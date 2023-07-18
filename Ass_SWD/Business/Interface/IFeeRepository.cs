
﻿using Ass_SWD.Models;

namespace Ass_SWD.Bussiness.Interface

{
	using Ass_SWD.Models;

	public interface IFeeRepository
	{
        Task<List<Fee>> GetFeesByRecordIdAsync(int id);
        Task<Fee>       GetFeeByRecordIdAsync(int id);
        List<Fee>       GetAllFees();
        void            AddFee(Fee f);
        void            UpdateFee(Fee f);
        Fee             GetFeeById(int id);
	}
}
