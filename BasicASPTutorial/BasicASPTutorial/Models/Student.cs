using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BasicASPTutorial.Models
{
    //ชื่อ Model (Student) จะเป็นชื่อตาราง
    //ชื่อ Propoties จะเป็นชื่อคอลัมที่อยู่ในตาราง เช่น Id, Name, Score
    public class Student
    {
        //Create Model
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("ชื่อนักเรียน")]
        public string Name { get; set; }

        [DisplayName("คะแนนสอบ")]
        [Range(0,100)]
        public int Score { get; set; }
    }
}
