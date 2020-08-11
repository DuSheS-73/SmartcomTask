using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SmartcomTask.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            ISession session = services.GetRequiredService<HttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ID = Guid.Parse(cartId) };
            
        }
    }
}
