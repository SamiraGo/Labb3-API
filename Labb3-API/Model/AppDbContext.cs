using Labb3_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb3_API.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<PersonHobby> PersonHobbies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Data

            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 1, FirstName = "Samira", LastName = "Ekberg", PhoneNumber = "0738041775" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 2, FirstName = "Nick", LastName = "Larsson", PhoneNumber = "07226566888" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 3, FirstName = "Ingrid", LastName = "Johansson", PhoneNumber = "0703698366" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 4, FirstName = "Magnus", LastName = "Lund", PhoneNumber = "0737659489" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 5, FirstName = "Nelly", LastName = "Stenberg", PhoneNumber = "0718763244" });

            modelBuilder.Entity<Hobby>().HasData(new Hobby { HobbyId = 1, Title = "Painting", Description = " the practice of applying paint, pigment, color or other medium to a solid surface" });
            modelBuilder.Entity<Hobby>().HasData(new Hobby { HobbyId = 2, Title = "Cooking", Description = "the art, science and craft of using heat to prepare food for consumption" });
            modelBuilder.Entity<Hobby>().HasData(new Hobby { HobbyId = 3, Title = "Training", Description = "develop specific motor skills, agility, strength or physical fitness" });
            modelBuilder.Entity<Hobby>().HasData(new Hobby { HobbyId = 4, Title = "Music", Description = " the art of arranging sound" });

            modelBuilder.Entity<Link>().HasData(new Link { LinkId = 1, HobbyId = 1, PersonId = 4, URL = "https://en.wikipedia.org/wiki/Painting" });
            modelBuilder.Entity<Link>().HasData(new Link { LinkId = 2, HobbyId = 2, PersonId = 3, URL = "https://en.wikipedia.org/wiki/Cooking" });
            modelBuilder.Entity<Link>().HasData(new Link { LinkId = 3, HobbyId = 3, PersonId = 1, URL = "https://en.wikipedia.org/wiki/Training" });
            modelBuilder.Entity<Link>().HasData(new Link { LinkId = 4, HobbyId = 4, PersonId = 5, URL = "https://en.wikipedia.org/wiki/Music" });
            modelBuilder.Entity<Link>().HasData(new Link { LinkId = 5, HobbyId = 4, PersonId = 2, URL = "https://www.newworldencyclopedia.org/entry/Music" });

            modelBuilder.Entity<PersonHobby>().HasData(new PersonHobby { PersonHobbyId = 1, HobbyId = 1, PersonId = 4 });
            modelBuilder.Entity<PersonHobby>().HasData(new PersonHobby { PersonHobbyId = 2, HobbyId = 2, PersonId = 3 });
            modelBuilder.Entity<PersonHobby>().HasData(new PersonHobby { PersonHobbyId = 3, HobbyId = 3, PersonId = 1 });
            modelBuilder.Entity<PersonHobby>().HasData(new PersonHobby { PersonHobbyId = 4, HobbyId = 4, PersonId = 5 });
            modelBuilder.Entity<PersonHobby>().HasData(new PersonHobby { PersonHobbyId = 5, HobbyId = 4, PersonId = 2 });
            modelBuilder.Entity<PersonHobby>().HasData(new PersonHobby { PersonHobbyId = 6, HobbyId = 3, PersonId = 2 });
            modelBuilder.Entity<PersonHobby>().HasData(new PersonHobby { PersonHobbyId = 7, HobbyId = 2, PersonId = 1 });
        }

    }
}
