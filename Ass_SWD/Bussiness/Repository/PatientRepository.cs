using Ass_SWD.Bussiness.Interface;
using Ass_SWD.DataAccess.Models;
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

    }
}
