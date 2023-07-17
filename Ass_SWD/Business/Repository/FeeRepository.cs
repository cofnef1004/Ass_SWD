using Ass_SWD.Bussiness.Interface;
using Ass_SWD.Models;
using Microsoft.EntityFrameworkCore;

namespace Ass_SWD.Bussiness.Repository
{
    public class FeeRepository : IFeeRepository
    {
        MyStoreContext context;

        public FeeRepository(MyStoreContext context)
        {
            this.context = context;
        }

        public async Task<Fee> GetFeeByRecordIdAsync(int id)
        {
            return await context.Fees.FindAsync(id);
            
        }
        public async Task<List<Fee>> GetFeesByRecordIdAsync(int id)
        {
            return await context.Fees.Where(o => o.RecordId == id).ToListAsync();
        }
    }
}
