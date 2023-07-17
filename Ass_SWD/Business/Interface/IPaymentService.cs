using Ass_SWD.Models;

namespace Ass_SWD.Business.Interface
{
    public interface IPaymentService
    {
        void AddPayment(Payment payment);
       
        void AddPayment(DataAccess.Models.Payment paymentEntity);
    }
}
