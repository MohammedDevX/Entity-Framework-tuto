using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace learn_entity_framework.Models
{
    // Here we are going to made a one to one relation betweene SerialNumbre and Item
    // N.B : Whene we have one to one relation, we made the FK in the table who depend to the other table, for ex 
    // in this ex we can have an item with out Serial, but we cant have Serial with out item, so we are going 
    // to made the FK in this table
    public class SerialNumber
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        // This is the column who are going to store the Id of the item
        public int ItemId { get; set; }

        // Here we made an FK and call the ItemId column
        [ForeignKey("ItemId")]
        public Item Item { get; set; }
    }
}
