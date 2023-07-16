using Ass_SWD.DataAccess.Models;

namespace Ass_SWD.Business.Interface
{
    public interface IPaymentService
    {
        public void AddPayment(Models.Payment payment);
    }
}
