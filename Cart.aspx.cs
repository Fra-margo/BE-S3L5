using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Esercizio_be_s3l5
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCartItems();
            }
        }

        protected void ReturnToHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HomePage.aspx");
        }

        protected void ClearCart_Click(object sender, EventArgs e)
        {
            ClearCart();
            BindCartItems();
        }

        protected void RemoveFromCart_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            int productIdToRemove;

            if (int.TryParse(button.CommandArgument, out productIdToRemove))
            {
                RemoveProductFromCart(productIdToRemove);

                BindCartItems();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "InvalidArgument", "alert('Errore: Argomento del comando non valido.');", true);
            }
        }

        private void RemoveProductFromCart(int productId)
        {
            if (Request.Cookies["cart"] != null)
            {
                HttpCookie cookie = Request.Cookies["cart"];
                cookie.Values.Remove(productId.ToString());
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
        }

        private void BindCartItems()
        {
            var cartItems = GetCartItems();
            if (cartItems.Any())
            {
                CartRepeater.DataSource = cartItems;
                CartRepeater.DataBind();

                decimal total = cartItems.Sum(item => item.Price * item.Quantity);

                TotalLabel.Text = $"Totale: € {total}";
            }
            else
            {
                CartRepeater.Visible = false;
                EmptyCartMessage.Visible = true;
                TotalLabel.Text = "Totale: € 0";
            }
        }

        public List<Product> GetCartItems()
        {
            var cartItems = new List<Product>();
            if (Request.Cookies["cart"] != null)
            {
                HttpCookie cookie = Request.Cookies["cart"];
                foreach (string productId in cookie.Values)
                {
                    if (!string.IsNullOrEmpty(productId))
                    {
                        if (int.TryParse(productId, out int parsedProductId))
                        {
                            var product = Products.GetAllProducts().Find(p => p.Id == parsedProductId);
                            if (product != null)
                            {
                                int quantity;
                                if (int.TryParse(cookie.Values[productId], out quantity))
                                {
                                    product.Quantity = quantity;
                                }
                                else
                                {
                                    Console.WriteLine("Errore: Impossibile convertire la quantità del prodotto.");
                                }

                                cartItems.Add(product);
                            }
                            else
                            {
                                Console.WriteLine("Errore: Nessun prodotto trovato con l'ID specificato.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Errore: Impossibile convertire productId in un numero intero.");
                        }
                    }
                }
            }
            return cartItems;
        }

        private void ClearCart()
        {
            if (Request.Cookies["cart"] != null)
            {
                HttpCookie cookie = Request.Cookies["cart"];
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
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