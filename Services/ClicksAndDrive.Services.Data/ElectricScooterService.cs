namespace ClicksAndDrive.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using ClicksAndDrive.Data;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.ViewModels.ElectricScooter;

    public class ElectricScooterService : IElectricScooterService
    {
        private readonly ApplicationDbContext db;

        public ElectricScooterService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public ElectricScooter Details(int id)
        {
            return this.db.ElectricScooters.FirstOrDefault(es => es.Id == id);
        }

        public IEnumerable<ElectricScooterViewModel> GetAll()
        {
            return this.db.ElectricScooters
                .Where(ec => ec.IsAvailable)
                .Select(ec => new ElectricScooterViewModel()
                {
                    Id = ec.Id,
                    Made = ec.Made,
                    PriceForHour = ec.PriceForHour,
                    ImageUrl = ec.ImageUrl,
                })
                .ToArray();
        }
    }
}
