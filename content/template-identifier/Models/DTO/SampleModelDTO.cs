using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.OData.Edm;
using Microsoft.AspNet.OData.Builder;

namespace template_identifier.Models.DTO
{
    /// <summary>
    /// This is a test model, it is part of the template in order to get setup quickly.
    /// You can safely remove this test model together with the unit tests.
    /// 
    /// Implement your own EdmModel
    /// 
    /// Book, Press will be served as Entity types
    /// Address will be served as a Complex type.
    /// Category will be served as an Enum type.
    /// </summary>
    public class SampleModelDTO 
    {  
        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<BookDTO>("SampleEfOData");
            builder.EntitySet<PressDTO>("Presses");
            return builder.GetEdmModel();
        }

        public class BookDTO
        {
            public int Id { get; set; }
            public string ISBN { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public decimal Price { get; set; }
            public string PriceDisplay { get; set; }
            public AddressDTO Location { get; set; }
            public PressDTO Press { get; set; }
            public DateTime LastQuery {get;set;}
        }

        // Press
        public class PressDTO
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public CategoryDTO Category { get; set; }
        }

        // Category
        public enum CategoryDTO
        {
            Book,
            Magazine,
            EBook
        }

        // Address
        public class AddressDTO
        {
            public string City { get; set; }
            public string Street { get; set; }
        }

        public class StudentDTO
        {
            public int StudentID { get; set; }
            public string StudentName { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public byte[]  Photo { get; set; }
            public decimal Height { get; set; }
            public float Weight { get; set; }
                
            public GradeDTO Grade { get; set; }
        }

        public class GradeDTO
        {
            public int GradeId { get; set; }
            public string GradeName { get; set; }
            public string Section { get; set; }
    
            public ICollection<StudentDTO> Students { get; set; }
        }
    }
}