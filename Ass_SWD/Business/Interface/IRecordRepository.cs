
﻿using Ass_SWD.Models;

namespace Ass_SWD.Bussiness.Interface

{
	

	public interface IRecordRepository
	{
		List<Record> GetAll();
        Task<List<Service>> GetServicesAsync();
        Task<Patient> GetPatientByIdAsync(int id);
        Task<List<Record>> GetMedicalRecordsByPatientIdAsync(int patientId);
        Task<Record> GetMedicalRecordByIdAsync(int recordId);
        Task AddMedicalRecordAsync(Record record);
        Task UpdateMedicalRecordAsync(Record record);
        Task DeleteMedicalRecordAsync(Record record);

    }
}
