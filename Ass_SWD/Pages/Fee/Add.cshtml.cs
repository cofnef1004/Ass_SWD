namespace Ass_SWD.Pages.Fee;

using Ass_SWD.Business.Interface;
using Ass_SWD.Bussiness.Interface;
using Ass_SWD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class Add : PageModel
{
    private readonly IPatientRepository patientRepository;
    private readonly IFeeRepository     feeRepository;
    private readonly IServiceRepository serviceRepository;
    private readonly IRecordRepository  recordRepository;

    public List<Patient> Patients;
    public List<Service> Services;
    public int           RecordId;
    public Record        Record;

    public Add(IPatientRepository patientRepository, IFeeRepository feeRepository, IServiceRepository serviceRepository,
        IRecordRepository recordRepository)
    {
        this.patientRepository = patientRepository;
        this.feeRepository     = feeRepository;
        this.serviceRepository = serviceRepository;
        this.recordRepository  = recordRepository;
    }
    
    public async void OnGet(int id)
    {
        this.Patients = this.patientRepository.GetPatients();
        this.Services = this.serviceRepository.GetServices();
        this.RecordId = id;
        this.Record = await this.recordRepository.GetMedicalRecordByIdAsync(id);
    }

    public async Task<IActionResult> OnPostAddFee(int recordId, decimal amount, string method)
    {
        var nFee = new Fee()
        {
            FeeId = 0,
            RecordId = recordId,
            Amount   = amount,
            PaymentDate = DateTime.Now,
            PaiedDate = DateTime.Now,
            Method   = method
        };
        this.feeRepository.AddFee(nFee);
        return this.Redirect("/Patients");
    }
}