using APBDKOLOS.Dtos;
using APBDKOLOS.Models;

namespace APBDKOLOS.Services;

public interface ISubService
{
    ClientandSubDto? GetClientAndSubscription(int id);
    Subscription? GetSubscription(int id);
    Client? GetClient(int id);
    bool PostPayment(PaymentRequestDto paymentRequestDto);
}