using Ass_SWD.Services;
using Ass_SWD.Models;

namespace Ass_SWD.Business.Repository
{
    public class PaymentService : IPaymentService
    {

        MyStoreContext _storeContext;
        public PaymentService(MyStoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public void AddPayment(Payment payment)
        {
            _storeContext.Payments.Add(payment);
            _storeContext.SaveChanges();
        }
    }
}
