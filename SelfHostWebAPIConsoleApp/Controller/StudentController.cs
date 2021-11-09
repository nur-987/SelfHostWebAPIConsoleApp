using SelfHostWebAPIConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SelfHostWebAPIConsoleApp.Controller
{
    class StudentController:ApiController
    {
        List<Student> stuList = new List<Student>();

        public StudentController()
        {
            stuList.Add(new Student() { id = 1, name = "Mary" });
            stuList.Add(new Student() { id = 2, name = "John" });
            stuList.Add(new Student() { id = 2, name = "John" });
        }

        [HttpGet]
        [Route("studentdetails/{id}")]
        public Student GetSelected(int id)
        {
            return stuList.Where(x => x.id == id).FirstOrDefault();

        }

        [HttpGet]
        [Route("allstudent")]
        public List<Student> GetAll()
        {
            return stuList;
        }

        [HttpPost]
        [Route("addstudent")]
        public List<Student> AddNewStudent(Student newStu)
        {
            stuList.Add(newStu);
            return stuList;
        }

        [HttpPatch]
        [Route("updatestudent")]
        public List<Student> UpdateStudent(int id, string newName)
        {
            Student StuExist = stuList.Where(x => x.id == id).FirstOrDefault();
            if (StuExist == null)
            {
                return null;
            }
            else
            {
                stuList.Remove(StuExist);
                StuExist.id = id;
                StuExist.name = newName;
                stuList.Add(StuExist);

                return stuList;
            }


        }

        [HttpPut]
        [Route("putstudent")]
        public List<Student> PutStudent(Student stu)
        {
            Student StuExist = stuList.Where(x => x.id == stu.id).FirstOrDefault();
            if (StuExist == null)
            {
                return null;
            }
            else
            {
                stuList.Remove(StuExist);
                stuList.Add(stu);
                return stuList;
            }

        }

        [HttpDelete]
        [Route("deletestu")]
        public List<Student> DeleteStudent(Student stu)
        {
            Student StuExist = stuList.Where(x => x.id == stu.id).FirstOrDefault();
            if (StuExist != null)
            {
                stuList.Remove(StuExist);
                return stuList;
            }
            else
            {
                return null;
            }
        }
    }
}
