using learn_entity_framework.Models;
using Microsoft.EntityFrameworkCore;

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

        // N.B : DbContext in EN meen the database, and DbSet in EN meen the table
        // N.B : To migrate the database you must, run thos 2 commandes : 
        // 1) Add-Migration "name of migration"
        // 2) Update-Database

        // N.B : In database approache the models and the DbContext are generated auto
    }
}
