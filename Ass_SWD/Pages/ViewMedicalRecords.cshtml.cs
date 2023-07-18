
using Ass_SWD.Bussiness.Interface;
using Ass_SWD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Ass_SWD.Pages
{
    

    public class ViewMedicalRecordsModel : PageModel
    {
        private readonly IRecordRepository _recordRepository;
        private readonly IFeeRepository    feeRepository;

        public ViewMedicalRecordsModel(IRecordRepository recordRepository, IFeeRepository feeRepository)
        {
            _recordRepository  = recordRepository;
            this.feeRepository = feeRepository;
        }

        public List<Record> MedicalRecords { get; set; }

        public Patient          Patient { get; set; }
        public List<Models.Fee> Fees    { get; set; }

        [BindProperty]
        public Record MedicalRecord { get; set; }

        public SelectList Services { get; private set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = await _recordRepository.GetPatientByIdAsync(id.Value);

            if (Patient == null)
            {
                return NotFound();
            }

            MedicalRecords = await _recordRepository.GetMedicalRecordsByPatientIdAsync(id.Value);

            Services = new SelectList(await _recordRepository.GetServicesAsync(), nameof(Service.ServiceId), nameof(Service.Name));

            return Page();
        }
    }
}
