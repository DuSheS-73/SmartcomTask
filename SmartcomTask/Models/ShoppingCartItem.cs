namespace SmartcomTask.Models
{
    public class ShoppingCartItem
    {
        public virtual Item Item { get; set; }

        public int Amount { get; set; }
    }
}
