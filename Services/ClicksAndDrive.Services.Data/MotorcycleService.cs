namespace ClicksAndDrive.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using ClicksAndDrive.Data;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.ViewModels.Motorcycles;

    public class MotorcycleService : IMotorcycleService
    {
        private readonly ApplicationDbContext db;

        public MotorcycleService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Motorcycle Details(int id)
        {
            return this.db.Motorcycles.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<MotorcycleViewModel> GetAll()
        {
            return this.db.Motorcycles
                .Where(m => m.IsAvailable)
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
