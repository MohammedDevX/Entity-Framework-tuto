namespace learn_entity_framework.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Here we say that we have a many relation with Item table, thats meen one Category ca be related with many
        // Items
        public List<Item>? Item { get; set; }
    }
}
