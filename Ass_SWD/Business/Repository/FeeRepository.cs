namespace Ass_SWD.Bussiness.Repository
{
    using Ass_SWD.Business.Interface;
    using Ass_SWD.Models;
    using Microsoft.EntityFrameworkCore;

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
        public List<Fee> GetAllFees()
        {
            return this.context.Fees.ToList();
        }
        public void AddFee(Fee f)
        {
            this.context.Fees.Add(f);
            this.context.SaveChanges();
        }
        public void UpdateFee(Fee f)
        {
            this.context.Fees.Update(f);
            this.context.SaveChanges();
        }
        public async Task<List<Fee>> GetFeesByRecordIdAsync(int id)
        {
            return await context.Fees.Where(o => o.RecordId == id).ToListAsync();
        }
    }
}
