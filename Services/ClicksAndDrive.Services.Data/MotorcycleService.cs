namespace ClicksAndDrive.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using ClicksAndDrive.Data;
    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.ViewModels.Motorcycles;

    public class MotorcycleService : IMotorcycleService
    {
        private readonly ApplicationDbContext db;

        public MotorcycleService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<MotorcycleViewModel> GetAll()
        {
            return this.db.Motorcycles
                .Select(m => new MotorcycleViewModel()
                {
                    Id = m.Id,
                    Made = m.Made,
                    PriceForHour = m.PriceForHour,
                    ImageUrl = m.ImageUrl,
                })
                .ToArray();
        }
    }
}
