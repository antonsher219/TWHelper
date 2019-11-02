using Domain.Models.Identity;
using TWHelp.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace TWHelp.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        RoleManager<IdentityRole<long>> _roleManager;
        UserManager<User> _userManager;

        public RolesController(RoleManager<IdentityRole<long>> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // GET: api/roles/all
        [HttpGet("all")]
        public IActionResult GetAllRoles()
        {
            List<IdentityRole<long>> roles = _roleManager.Roles.ToList();
            return Ok(roles);
        }

        // POST: api/roles/create/{name}
        [HttpPost("create/{name}")]
        public async Task<IActionResult> CreateNewRole(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }

            var role = new IdentityRole<long>(name);
            IdentityResult result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                string errorsDescription = string.Empty;

                foreach (var error in result.Errors)
                {
                    errorsDescription += error.Description;
                }

                return BadRequest(errorsDescription);
            }

            return Ok(name);
        }

        // POST: api/roles/add/{userid}/{role}
        [HttpPost("add/{userid}/{role}")]
        public async Task<IActionResult> AddNewRole(long userID, string role)
        {
            User user = await _userManager.FindByIdAsync(userID.ToString());

            if (user == null || role == null)
            {
                return BadRequest();
            }

            IdentityRole<long> identityRole = new IdentityRole<long>(role);
            
            IdentityResult identityResult = await _roleManager.CreateAsync(identityRole);

            if(identityResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, role);

                return Ok();
            }

            return BadRequest("role manager has not created role");
        }

        // DELETE: api/roles/delete/{name}
        [HttpDelete("delete/{name}")]
        public async Task<IActionResult> DeleteRole(string name)
        {
            IdentityRole<long> role = await _roleManager.FindByIdAsync(name);
            
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);

                return Ok();
            }

            return NoContent();
        }

        //DELETE: api/roles/delete/all
        [HttpDelete("delete/all")]
        public async Task<IActionResult> DeleteAllRoles()
        {
            User user = await _userManager.GetUserAsync(User);

            IList<string> userRoles = await _userManager.GetRolesAsync(user);
            IdentityResult result = await _userManager.RemoveFromRolesAsync(user, userRoles);

            if(result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}