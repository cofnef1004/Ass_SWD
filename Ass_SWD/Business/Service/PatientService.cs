using Ass_SWD.Models;

namespace Ass_SWD.Business.Service
{
    public class PatientService
    {
        private Models.MyStoreContext _context = new MyStoreContext();

        public void connectInsurance(Insurance insurance)
        {
            if (!_context.Insurances.Any(x => x.PatientId == insurance.PatientId
                 && x.Number == insurance.Number && x.Type.Equals(insurance.Type)))
            {
                _context.Insurances.Add(insurance);
                _context.SaveChanges();
            }
        }

        public void modify(Insurance insurance)
        {
            if (!_context.Insurances.Any(x => x.PatientId != insurance.PatientId
                 && x.Number == insurance.Number && x.Type.Equals(insurance.Type)))
            {
                _context.Insurances.Update(insurance);
                _context.SaveChanges();
            }

        }
    }
}
