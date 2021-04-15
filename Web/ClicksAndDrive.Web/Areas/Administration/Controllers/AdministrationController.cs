namespace ClicksAndDrive.Web.Areas.Administration.Controllers
{
    using ClicksAndDrive.Common;
    using ClicksAndDrive.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
