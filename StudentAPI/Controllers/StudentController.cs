using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace App_2021_03_26.Controllers
{
    [ApiController]
    [Route("student")]
    public class StudentController : Controller
    {
        public static List<Student> studentList = new();
        public StudentController() {
            studentList.Add(new Student {Name = "Hai"});
            studentList.Add(new Student {Name = "Vinh"});
        }
        [HttpGet]
        public List<Student> Get() {
            return studentList;
        }
        [HttpPost]
        public List<Student> Post(Student student) {
            studentList.Add(student);
            return studentList;
        }
        [HttpDelete]
        public List<Student> Delete(int index) {
            studentList.RemoveAt(index);
            return studentList;
        }
    }
}