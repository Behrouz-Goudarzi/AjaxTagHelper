using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AjaxTagHelper.Models
{
    public class AjaxTagheplerContext : DbContext
    {
        public AjaxTagheplerContext(DbContextOptions<AjaxTagheplerContext> options)
            : base(options ) { 

        }

        public DbSet<PersonModel> Person { get; set; }

    }
    public class PersonModel                                    
    {
        public int  Id { get; set; }

        public string Name { get; set; }

        public string Family { get; set; }

        public string Email { get; set; }

        public string FullName => Name + " " + Family;
    }
}
