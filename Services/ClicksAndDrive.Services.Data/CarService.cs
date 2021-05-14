namespace ClicksAndDrive.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using ClicksAndDrive.Data;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Web.ViewModels.Cars;

    public class CarService : ICarService
    {
        private readonly ApplicationDbContext db;

        public CarService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Car Details(int id)
        {
            return this.db.Cars.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<CarViewModel> GetAll()
        {
            return this.db.Cars
                  .Where(c => c.IsAvailable)
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
