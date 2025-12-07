using System.ComponentModel.DataAnnotations.Schema;

namespace learn_entity_framework.Models
{
    // Model file : To create tables EN see every model class and transform him into tables in database 
    public class Item
    {
        // Here we define our colums
        public int Id { get; set; } // Id is by default an primary key or you can add annotaion [Key]
        public string ? Nom { get; set; }
        public double Price { get; set; }
        public SerialNumber SerialNumber { get; set; }

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}
