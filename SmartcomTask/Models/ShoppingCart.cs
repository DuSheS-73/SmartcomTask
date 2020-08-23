using System.Collections.Generic;
using System.Linq;

namespace SmartcomTask.Models
{
    public class ShoppingCart
    {
        private List<ShoppingCartItem> ShoppingCartItems = new List<ShoppingCartItem>();
        public IEnumerable<ShoppingCartItem> AllItems { get { return ShoppingCartItems; } }



        public void AddToCart(Item item, int amount)
        {
            ShoppingCartItem cartItem = ShoppingCartItems.FirstOrDefault(c => c.Item.ID == item.ID);

            if(cartItem == null)
            {
                ShoppingCartItems.Add(new ShoppingCartItem { Item = item, Amount = amount });
            }
            else
            {
                cartItem.Amount += amount;
            }
        }


        public void RemoveFromCart(Item item)
        {
            ShoppingCartItem cartItem = ShoppingCartItems.FirstOrDefault(c => c.Item.ID == item.ID);

            if(cartItem != null)
            {
                if(cartItem.Amount > 1)
                {
                    cartItem.Amount -= 1;
                }
                else
                {
                    ShoppingCartItems.Remove(cartItem);
                }
            }
        }


        public void ClearCart()
        {
            ShoppingCartItems.Clear();
        }


        public decimal GetShoppingCartTotal()
        {
            return ShoppingCartItems.Select(c => c.Item.Price * c.Amount).Sum();
        }

    }
}