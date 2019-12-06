using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management.StudentManagement
{
    class LogicLayer
    {
        public Student[] GetStudents()
        {
            var db = new StudentEntities2();
            return db.Students.ToArray();
        }

        public Student GetStudent(int id)
        {
            var db = new StudentEntities2();
            return db.Students.Find(id);
        }

        public void CreateStudent(string code, string name, DateTime birthday, int class_id, string email, string hometown)
        {
            var student = new Student();
            student.Code = code;
            student.Name = name;
            student.Birthday = birthday;
            student.Class_id = class_id;
            student.Email = email;
            student.Home_Town = hometown;

            var db = new StudentEntities2();
            db.Students.Add(student);
            db.SaveChanges();
        }

        public void UpdateStudent(int id, string name, DateTime birthday, int class_id, string email, string hometown)
        {
            var db = new StudentEntities2();
            var student = db.Students.Find(id);

            student.Name = name;
            student.Birthday = birthday;
            student.Class_id = class_id;
            student.Email = email;
            student.Home_Town = hometown;

            db.Entry(student).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var db = new StudentEntities2();
            var student = db.Students.Find(id);

            db.Students.Remove(student);
            db.SaveChanges();
        }
        public Class[] GetClasses()
        {
            var db = new StudentEntities2();
            return db.Classes.ToArray();
        }
    }
}

