namespace ClicksAndDrive.Web.ViewModels.Administration.Orders
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using ClicksAndDrive.Common;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Services.Mapping;

    public class OrdersViewModel : IMapFrom<Order>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [Display(Name = GlobalConstants.Email)]
        public string Email { get; set; }

        [Display(Name = GlobalConstants.OrderStatus)]
        public StatusType Status { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Order, OrdersViewModel>()
                .ForMember(x => x.Email, opt =>
                  {
                      opt.MapFrom(x => x.User.Email);
                  });
        }
    }
}
