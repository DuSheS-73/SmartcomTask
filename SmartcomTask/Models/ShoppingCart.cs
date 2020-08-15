using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartcomTask.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartcomTask.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext context;
        public ShoppingCart(AppDbContext context)
        {
            this.context = context;
        }


        public Guid ID { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }



        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ID = Guid.Parse(cartId) };
            
        }


        public void AddToCart(Item item, int amount)
        {
            var shoppingCartItem = context.ShoppingCartItems.FirstOrDefault(c => c.Item.ID == item.ID && c.ShoppingCartID == ID);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartID = ID,
                    Item = item,
                    Amount = amount
                };

                context.Entry(shoppingCartItem).State = EntityState.Added;
            }
            else
            {
                shoppingCartItem.Amount++;
            }
        }


        public int RemoveFromCart(Item item)
        {
            var shoppingCartItem = context.ShoppingCartItems.FirstOrDefault(c => c.Item.ID == item.ID && c.ShoppingCartID == this.ID);

            //int localAmount = 0;

            if(shoppingCartItem != null)
            {
                if(shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount -= 1;
                }
                else
                {
                    context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            return shoppingCartItem.Amount;
        }


        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return this.ShoppingCartItems ?? (this.ShoppingCartItems = context.ShoppingCartItems.Where(c => c.ShoppingCartID == this.ID)
                                                                                                .Include(s => s.Item)
                                                                                                .ToList());
        }


        public void ClearCart()
        {
            var cartItems = context.ShoppingCartItems.Where(c => c.ShoppingCartID == this.ID);

            context.ShoppingCartItems.RemoveRange(cartItems);
            context.SaveChanges();
        }


        public decimal GetShoppingCartTotal()
        {
            var total = context.ShoppingCartItems.Where(c => c.ID == this.ID).Select(s => s.Item.Price * s.Amount).Sum();
            return total;
        }

    }
}
