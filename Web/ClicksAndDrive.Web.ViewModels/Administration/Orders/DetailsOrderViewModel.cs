namespace ClicksAndDrive.Web.ViewModels.Orders
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AutoMapper;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Services.Mapping;

    public class DetailsOrderViewModel : IMapFrom<Order>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public decimal PriceForHour { get; set; }

        public DateTime DateTo { get; set; }

        public DateTime? DateFrom { get; set; }

        public decimal TotalSum { get; set; }

        public byte Discount { get; set; }

        public IEnumerable<Image> Images { get; set; }

        public StatusType Status { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Order, DetailsOrderViewModel>()
               .ForMember(x => x.Email, opt =>
               {
                   opt.MapFrom(x => x.User.Email);
               })
                 .ForMember(x => x.PhoneNumber, opt =>
              {
                  opt.MapFrom(x => x.User.PhoneNumber);
              })
             .ForMember(x => x.Discount, opt =>
              {
                  opt.MapFrom(x => x.User.Discount);
              });
        }
    }
}
