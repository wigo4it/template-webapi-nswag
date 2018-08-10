using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace template_webapi_nswag.Models
{
    public class ValueContext : DbContext
    {
        public ValueContext(DbContextOptions<ValueContext> options)
            : base(options)
        { }

        public DbSet<Value> Values { get; set; }
    }

    public class Value
    {
        [Key]
        public int Id { get; set; }
    
        public string Val { get; set; }

    }
}