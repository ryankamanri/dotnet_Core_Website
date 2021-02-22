using System;
using System.Collections.Generic;
using WebApplication1.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //using (var context = new WebApplication1Context(
            //    serviceProvider.GetRequiredService<DbContextOptions<WebApplication1Context>>()))
            //    {
            //        if (context.File.Any()) { return; }
            //    context.File.AddRange(
            //        new File
            //        {
            //            Name = "Ryan Kamanri",
            //            LastWriteTime = DateTime.Parse("2001-8-8"),
            //            Length= "2019110111",
            //            Description = "null pointer",
            //        });
            //    context.SaveChanges();
            //    }
        }
    }
}
