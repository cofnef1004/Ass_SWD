using Ass_SWD.DataAccess.Models;

namespace Ass_SWD.Bussiness.Interface
{
	public interface IFeeRepository
	{
        Task<List<Fee>> GetFeesByRecordIdAsync(int id);
        Task<Fee> GetFeeByRecordIdAsync(int id);
    }
}
