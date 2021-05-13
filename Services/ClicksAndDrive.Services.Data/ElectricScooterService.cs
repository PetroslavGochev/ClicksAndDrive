namespace ClicksAndDrive.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using ClicksAndDrive.Data;
    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.ViewModels.ElectricScooter;

    public class ElectricScooterService : IElectricScooterService
    {
        private readonly ApplicationDbContext db;

        public ElectricScooterService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<ElectricScooterViewModel> GetAll()
        {
            return this.db.ElectricScooters
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
