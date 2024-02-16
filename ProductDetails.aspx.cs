using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Esercizio_be_s3l5
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ReturnToHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HomePage.aspx");
        }

        protected void AddToCart_Click(object sender, EventArgs e)
        {
            var productId = int.Parse(Request.QueryString["id"]);
            var product = Products.GetAllProducts().Find(p => p.Id == productId);
            AddProductToCart(product);
            Response.Redirect("Cart.aspx");
        }

        private void AddProductToCart(Product product)
        {
            if (Request.Cookies["cart"] != null)
            {
                HttpCookie cookie = Request.Cookies["cart"];

                if (cookie.Values.AllKeys.Contains(product.Id.ToString()))
                {
                    int quantity = int.Parse(cookie.Values[product.Id.ToString()]);
                    quantity++;
                    cookie.Values[product.Id.ToString()] = quantity.ToString();
                }
                else
                {
                    cookie.Values[product.Id.ToString()] = "1";
                }

                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);
            }
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string ImageUrl { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }
            public int Quantity { get; set; }
        }

        public static class Products
        {
            public static List<Product> GetAllProducts()
            {                
                return new List<Product>
                {
                    new Product { Id = 1, Name = "S-24", ImageUrl = "https://img.tuttoandroid.net/wp-content/uploads/2023/09/s24-render-5k-1.jpg", Price = 989.00m, Description = "Ultimo modello della casa Samsung, disponibile in diverse colorazioni" },
                    new Product { Id = 2, Name = "Iphone 15", ImageUrl = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-15-pro-finish-select-202309-6-1inch_GEO_EMEA?wid=5120&hei=2880&fmt=p-jpg&qlt=80&.v=1693009279096", Price = 829.00m, Description = "Ultimo modello della casa Apple. Disponibile anche in versione Pro e Pro Max" },
                    new Product { Id = 3, Name = "Redmi Note 13 Pro", ImageUrl = "https://i.ebayimg.com/images/g/H2EAAOSwIMZlLL6g/s-l1600.jpg", Price = 349.99m, Description = "Ultimo modello Xiaomi, disponibile in diverse colorazioni" },
                    new Product { Id = 4, Name = "Honor 90", ImageUrl = "https://www.mytrendyphone.it/images/Honor-90-Lite-256GB-Titanium-Silver-6936520825127-24072023-01-p.webp", Price = 399.90m, Description = "Ultimo modello Honor" },
                    new Product { Id = 5, Name = "P60 Pro", ImageUrl = "https://i.ebayimg.com/images/g/Mt8AAOSwRwpkHRll/s-l1200.jpg", Price = 999.99m, Description = "Ultimo modello casa Huawei" },
                    new Product { Id = 6, Name = "Xperia 1 V", ImageUrl = "https://files.refurbed.com/ii/sony-experia-1-v-1692016302.jpg?t=fitdesign&h=600&w=800", Price = 1226.00m, Description = "Ultimo modello Sony" }

                };
            }
        }
    }
}