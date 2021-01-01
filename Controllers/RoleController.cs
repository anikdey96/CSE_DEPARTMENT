//using CSE_DEPARTMENT.Models;
//using Microsoft.AspNet.Identity.Owin;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;

//namespace CSE_DEPARTMENT.Controllers
//{
//    //[Authorize(Roles = "SuperAdmin")]
//    public class RoleController : Controller
//    {
//        private ApplicationRoleManager _roleManager;
//        public RoleController()
//        {

//        }



//        public RoleController(ApplicationRoleManager roleManager)
//        {
//            RoleManager = roleManager;

//        }

//        public ApplicationRoleManager RoleManager
//        {
//            get
//            {
//                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
//            }
//            private set
//            {
//                _roleManager = value;
//            }
//        }

//        public async Task<ActionResult> DeleteRoles(string id)
//        {
//            var role = await RoleManager.FindByIdAsync(id);
//            return View(new RoleViewModel(role));
//        }

//        public async Task<ActionResult> DeleteRolesConfirmed(string id)
//        {
//            var role = await RoleManager.FindByIdAsync(id);
//            await RoleManager.DeleteAsync(role);
//            return RedirectToAction("Multidata", "ShowData");
//        }
//    }
//}