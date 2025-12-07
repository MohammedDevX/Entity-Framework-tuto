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

        // Here we say that we have a one relation with SerialNumber table
        public SerialNumber SerialNumber { get; set; }

        // Here we have the column who are going to represente the the Id of category
        public int? CategoryId { get; set; }

        // Here we made the FK and call CategoryId, and it reference that we have a one relation with Category 
        // table, thats meen one item have one category 
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        public List<ClientItem> ClientItem { get; set; } = new();
    }
}
