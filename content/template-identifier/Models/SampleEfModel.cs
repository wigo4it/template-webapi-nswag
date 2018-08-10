using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace template_identifier.Models
{
    /// <summary>
    /// This is a test model, it is part of the template in order to get setup quickly.
    /// You can safely remove this test model together with the unit tests.
    /// </summary>
    public class SampleEfModel 
    {  
        public class Book
        {
            public int Id { get; set; }
            public string ISBN { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public decimal Price { get; set; }
            public Address Location { get; set; }
            public Press Press { get; set; }
        }

        // Press
        public class Press
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public Category Category { get; set; }
        }

        // Category
        public enum Category
        {
            Book,
            Magazine,
            EBook
        }

        // Address
        public class Address
        {
            public string City { get; set; }
            public string Street { get; set; }
        }
        
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

        public static class DataSource
        {
            private static IList<Book> _books { get; set; }

            public static IList<Book> GetBooks()
            {
                if (_books != null)
                {
                    return _books;
                }

                _books = new List<Book>();

                // book #1
                Book book = new Book
                {
                    Id = 1,
                    ISBN = "978-0-321-87758-1",
                    Title = "Essential C#5.0",
                    Author = "Mark Michaelis",
                    Price = 59.99m,
                    Location = new Address { City = "Redmond", Street = "156TH AVE NE" },
                    Press = new Press
                    {
                        Id = 1,
                        Name = "Addison-Wesley",
                        Category = Category.Book
                    }
                };
                _books.Add(book);

                // book #2
                book = new Book
                {
                    Id = 2,
                    ISBN = "063-6-920-02371-5",
                    Title = "Enterprise Games",
                    Author = "Michael Hugos",
                    Price = 49.99m,
                    Location = new Address { City = "Bellevue", Street = "Main ST" },
                    Press = new Press
                    {
                        Id = 2,
                        Name = "O'Reilly",
                        Category = Category.EBook,
                    }
                };
                _books.Add(book);

                return _books;
            }
        }
    }
}