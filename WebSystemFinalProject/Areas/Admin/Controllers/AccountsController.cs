using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Web.Models;
using Web.Models.ViewModels;
using Web.Utility;

namespace WebSystemFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetails.Role_Super_Admin)]
    public class AccountsController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountsController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();

            // Create a dictionary to store user roles for faster lookup
            var userRoles = new Dictionary<string, string>();

            // Fetch roles for each user
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var role = roles.FirstOrDefault(); // Assuming each user has only one role
                userRoles.Add(user.Id, role);
            }

            ViewBag.UserRoles = userRoles;
            return View(users);
        }




        [HttpGet]
        public IActionResult Create()
        {
            // Populate roles dropdown
            ViewBag.Roles = _roleManager.Roles.Select(r => new SelectListItem { Text = r.Name, Value = r.Name });
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // Assign role
                    await _userManager.AddToRoleAsync(user, model.Role);
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            // If model state is not valid, return to the view with roles dropdown
            ViewBag.Roles = _roleManager.Roles.Select(r => new SelectListItem { Text = r.Name, Value = r.Name });
            return View(model);
        }





        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            EditUserViewModel model = new()
            {
                Email = user.Email,
                Role = userRoles.FirstOrDefault()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditUserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //assign the updated value of model.Email to the value of email ng account na nasa database
                user.Email = model.Email;


                // Remove existing roles
                var existingRoles = await _userManager.GetRolesAsync(user); //retrieve lahat ng available roles na involve si user
                await _userManager.RemoveFromRolesAsync(user, existingRoles); //remove si user sa mga roles na involve sya

                // Add the new role
                await _userManager.AddToRoleAsync(user, model.Role); //assign sa user yung role na value ni view model


                // Save changes
                await _userManager.UpdateAsync(user);

                return RedirectToAction("Index");
            }

            return View(user);
        }



        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            //if successful
            return RedirectToAction("Index");
        }
    }
}
