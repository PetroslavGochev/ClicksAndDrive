namespace ClicksAndDrive.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using ClicksAndDrive.Data;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Web.ViewModels.Bicycles;

    public class BicycleService : IBicycleService
    {
        private readonly ApplicationDbContext db;

        public BicycleService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<BicycleViewModel> GetAll(string[] size, string[] type)
        {
            var bicycles = this.db.Bicycles
                .Where(b => b.IsAvailable)
                .Select(b => new BicycleViewModel()
                {
                    Id = b.Id,
                    Made = b.Made,
                    PriceForHour = b.PriceForHour,
                    ImageUrl = b.ImageUrl,
                    Type = b.Type,
                    Size = b.Size,
                    Filters = size.Length == 0 && type.Length == 0 ? null : new FilterBicycleViewModel()
                    {
                        SizeOfBicycle = size,
                        TypeOfBicycle = type,
                    },
                })
                .ToArray();

            return bicycles;
        }

        public Bicycle Details(int id)
        {
            return this.db.Bicycles.FirstOrDefault(b => b.Id == id);
        }
    }
}
