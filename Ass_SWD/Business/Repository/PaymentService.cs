using Ass_SWD.Business.Interface;
using Ass_SWD.DataAccess.Models;

namespace Ass_SWD.Business.Repository
{
    public class PaymentService : IPaymentService
    {

        MyStoreContext _storeContext;
        public PaymentService(MyStoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public void AddPayment(Models.Payment payment)
        {
            _storeContext.Payments.Add(payment);
            _storeContext.SaveChanges();
        }
    }
}
