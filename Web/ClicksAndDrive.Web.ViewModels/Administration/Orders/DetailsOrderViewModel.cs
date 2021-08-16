namespace ClicksAndDrive.Web.ViewModels.Orders
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using AutoMapper;
    using ClicksAndDrive.Common;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Services.Mapping;

    public class DetailsOrderViewModel : IMapFrom<Order>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [Display(Name = GlobalConstants.Email)]
        public string Email { get; set; }

        [Display(Name = GlobalConstants.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = GlobalConstants.PriceForHour)]
        public decimal PriceForHour { get; set; }

        [Display(Name = GlobalConstants.DateTo)]
        public DateTime? DateTo { get; set; }

        [Display(Name = GlobalConstants.DateFrom)]
        public DateTime DateFrom { get; set; }

        [Display(Name = GlobalConstants.TotalSum)]
        public decimal TotalSum { get; set; }

        [Display(Name = GlobalConstants.Discount)]
        public byte Discount { get; set; }

        [Display(Name = GlobalConstants.Licens)]
        public IEnumerable<string> Images { get; set; }

        [Display(Name = GlobalConstants.OrderStatus)]
        public StatusType Status { get; set; }

        [Display(Name = GlobalConstants.Images)]
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
