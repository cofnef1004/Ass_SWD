
using Ass_SWD.Bussiness.Interface;
using Ass_SWD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace Ass_SWD.Pages
{
   

    public class PatientsModel : PageModel
    {
        IPatientRepository _patientRepository;
        public IList<Models.Patient> patients { get; set; } = default!;
       

        [BindProperty]
        public Patient Input { get; set; }
        public int Id;

        public PatientsModel(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public void OnGet()
        {
            patients = _patientRepository.GetPatients();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var patient = new Patient
            {
                FullName = Input.FullName,
                Gender = Input.Gender,
                Dob = Input.Dob,
                Address = Input.Address,
                Phone = Input.Phone,
                NumberId = Input.NumberId
            };

            try
            {
                _patientRepository.AddPatient(patient);
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                return Page();
            }
        }

       /* public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            *//*var pat = _patientRepository.GetPatientById(id);

            if (pat == null)
            {
                return NotFound();
            }*//*

            //try
           // {
                using(var db = new MyStoreContext())
                {
                    Models.Patient pate = db.Patients.FirstOrDefault(p => p.PatientId == Id);
                    //var pate= _patientRepository.GetPatientById(id);
                   
                db.Patients.Remove(pate);
                    db.SaveChanges();
                    patients = db.Patients.Include(p=> p.PatientId).Where(p => p.PatientId == Id).ToList();
                    return RedirectToPage("/Patients");
                }
               // _patientRepository.DeletePatient(pat);
                
               // return RedirectToPage();
           // }
           *//* catch (Exception ex)
            {
                return Page();
            }*//*
        }*/
    }
}
