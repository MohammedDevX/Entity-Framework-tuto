namespace learn_entity_framework.Models
{
    public class ClientItem
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
