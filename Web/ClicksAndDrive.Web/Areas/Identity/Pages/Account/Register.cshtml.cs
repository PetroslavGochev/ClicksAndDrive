namespace ClicksAndDrive.Web.Areas.Identity.Pages.Account
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;

    using ClicksAndDrive.Common;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.ViewModels.AttributesValidation;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.WebUtilities;
    using Microsoft.Extensions.Logging;

    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<RegisterModel> logger;
        private readonly IEmailSender emailSender;
        private readonly IImageService imageService;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IImageService imageService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.emailSender = emailSender;
            this.imageService = imageService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = GlobalConstants.Required)]
            [EmailAddress(ErrorMessage = GlobalConstants.InvalidEmail)]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = GlobalConstants.Required)]
            [StringLength(100, ErrorMessage = GlobalConstants.InvalidPassword, MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = GlobalConstants.PasswordDoesntMatch)]
            public string ConfirmPassword { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Рождена дата")]
            [YearAttribute]
            public DateTime DateOfBirth { get; set; }

            [Required(ErrorMessage = GlobalConstants.Required)]
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Телефонен номер")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = GlobalConstants.Required)]
            [Display(Name = "Документ за самоличност")]
            public IEnumerable<IFormFile> Images { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            this.ReturnUrl = returnUrl;
            this.ExternalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= this.Url.Content("~/");
            this.ExternalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (!this.IsImageValid(this.Input.Images))
            {
                this.ModelState.AddModelError("Images", "Invalid Images");
            }

            if (this.ModelState.IsValid)
            {
                var age = YearCalculator.CalculateYear(this.Input.DateOfBirth);
                var user = new ApplicationUser
                {
                    UserName = this.Input.Email,
                    Email = this.Input.Email,
                    PhoneNumber = this.Input.PhoneNumber,
                    Age = age,
                };

                var result = await this.userManager.CreateAsync(user, this.Input.Password);

                if (this.Input.Images.Any())
                {
                   await this.imageService.UploadImages(this.Input.Images.ToList(), this.Input.Images.Count(), user.Id);
                }

                if (result.Succeeded)
                {
                    this.logger.LogInformation("User created a new account with password.");

                    var code = await this.userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = this.Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: this.Request.Scheme);

                    await this.emailSender.SendEmailAsync(
                        this.Input.Email,
                        "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (this.userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return this.RedirectToPage("RegisterConfirmation", new { email = this.Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await this.signInManager.SignInAsync(user, isPersistent: false);
                        return this.LocalRedirect(returnUrl);
                    }
                }

                foreach (var error in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return this.Page();
        }

        private bool IsImageValid(IEnumerable<IFormFile> images)
        {
            foreach (var image in images)
            {
                if (image.Length > 10 * 1024 * 1024)
                {
                    return false;
                }
                else if (image.FileName.EndsWith(".jpg"))
                {
                    continue;
                }
                else if (image.FileName.EndsWith(".jpeg"))
                {
                    continue;
                }
                else if (image.FileName.EndsWith(".png"))
                {
                    continue;
                }
                else if (image.FileName.EndsWith(".gif"))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
