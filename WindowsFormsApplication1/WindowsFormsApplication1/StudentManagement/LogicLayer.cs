using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.StudentManagement
{
    public class LogicLayer
    {
        public Student[] GetStudents()
        {
            var db = new MyDatabaseEntities();
            return db.Student.ToArray();
        }
        public Student GetStudent(int id)
        {
            var db = new MyDatabaseEntities();
            return db.Student.Find(id);
        }
        public void CreateStudent(string code , string name , DateTime birthday , int class_id)
        {
            var newStudent = new Student();
            newStudent.Code = code;
            newStudent.Name = name;
            newStudent.Birthday = birthday;
            newStudent.Class_id = class_id;

            var db = new MyDatabaseEntities();
            db.Student.Add(newStudent);
            db.SaveChanges();
        }
        public void UpdateStudent(int id , string name , DateTime birthday , int class_id)
        {
            var db = new MyDatabaseEntities();
            var Student = db.Student.Find(id);

            Student.Name = name;
            Student.Birthday = birthday;
            Student.Class_id = class_id;

            db.Entry(Student).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteStudent(int id)
        {
            var db = new MyDatabaseEntities();
            var student = db.Student.Find(id);

            db.Student.Remove(student);
            db.SaveChanges();
        }
        public Class[] GetClasses()
        {
            var db = new MyDatabaseEntities();
            return db.Class.ToArray();
        }
    }
}
