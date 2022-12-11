using HotelOtomation.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HotelOtomation.UI.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AppRole role)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AppRole role)
        {
            var updatedRole = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == role.Id);
            updatedRole.Name = role.Name;
            var result = await _roleManager.UpdateAsync(updatedRole);
            if (result.Succeeded)
                return RedirectToAction("Index");
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
                return RedirectToAction("Index");
            return View();
        }
    }
}
