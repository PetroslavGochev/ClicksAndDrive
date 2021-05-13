namespace ClicksAndDrive.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using ClicksAndDrive.Data;
    using ClicksAndDrive.Web.ViewModels.Bicycles;

    public class BicycleService : IBicycleService
    {
        private readonly ApplicationDbContext db;

        public BicycleService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<BicycleViewModel> GetAll()
        {
            return this.db.Bicycles
                .Select(b => new BicycleViewModel()
                {
                    Id = b.Id,
                    Made = b.Made,
                    PriceForHour = b.PriceForHour,
                    ImageUrl = b.ImageUrl,
                })
                .ToArray();
        }
    }
}
