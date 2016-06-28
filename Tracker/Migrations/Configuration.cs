namespace Tracker.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Tracker.Models.TrackerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Tracker.Models.TrackerContext context)
        {
            context.PetOwners.AddOrUpdate(
                p => p.Id,
                new PetOwner { Id = 1, FirstName = "Andreas", LastName = "Dro", Email = "andreas@mail.com" },
                new PetOwner { Id = 2, FirstName = "Vivi", LastName = "Kol", Email = "vivi@mail.com" },
                new PetOwner { Id = 3, FirstName = "Nikos", LastName = "Dra", Email = "nikos@mail.com" }
              );
            context.Pets.AddOrUpdate(
                  p => p.Id,
                  new Pet { Id = 1, Name = "Hra", DateOfBirth = Convert.ToDateTime("01/08/2008"), PetOwnerId = 1 },
                  new Pet { Id = 2, Name = "Aris", DateOfBirth = Convert.ToDateTime("01/08/2009"), PetOwnerId = 2 },
                  new Pet { Id = 3, Name = "Dias", DateOfBirth = Convert.ToDateTime("01/08/2008"), PetOwnerId = 2 }
                );
            context.PetWalkers.AddOrUpdate(
                 p => p.Id,
                 new PetWalker { Id = 1, FirstName = "Walker1", LastName = "Dro", Email = "walker1@mail.com" },
                 new PetWalker { Id = 2, FirstName = "Walker2", LastName = "Kol", Email = "walker2@mail.com" },
                 new PetWalker { Id = 3, FirstName = "Walker3", LastName = "Dra", Email = "walker3@mail.com" }
               );
            context.Approvals.AddOrUpdate(
                 p => p.Id,
                 new Approval { Id = 1, PetOwnerId = 1, PetWalkerId = 1 },
                 new Approval { Id = 2, PetOwnerId = 2, PetWalkerId = 2 },
                 new Approval { Id = 3, PetOwnerId = 1, PetWalkerId = 3 }
               );
        }
    }
}
