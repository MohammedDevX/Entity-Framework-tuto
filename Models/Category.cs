namespace learn_entity_framework.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Item? Item { get; set; }
    }
}
