using E_Voting_System.Areas.Identity.Data;
using E_Voting_System.Data;
using E_Voting_System.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Voting_System.Controllers
{
    public class Admin : Controller
    {
        private UserManager<E_Voting_SystemUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private E_Voting_SystemContext _context;

        public Admin(UserManager<E_Voting_SystemUser> userManager,
            RoleManager<IdentityRole> roleManager, 
            E_Voting_SystemContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ViewVoters()
        {
            
            var voters = await (from user in _context.Users 
                                          join userRole in _context.UserRoles 
                                          on user.Id equals userRole.UserId 
                                          join role in _context.Roles 
                                          on userRole.RoleId equals role.Id 
                                          where role.Name != "Admin" 
                                          select user)
                                          .ToListAsync();

            ConvertApplicationUser ViewModelUsers = new ConvertApplicationUser(voters);
            return View(ViewModelUsers.ApplicationUsers);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}   
