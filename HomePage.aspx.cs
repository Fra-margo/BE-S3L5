using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Esercizio_be_s3l5
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["cart"] == null)
                {
                    HttpCookie cookie = new HttpCookie("cart");
                    cookie.Expires = DateTime.Now.AddDays(1);
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
                    new Product { Id = 3, Name = "Redmi Note 13 Pro", ImageUrl = "https://www.notebookcheck.it/uploads/tx_nbc2/Xiaomi_Redmi_Note_13_Pro_5G.jpg", Price = 349.99m, Description = "Ultimo modello Xiaomi, disponibile in diverse colorazioni" },
                    new Product { Id = 4, Name = "Honor 90", ImageUrl = "https://static.digitecgalaxus.ch/Files/7/5/1/1/6/9/8/2/csm_Honor29_0a9a017e1f.jpg", Price = 399.90m, Description = "Ultimo modello Honor" },
                    new Product { Id = 5, Name = "P60 Pro", ImageUrl = "https://img.tuttoandroid.net/wp-content/uploads/2023/03/HUAWEI-P60-Pro-TAG.jpg", Price = 999.99m, Description = "Ultimo modello casa Huawei" },
                    new Product { Id = 6, Name = "Xperia 1 V", ImageUrl = "https://files.refurbed.com/pi/sony-experia-1-v-1691660351.jpg", Price = 1226.00m, Description = "Ultimo modello Sony" }
                };
            }
        }
    }
}
