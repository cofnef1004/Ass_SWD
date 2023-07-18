
﻿using Ass_SWD.Bussiness.Interface;
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
            return this._context.Patients.ToList();
        }

        public void AddPatient(Patient patient)
        {
            this._context.Patients.Add(patient);
            this._context.SaveChanges();
        }

        public void UpdatePatient(Patient patient)
        {
            this._context.Patients.Update(patient);
            this._context.SaveChanges();
        }

        public void DeletePatient(Patient patient)
        {
            this._context.Patients.Remove(patient);
            this._context.SaveChanges();
        }

        public Patient GetPatientById(int id)
        {
            return this._context.Patients.FirstOrDefault(p => p.PatientId == id);
        }

        public void connectInsurance(Insurance insurance)
        {
            if (!this._context.Insurances.Any(x => x.PatientId == insurance.PatientId
                                                   && x.Number == insurance.Number && x.Type.Equals(insurance.Type)))
            {
                this._context.Insurances.Add(insurance);
                this._context.SaveChanges();
            }
        }

        public void modify(Insurance insurance)
        {
            if (!this._context.Insurances.Any(x => x.PatientId == insurance.PatientId
                                                   && x.Number == insurance.Number && x.Type.Equals(insurance.Type)))
            {
                this._context.Insurances.Update(insurance);
                this._context.SaveChanges();
            }

        }
    }
}
