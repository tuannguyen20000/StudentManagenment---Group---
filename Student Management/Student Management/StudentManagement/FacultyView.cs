using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management.StudentManagement
{
    class FacultyView
    {
        public string Faculty_ID { get; set; }
        public string Faculty_Name { get; set; }
        public int Number_of_Student { get; set; }
        public FacultyView(Faculty faculty)
        {
            this.Faculty_ID = faculty.Faculty_ID;
            this.Faculty_Name = faculty.Faculty_Name;
            this.Number_of_Student = faculty.Students.Count;
        }
    }
}
