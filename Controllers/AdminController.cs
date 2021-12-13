using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ParcelTrackingSystem.Data;

namespace ParcelTrackingSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly INotyfService notifyService;

        public AdminController(ApplicationDbContext context, UserManager<IdentityUser> userManager, INotyfService notifyService)
        {
            this.context = context;
            this.userManager = userManager;
            this.notifyService = notifyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewAdmins()
        {
            return View();
        }

        public ActionResult Update(string id)
        {
            return View(context.Users.Where(s => s.Id == id).First());
        }

        [HttpPost]
        public IActionResult Update(IdentityUser identityUser)
        {
            try
            {
                IdentityUser user = context.Users.Where(s => s.Id == identityUser.Id).First();
                user.UserName = identityUser.UserName;
                user.PasswordHash = identityUser.PasswordHash;
                user.Email = identityUser.Email;
                context.SaveChanges();
                this.notifyService.Success("User Updated Successfully!");
                return RedirectToAction("ViewAdmins", "Admin");
            } catch (Exception ex)
            {
                this.notifyService.Error("User Updated Failed!");
                return View();
            }

        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            try
            {
                IdentityUser adminUser = context.Users.Where(s => s.Id == id).First();
                context.Users.Remove(adminUser);
                context.SaveChanges();
                this.notifyService.Success("User Deleted Successfully!");
                return RedirectToAction("ViewAdmins","Admin");
            }
            catch (System.Exception)
            {
                this.notifyService.Error("User Delete Failed!");
                return View();
            }
        }

        [HttpPost]
        public ActionResult CreateAdminUser(IdentityUser adminUser)
        {
            try
            {
                IdentityUser user = new IdentityUser();
                user.Email = adminUser.Email;
                user.UserName = adminUser.UserName;
                IdentityResult result = userManager.CreateAsync(user, adminUser.PasswordHash).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                    this.notifyService.Success("User Added Successfully!");
                }
                return RedirectToAction("ViewAdmins", "Admin");
            } catch
            {
                this.notifyService.Error("User Delete Failed!");
                return View();
            }
        }
    }
}
