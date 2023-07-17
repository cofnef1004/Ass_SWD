using Ass_SWD.Bussiness.Interface;
using Ass_SWD.Models;
using Microsoft.EntityFrameworkCore;

namespace Ass_SWD.Bussiness.Repository
{
    public class PatientRepository : IPatientRepository
    {
        MyStoreContext _context;

        public PatientRepository(MyStoreContext context)
        {
            this._context = context;
        }

        public List<Patient> GetPatients()
        {
            return _context.Patients.ToList();
        }

        public void AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public void UpdatePatient(Patient patient)
        {
            _context.Patients.Update(patient);
            _context.SaveChanges();
        }

        public void DeletePatient(Patient patient)
        {
            _context.Patients.Remove(patient);
            _context.SaveChanges();
        }

        public Patient GetPatientById(int id)
        {
            return _context.Patients.FirstOrDefault(p => p.PatientId == id);
        }

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
            if (!_context.Insurances.Any(x => x.PatientId == insurance.PatientId
                 && x.Number == insurance.Number && x.Type.Equals(insurance.Type)))
            {
                _context.Insurances.Update(insurance);
                _context.SaveChanges();
            }

        }
    }
}
