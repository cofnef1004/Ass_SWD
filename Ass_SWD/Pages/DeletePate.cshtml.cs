using Ass_SWD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ass_SWD.Pages
{
    public class DeletePateModel : PageModel
    {
		public IList<Models.Patient> Patients { get; set; } = default!;
		MyStoreContext _context = new MyStoreContext();
		public int Id;
		public IActionResult OnGet(int id)
		{
			try
			{
				var db = _context.Patients.Include(p => p.Insurances).Include(p => p.Records).Where(p => p.PatientId == id).FirstOrDefault(p=>p.PatientId==id);
				
				if (db == null)
				{
					return NotFound();
				}

				// Xử lý xóa dữ liệu từ nhiều bảng

				/*var dependentRecords = _context.Records.Where(r => r.PatientId == id);
				_context.Records.RemoveRange(dependentRecords);

				var ins = db.Insurances.Where(i => i.PatientId == id);
				_context.Insurances.RemoveRange(ins);*/
				
				_context.Patients.Remove(db);
				_context.SaveChanges();

				return RedirectToPage("/Patients");
			}
			catch(Exception ex)
			{
				ModelState.AddModelError("", "Benh nhan dang trong trang thai kham nen ko the xoa!");
				TempData["ErrorMessage"] = "Bệnh nhân đang trong trạng thái khám, không thể xóa!";
				return RedirectToPage("/Patients");
			}
			/*using (var db = new MyStoreContext())
			{
				//Models.Patient pate = db.Patients.FirstOrDefault(p => p.PatientId == id);
			
				var data = db.Patients.Include(p => p.Insurances).Include(p => p.Records).Where(p => p.PatientId == id).FirstOrDefault(); ;
				*//*db.Patients.Include(p => p.Insurances).Include(p => p.Records);
				db.SaveChanges();*//*
				if (data == null)
				{
					return NotFound();
				}
				var dependentRecords = db.Records.Where(r => r.PatientId == id);
				db.Records.RemoveRange(dependentRecords);
				
				var ins = db.Insurances.Where(i => i.PatientId == id);
				db.Insurances.RemoveRange(ins);
		

				db.Patients.Remove(data);
				db.SaveChanges();
			
			//	Patients = db.Patients.Where(p => p.PatientId == Id).ToList();
				return RedirectToPage("/Patients");
			}*/
		}
	}
}
