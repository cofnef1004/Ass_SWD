using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ass_SWD.Pages.Fee;

using Ass_SWD.Business.Interface;
using Ass_SWD.Bussiness.Interface;
using Microsoft.AspNetCore.Mvc;

public class Update : PageModel
{
    private readonly IPatientRepository patientRepository;
    private readonly IFeeRepository     feeRepository;
    private readonly IServiceRepository serviceRepository;
    private readonly IRecordRepository  recordRepository;

    public int FeeId;
    public int Fee;
    
    public Update(IPatientRepository patientRepository,
        IFeeRepository feeRepository,
        IServiceRepository serviceRepository,
        IRecordRepository recordRepository)
    {
        this.patientRepository = patientRepository;
        this.feeRepository     = feeRepository;
        this.serviceRepository = serviceRepository;
        this.recordRepository  = recordRepository;
    }
    
    public void OnGet(int id)
    {
        this.FeeId = id;
    }

    public IActionResult OnPostUpdateFee(int feeId, decimal amount, string method)
    {
        var fee = this.feeRepository.GetFeeById(feeId);
        fee.Amount = amount;
        fee.Method = method;
        this.feeRepository.UpdateFee(fee);
        return this.Redirect("/Patients");
    }
}