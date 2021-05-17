namespace ClicksAndDrive.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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

        public Bicycle Edit(int id)
        {
            return this.db.Bicycles.FirstOrDefault(b => b.Id == id);
        }

        public void DoEdit(EditBicycleViewModel input)
        {
            var bicycle = this.db.Bicycles.FirstOrDefault(b => b.Id == input.Id);

            if (bicycle != null)
            {
                bicycle.Made = input.Made;
                bicycle.Type = input.Type;
                bicycle.Speeds = input.Speeds;
                bicycle.PriceForHour = input.PriceForHour;
                bicycle.Size = input.Size;
                bicycle.SizeOfTires = input.SizeOfTires;
                bicycle.Description = input.Description;

                this.db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var bicycle = this.db.Bicycles.FirstOrDefault(b => b.Id == id);

            if (bicycle != null)
            {
                this.db.Bicycles.Remove(bicycle);

                this.db.SaveChanges();
            }
        }
    }
}
