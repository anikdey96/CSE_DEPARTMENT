using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CSE_DEPARTMENT.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string RoleSelected { get; set; }

       
        

        public virtual ICollection<teacher> Teachers { get; set; }
        public virtual ICollection<student> Students { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }



    //public class ApplicationRole : IdentityRole
    //{
    //    public ApplicationRole() : base() { }
    //    public ApplicationRole(string roleName) : base(roleName) { }
    //}


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {

            return new ApplicationDbContext();
        }

       

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.activities> activities { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.student> students { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.book> books { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.Subject> Subjects { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.Year> Years { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.current_academic> current_academic { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.result> results { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.Session> Sessions { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.materials> materials { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.notice> notices { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.previous_academic> previous_academic { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.routine> routines { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.teacher> teachers { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.Staff> Staffs { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.staff_career> staff_career { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.teacher_career> teacher_career { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.Application> Applications { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.Staff_Application> Staff_Application { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.Faculty_Application> Faculty_Application { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.student_task_assign> student_task_assign { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.faculty_task_assign> faculty_task_assign { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.staff_task_assign> staff_task_assign { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.book12> book12 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.book21> book21 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.book22> book22 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.book31> book31 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.book32> book32 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.book41> book41 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.book42> book42 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.materials12> materials12 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.materials21> materials21 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.materials22> materials22 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.materials31> materials31 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.materials32> materials32 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.materials41> materials41 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.materials42> materials42 { get; set; }

 

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.routine21> routine21 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.routine22> routine22 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.routine31> routine31 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.routine32> routine32 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.routine41> routine41 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.routine42> routine42 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.book11> book11 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.materials11> materials11 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.notice11> notice11 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.notice12> notice12 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.notice21> notice21 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.notice22> notice22 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.notice31> notice31 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.notice32> notice32 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.notice41> notice41 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.notice42> notice42 { get; set; }

     

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.oldRoutine> oldRoutines { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.oldRoutine_2> oldRoutine_2 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.oldRoutine11> oldRoutine11 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.oldRoutine_12> oldRoutine_12 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.oldRoutine_21> oldRoutine_21 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.oldRoutine_22> oldRoutine_22 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.oldRoutine_31> oldRoutine_31 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.oldRoutine_32> oldRoutine_32 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.oldRoutine_41> oldRoutine_41 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.oldRoutine_42> oldRoutine_42 { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.moFacultyInfo> moFacultyInfoes { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.emFacultyInfo> emFacultyInfoes { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.shFacultyInfo> shFacultyInfoes { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.moFacultyApplication> moFacultyApplications { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.designationEm> designationEms { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.designationMo> designationMoes { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.designationSha> designationShas { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.emFacultyApplication> emFacultyApplications { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.shaFacultyApplication> shaFacultyApplications { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.rollAnik> rollAniks { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.namesAnik> namesAniks { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.appliAnik> appliAniks { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.nameArsad> nameArsads { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.nameImrul> nameImruls { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.appliImrul> appliImruls { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.appliArsad> appliArsads { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.nameMahin> nameMahins { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.rollMahin> rollMahins { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.appliMahin> appliMahins { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.indexAppliAnik> indexAppliAniks { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.indexAppliMahin> indexAppliMahins { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.indexAppliArsad> indexAppliArsads { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.indexAppliImrul> indexAppliImruls { get; set; }


        //public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.RoleViewModel> RoleViewModels { get; set; }




    }
}