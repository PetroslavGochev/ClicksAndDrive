namespace ClicksAndDrive.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using ClicksAndDrive.Data;
    using ClicksAndDrive.Web.ViewModels.Cars;

    public class CarService : ICarService
    {
        private readonly ApplicationDbContext db;

        public CarService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CarViewModel> GetAll()
        {
          return this.db.Cars
                .Select(c => new CarViewModel()
                {
                    Id = c.Id,
                    Made = c.Made,
                    Model = c.Model,
                    PriceForHour = c.PriceForHour,
                    ImageUrl = c.ImageUrl,
                })
                .ToArray();
        }
    }
}
