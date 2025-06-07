using APBDKOLOS.Dtos;
using APBDKOLOS.Models;
using Microsoft.EntityFrameworkCore;

namespace APBDKOLOS.Services;

public class SubService : ISubService
{
    private readonly ApiContext _apiContext;

    public SubService(ApiContext apiContext)
    {
        _apiContext = apiContext;
    }
    
    public ClientandSubDto? GetClientAndSubscription(int id)
    {
        var client = GetClient(id);

        if (client == null)
        {
            Console.WriteLine($"Wrong client ID {id}");
            return null;
        }
        
        var subscription = client.Sales
            .Select(s => s.Subscription)
            .FirstOrDefault();

        if (subscription == null)
        {
            Console.WriteLine($"No subscription");
            return null;
        }
            

        return new ClientandSubDto
        {
            FirstName = client.FirstName,
            LastName = client.LastName,
            Email = client.Email,
            Phone = client.Phone
        };
    }

    public Subscription? GetSubscription(int id)
    {
        return _apiContext.Subscriptions
            .Include(s => s.Discounts)
            .Include(s => s.Sales)
            .Include(s => s.Payments)
            .FirstOrDefault(s => s.IdSubscription == id);
    }
    
    public Client? GetClient(int id)
    {
        return _apiContext.Clients
            .Include(c => c.Sales)
                .ThenInclude(s => s.Subscription)
            .Include(c => c.Payments)
            .FirstOrDefault(c => c.IdClient == id);
    }
    
    public IEnumerable<Subscription> GetAllSubscriptions()
    {
        return _apiContext.Subscriptions
            .Include(s => s.Discounts)
            .Include(s => s.Sales)
            .Include(s => s.Payments)
            .ToList();
    }
    
    public IEnumerable<Client> GetAllClients()
    {
        return _apiContext.Clients
            .Include(c => c.Sales)
            .Include(c => c.Payments)
            .ToList();
    }
    
    public bool PostPayment(PaymentRequestDto paymentRequest)
        {
            var client = GetClient(paymentRequest.IdClient);
            if (client == null)
                throw new ArgumentException("No client");

            var subscription = GetSubscription(paymentRequest.IdSubscription);
            if (subscription == null)
                throw new ArgumentException("No subscription.");

            var sale = _apiContext.Sales
                .Where(s => s.IdClient == paymentRequest.IdClient && s.IdSubscription == paymentRequest.IdSubscription)
                .OrderByDescending(s => s.CreatedAt)
                .FirstOrDefault();

            if (sale == null)
                throw new InvalidOperationException("No sale found for subscription");

            var currentDate = DateTime.Now;
            var subscriptionStart = sale.CreatedAt;
            var monthsElapsed = ((currentDate.Year - subscriptionStart.Year) * 12) + currentDate.Month - subscriptionStart.Month;
            var currentPeriodStart = subscriptionStart.AddMonths((monthsElapsed / subscription.RenewalPeriod) * subscription.RenewalPeriod);
            var currentPeriodEnd = currentPeriodStart.AddMonths(subscription.RenewalPeriod);

            var existingPayment = _apiContext.Payments
                .Any(p => p.IdClient == paymentRequest.IdClient && 
                              p.IdSubscription == paymentRequest.IdSubscription &&
                              p.Date >= currentPeriodStart && 
                              p.Date < currentPeriodEnd);

            if (existingPayment)
                throw new InvalidOperationException("Payment exists");

            var expectedAmount = subscription.Price;
            var activeDiscount = _apiContext.Discounts
                .Where(d => d.IdSubscription == paymentRequest.IdSubscription &&
                           d.DateFrom <= currentDate &&
                           d.DateTo >= currentDate)
                .OrderByDescending(d => d.Value)
                .FirstOrDefault();
            
            var payment = new Payment
            {
                Date = DateTime.Now,
                IdClient = paymentRequest.IdClient,
                IdSubscription = paymentRequest.IdSubscription,
                Amount = paymentRequest.Payment
            };

            _apiContext.Payments.Add(payment);
            _apiContext.SaveChangesAsync();

            return true;
        }
}