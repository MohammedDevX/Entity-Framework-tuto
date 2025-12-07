using learn_entity_framework.Models;
using learn_entity_framework.ViewModels;

namespace learn_entity_framework.Mapper
{
    public class ItemMP
    {
        public static Item AffectItemVMToItem(ItemVM itemvm)
        {
            Item item = new Item();
            item.Nom = itemvm.Nom;
            item.Price = itemvm.Price;
            item.CategoryId = itemvm.Category;
            return item;
        }

        public static Item AffectItemVMToItem(ItemVM itemvm, int id)
        {
            Item item = new Item();
            item.Id = id;
            item.Nom = itemvm.Nom;
            item.Price = itemvm.Price;
            item.CategoryId = itemvm.Category;
            return item;
        }
    }
}
