using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace template_identifier.Models.DTO
{
    public class SampleModelDTO
    {  
        public class StudentDTO
        {
            public int StudentID { get; set; }
            public string StudentName { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public byte[]  Photo { get; set; }
            public decimal Height { get; set; }
            public float Weight { get; set; }
                
            public Grade Grade { get; set; }
        }
        
        public class GradeDTO
        {
            public int GradeId { get; set; }
            public string GradeName { get; set; }
            public string Section { get; set; }
    
            public ICollection<Student> Students { get; set; }
        }
    }
}