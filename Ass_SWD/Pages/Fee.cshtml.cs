namespace Ass_SWD.Pages
{
    using Ass_SWD.Business.Interface;
    using Ass_SWD.Bussiness.Interface;
    using Ass_SWD.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class FeeModel : PageModel
    {
        IRecordRepository _recordRepository;
        IFeeRepository _feeRepository;

        public FeeModel( IRecordRepository recordRepository, IFeeRepository feeRepository)
        {
            _recordRepository = recordRepository;
            _feeRepository = feeRepository;
        }

        [BindProperty(SupportsGet = true)]
        public Record record { get; set; }

        [BindProperty]
        public List<Models.Fee> Fees { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            record = await _recordRepository.GetMedicalRecordByIdAsync(id.Value);

            if (record == null)
            {
                return NotFound();
            }

            Fees = await _feeRepository.GetFeesByRecordIdAsync(id.Value);
            return Page();
        }
    }
}
