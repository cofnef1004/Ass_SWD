namespace Ass_SWD.Business.Interface
{
    using Ass_SWD.Models;

    public interface IPatientRepository
    {
		List<Patient> GetPatients();
        Patient GetPatientById(int id);
        public void AddPatient(Patient patient);
        public void UpdatePatient(Patient patient);
        void DeletePatient(Patient patient);

        void connectInsurance(Insurance insurance);
        void modify(Insurance insurance);
    }
}
