using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Gurpinder_Windows.Data;
using System;
using System.Linq;

namespace Gurpinder_Windows.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Gurpinder_WindowsContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Gurpinder_WindowsContext>>()))
            {
                // Look for any movies.
                if (context.Window.Any())
                {
                    return;   // DB has been seeded
                }

                context.Window.AddRange(
                    new Window
                    {
                        Name = "Double-hung",
                        Style = "Clasic and Versatile",
                        Material = "Vinyl, wood, or fiberglass",
                        Size = 10,
                        Price = 200.00M,
                        Rating = 4
                    },

                    new Window
                    {
                        Name = " Casement",
                        Style = "Hinged on one side",
                        Material = "Vinyl, wood, or aluminum",
                        Size = 8,
                        Price = 299.99M,
                        Rating = 4.4M
                    },

                    new Window
                    {
                        Name = "Sliding",
                        Style = "Horizontal sliding windows",
                        Material = "Aluminum, or fiberglass",
                        Size = 7,
                        Price = 299.99M,
                        Rating = 4.1M
                    },

                    new Window
                    {
                        Name = "Awning",
                        Style = " Hinged at the top",
                        Material = "Vinyl, wood, or aluminum",
                        Size = 8.5M,
                        Price = 400,
                        Rating = 4.3M
                    },

                    new Window
                    {
                        Name = "Picture ",
                        Style = "Large, fixed windows",
                        Material = " Wood or fiberglass",
                        Size = 9,
                        Price = 500,
                        Rating = 4
                    }
                );
                context.SaveChanges();
            }
        }
    }
}