using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETrade.Entities;

namespace ETrade.DataAccess.Concrete.EFCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new DataContext();
            if(context.Database.GetPendingMigrations().Count() == 0)
            {
                if(context.Categories.Count() == 0)
                {
                    context.AddRange(Categories);
                }

                if (context.Products.Count() == 0)
                {
                    context.AddRange(Products);
                    context.AddRange(ProductCategory);

                }
            }
        }

        private static Category[] Categories =
        {
            new Category(){Name = "Telefon"},
            new Category(){Name = "Bilgisayar"},
            new Category(){Name = "Elektronik"},
        };

        private static Product[] Products =
        {
            new Product(){Name = "Samsung Note 2",Price=15000,
                Images={ 
                    new Image(){ImageUrl="1.jpg"},
                    new Image(){ImageUrl="2.jpg"},
                    new Image(){ImageUrl="3.jpg"},
                    new Image(){ImageUrl="4.jpg"} 
                },Description ="güzel telefon"  },

             new Product(){Name = "Samsung Note 3",Price=17000,
                Images={
                    new Image(){ImageUrl="1.jpg"},
                    new Image(){ImageUrl="2.jpg"},
                    new Image(){ImageUrl="3.jpg"},
                    new Image(){ImageUrl="4.jpg"}
                },Description ="güzel telefon"  },

             new Product(){Name = "Samsung Note 4",Price=19000,
                Images={
                    new Image(){ImageUrl="1.jpg"},
                    new Image(){ImageUrl="2.jpg"},
                    new Image(){ImageUrl="3.jpg"},
                    new Image(){ImageUrl="4.jpg"}
                },Description ="güzel telefon"  },

             new Product(){Name = "Samsung Note 5",Price=21000,
                Images={
                    new Image(){ImageUrl="1.jpg"},
                    new Image(){ImageUrl="2.jpg"},
                    new Image(){ImageUrl="3.jpg"},
                    new Image(){ImageUrl="4.jpg"}
                },Description ="güzel telefon"  },

              new Product(){Name = "Samsung Note 6",Price=22000,
                Images={
                    new Image(){ImageUrl="1.jpg"},
                    new Image(){ImageUrl="2.jpg"},
                    new Image(){ImageUrl="3.jpg"},
                    new Image(){ImageUrl="4.jpg"}
                },Description ="güzel telefon"  },

               new Product(){Name = "Samsung Note 7",Price=23000,
                Images={
                    new Image(){ImageUrl="1.jpg"},
                    new Image(){ImageUrl="2.jpg"},
                    new Image(){ImageUrl="3.jpg"},
                    new Image(){ImageUrl="4.jpg"}
                },Description ="güzel telefon"  },

        };

        private static ProductCategory[] ProductCategory =
        {
            new ProductCategory(){Product=Products[0],Category = Categories[0]},
            new ProductCategory(){Product=Products[1],Category = Categories[0]},
            new ProductCategory(){Product=Products[2],Category = Categories[2]},
            new ProductCategory(){Product=Products[3],Category = Categories[0]},
            new ProductCategory(){Product=Products[4],Category = Categories[2]},
            new ProductCategory(){Product=Products[5],Category = Categories[0]},
        };
    }
}
