using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectYK.Models
{
    public class DBClass: DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<TypeOfEvent> Types { get; set; }

        public DBClass(DbContextOptions<DBClass> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении к классу
        }
    }
}
