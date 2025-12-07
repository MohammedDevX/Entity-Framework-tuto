using learn_entity_framework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace learn_entity_framework.Data
    // Here we are going to use the code first approach, who help us to transfore our c# classes into tables in database

    // The class MyAppContext in the Data folder, help us to manipulate the data entire database
{
    // This class extend from DbContext class, wich help us to work with entity frameworks and transforme DbContext
    // in to tables in database
    public class MyAppContext : DbContext
    {
        // We create a constructor who have DbContextOptions as param with the type of the DbContext wish is the name
        // of the class, this param accepte informations for the database : the name of the database wish type
        // of database going to work with : (mysql, sql server etc ..) and we call the mother constructor,
        // and we pass theme thos informations
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options) { }

        // DbSet property : this property help EF to know Items is the the table he should crate in the database 
        // and help us to mapp the rows from the table to the entity class 
        public DbSet<Item> Items { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }
        public DbSet<Category> Category { get; set; }

        // N.B : DbContext in EN meen the database, and DbSet in EN meen the table
        // N.B : To migrate the database you must, run thos 2 commandes : 
        // To create a database :
        // 1) Go to view/server explorer 
        // 2) Create new sql server
        // 3) Enter the server name, and choise the type of auth and the name of database
        // 4) Add-Migration "name of migration"
        // 5) Update-Database

        // N.B : In database approache the models and the DbContext are generated auto

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Nom = "Keyboard", Price = 150 }
            );

            modelBuilder.Entity<SerialNumber>().HasData(
                new SerialNumber { Id = 1, Name = "Razor102", ItemId = 1 }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronique" },
                new Category { Id = 2, Name="clothes" }
            );
        }
    }
}
