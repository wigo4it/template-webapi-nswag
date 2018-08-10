using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace template_identifier.Models
{
    public class SampleEfModel 
    {  
        public class Student
        {
            public int StudentID { get; set; }
            public string StudentName { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public byte[]  Photo { get; set; }
            public decimal Height { get; set; }
            public float Weight { get; set; }
                
            public Grade Grade { get; set; }
        }
        public class Grade
        {
            public int GradeId { get; set; }
            public string GradeName { get; set; }
            public string Section { get; set; }
    
            public ICollection<Student> Students { get; set; }
        }
    }
}