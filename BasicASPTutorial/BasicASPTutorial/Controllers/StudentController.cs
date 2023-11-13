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

        //-------------------- Show (Read) --------------------
        public IActionResult Index()
        {
            //รูปแบบที่ 1
            //Student s1 = new Student();
            //รูปแบบที่ 2  (นิยมที่สุด)
            //var s2 = new Student();
            //รูปแบบที่ 3
            //Student s3 = new();

            //s1.Id = 1;
            //s1.Name = "Mink";
            //s1.Score = 100;

            //var s2 = new Student();
            //s2.Id = 2;
            //s2.Name = "Watchapol";
            //s2.Score = 40;

            //Student s3 = new();
            //s3.Id = 3;
            //s3.Name = "Yeen";
            //s3.Score = 90;

            //List<Student> allStudent = new List<Student>();
            //allStudent.Add(s1);
            //allStudent.Add(s2);
            //allStudent.Add(s3);

            //IEnumerable เพื่อเป็นกลุ่มของ Object จาก Model Student
            //allStudent เก็บกลุ่มของ Object หรือกลุ่มของข้อมูลที่เก็บมาจากฐานข้อมูลด้วยตัวแทน Students
            IEnumerable<Student> allStudent = _db.Students;

            return View(allStudent);

        }

        //-------------------- Create --------------------
        //GET METHOD รับหน้าที่ในการแสดงผลหน้าเว็บเพจของ View Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //POST METHOD รับหน้าที่ในการรับข้อมูลจาก View มาใช้ใน Controller
        //เมื่อมีการใส่ข้อมูล จะทำการเรียกใช้ Action ตัวนี้
        public IActionResult Create(Student obj)
        {
            //ถ้ามีการตรวจสอบข้อมูลถูกต้องแล้ว (อย่าง ห้าม null) ให้บันทึกได้
            if (ModelState.IsValid)
            {
                //add ค่า Name และ Score ที่ได้รับมาจากหน้า View Create
                _db.Students.Add(obj);
                //บันทึก
                _db.SaveChanges();
                //ทำการ redirect คือเมื่อกดปุ่ม "บ้นทึก" แล้ว ให้ไปหน้า View Index
                return RedirectToAction("Index");
            }
            //ถ้าไม่ ก็ยังคงค่า Object นั้นไว้อยู่
            return View(obj);
        }

        //-------------------- Update --------------------
        // "?" คือ Optional Parameter
        public IActionResult Edit(int? id)
        {
            if (id==null || id == 0)
            {
                return NotFound();
            }
            //ค้นหาข้อมูล
            var obj = _db.Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Edit(Student obj)
        {
            //ถ้ามีการตรวจสอบข้อมูลถูกต้องแล้ว (อย่าง ห้าม null) ให้บันทึกได้
            if (ModelState.IsValid)
            {
                //Update ค่า Name และ Score ที่ได้รับมาจากหน้า View Edit
                _db.Students.Update(obj);
                //บันทึก
                _db.SaveChanges();
                //ทำการ redirect คือเมื่อกดปุ่ม "บ้นทึก" แล้ว ให้ไปหน้า View Index
                return RedirectToAction("Index");
            }
            //ถ้าไม่ ก็ยังคงค่า Object นั้นไว้อยู่
            return View(obj);
        }

        //-------------------- Delete --------------------
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //ค้นหาข้อมูล
            var obj = _db.Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Students.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
