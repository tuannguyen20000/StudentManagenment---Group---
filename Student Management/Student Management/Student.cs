//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Student_Management
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public System.DateTime Birthday { get; set; }
        public int Class_id { get; set; }
        public string Email { get; set; }
        public string Home_Town { get; set; }
    
        public virtual Class Class { get; set; }
    }
}