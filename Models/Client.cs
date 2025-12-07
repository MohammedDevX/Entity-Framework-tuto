namespace learn_entity_framework.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<ClientItem> ClientItem { get; set; } = new();
    }
}
