using Ass_SWD.Bussiness.Interface;
using Ass_SWD.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Ass_SWD.Bussiness.Repository
{
	public class RecordRepository : IRecordRepository
	{
		MyStoreContext context;

		public RecordRepository(MyStoreContext context)
		{
			this.context = context;
		}

		public List<Record> GetAll()
		{
			throw new NotImplementedException();
		}
        public async Task<List<Service>> GetServicesAsync()
        {
            return await context.Services.ToListAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await context.Patients.FindAsync(id);
        }

        public async Task<List<Record>> GetMedicalRecordsByPatientIdAsync(int patientId)
        {
            return await context.Records
                .Include(r => r.Service)
                .Where(r => r.PatientId == patientId)
                .ToListAsync();
        }

        public async Task<Record> GetMedicalRecordByIdAsync(int recordId)
        {
            return await context.Records.FindAsync(recordId);
        }

        public async Task AddMedicalRecordAsync(Record record)
        {
            await context.Records.AddAsync(record);
            await context.SaveChangesAsync();
        }

        public async Task UpdateMedicalRecordAsync(Record record)
        {
            context.Records.Update(record);
            await context.SaveChangesAsync();
        }

        public async Task DeleteMedicalRecordAsync(Record record)
        {
            context.Records.Remove(record);
            await context.SaveChangesAsync();
        }
    }
}
