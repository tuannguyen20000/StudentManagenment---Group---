//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Student_Management.StudentManagement
{
    using System;
    using System.Collections.Generic;
    
    public partial class Faculty
    {
       
        public Faculty()
        {
            this.Students = new HashSet<Student>();
        }
    
        public string Faculty_ID { get; set; }
        public string Faculty_Name { get; set; }
    
        public virtual ICollection<Student> Students { get; set; }
    }
}