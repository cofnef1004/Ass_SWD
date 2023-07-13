using Ass_SWD.Bussiness.Interface;
using Ass_SWD.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ass_SWD.Pages
{
    public class PatientsModel : PageModel
    {
        IPatientRepository _patientRepository;

        public List<Patient> patients;

        [BindProperty]
        public Patient Input { get; set; }

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

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var patient = _patientRepository.GetPatientById(id);

            if (patient == null)
            {
                return NotFound();
            }

            try
            {
                _patientRepository.DeletePatient(patient);
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                return Page();
            }
        }
    }
}
