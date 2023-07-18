
﻿using Ass_SWD.Bussiness.Interface;
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
        public Fee GetFeeById(int id)
        {
            var fee = this.context.Fees.FirstOrDefault(f => f.FeeId == id);
            return fee;
        }
        public async Task<List<Fee>> GetFeesByRecordIdAsync(int id)
        {
            return await context.Fees.Where(o => o.RecordId == id).ToListAsync();
        }
    }
}
