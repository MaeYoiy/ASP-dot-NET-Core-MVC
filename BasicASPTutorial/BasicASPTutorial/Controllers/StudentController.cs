using BasicASPTutorial.Data;
using BasicASPTutorial.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicASPTutorial.Controllers
{
    //Constructor
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext _db;

        //Constructor
        //Dependency Injection
        public StudentController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //รูปแบบที่ 1
            Student s1 = new Student();
            //รูปแบบที่ 2  (นิยมที่สุด)
            //var s2 = new Student();
            //รูปแบบที่ 3
            //Student s3 = new();

            s1.Id = 1;
            s1.Name = "Mink";
            s1.Score = 100;

            var s2 = new Student();
            s2.Id = 2;
            s2.Name = "Watchapol";
            s2.Score = 40;

            Student s3 = new();
            s3.Id = 3;
            s3.Name = "Yeen";
            s3.Score = 90;

            List<Student> allStudent = new List<Student>();
            allStudent.Add(s1);
            allStudent.Add(s2);
            allStudent.Add(s3);

            return View(allStudent);

        }

        //GET METHOD รับหน้าที่ในการแสดงผล
        public IActionResult Create()
        {
            return View();
        }

        //POST METHOD รับหน้าที่ในการข้อมูลจาก View มาใช้ใน Controller

        
    }
}
