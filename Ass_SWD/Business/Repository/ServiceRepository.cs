namespace Ass_SWD.Bussiness.Repository
{
	using Ass_SWD.Bussiness.Interface;
	using Ass_SWD.Models;

	public class ServiceRepository : IServiceRepository
	{
		private readonly MyStoreContext context;

		public ServiceRepository(MyStoreContext context)
		{
			this.context = context;
		}
		
		public List<Service> GetServices()
		{
			return this.context.Services.ToList();
		}
	}
}
