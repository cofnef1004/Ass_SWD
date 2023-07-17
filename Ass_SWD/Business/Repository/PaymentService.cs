using Ass_SWD.Business.Interface;
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

        public void AddPayment(DataAccess.Models.Payment paymentEntity)
        {
            throw new NotImplementedException();
        }
    }
}
