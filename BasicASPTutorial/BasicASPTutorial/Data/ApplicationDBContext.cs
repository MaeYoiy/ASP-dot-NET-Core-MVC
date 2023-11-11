using BasicASPTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicASPTutorial.Data
{
    //ApplicationDBContext สืบทอดคุณสมบัติ DbContext
    public class ApplicationDBContext:DbContext
    {
        //Constructor
        public ApplicationDBContext (DbContextOptions<ApplicationDBContext> options) :base(options){ 

        }

        //เข้าถึงฐานข้อมูล Student ด้วย Students ตัวด้านล่างนี้
        public DbSet<Student> Students { get; set; }
    }
}
