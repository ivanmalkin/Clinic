using Clinic.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Database
{
    public class Initializer
    {
        public static void SeedIdentityData(IApplicationBuilder applicationBuilder)
        {
            ApplicationIdentityDbContext context = applicationBuilder.ApplicationServices.GetRequiredService<ApplicationIdentityDbContext>();

            if (!context.Roles.Any())
            {
                context.AddRange
                (
                    new IdentityRole
                    {
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole
                    {
                        Name = "Doctor",
                        NormalizedName = "DOCTOR"
                    },
                    new IdentityRole
                    {
                        Name = "Patient",
                        NormalizedName = "PATIENT"
                    }
                );
            }

            context.SaveChanges();
        }

        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            ApplicationDbContext context = applicationBuilder.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Services.Any())
            {
                context.AddRange
                (
                    new Service
                    {
                        Name = "Запись на прием 1",
                        ShortDescription = "Короткое описание 1",
                        LongDescription = "Полное описание 1",
                        Price = 100,
                        ImageUrl = "url",
                        ImageThumbnailUrl = "url",
                        IsPrefferedService = true,
                        Category = Categories["Прием у врача"]
                    },
                    new Service
                    {
                        Name = "Запись на прием 2",
                        ShortDescription = "Короткое описание 2",
                        LongDescription = "Полное описание 2",
                        Price = 200,
                        ImageUrl = "url",
                        ImageThumbnailUrl = "url",
                        IsPrefferedService = true,
                        Category = Categories["Прием у врача"]
                    },
                    new Service
                    {
                        Name = "Запись на прием 3",
                        ShortDescription = "Короткое описание 3",
                        LongDescription = "Полное описание 3",
                        Price = 300,
                        ImageUrl = "url",
                        ImageThumbnailUrl = "url",
                        IsPrefferedService = false,
                        Category = Categories["Прием у врача"]
                    },
                    new Service
                    {
                        Name = "Запись на прием 4",
                        ShortDescription = "Короткое описание 4",
                        LongDescription = "Полное описание 4",
                        Price = 400,
                        ImageUrl = "url",
                        ImageThumbnailUrl = "url",
                        IsPrefferedService = true,
                        Category = Categories["Прием у врача"]
                    },
                    new Service
                    {
                        Name = "Запись на прием 5",
                        ShortDescription = "Короткое описание 5",
                        LongDescription = "Полное описание 5",
                        Price = 500,
                        ImageUrl = "url",
                        ImageThumbnailUrl = "url",
                        IsPrefferedService = false,
                        Category = Categories["Прием у врача"]
                    },
                    new Service
                    {
                        Name = "Процедура или услуга 1",
                        ShortDescription = "Короткое описание 1",
                        LongDescription = "Полное описание 1",
                        Price = 1000,
                        ImageUrl = "url",
                        ImageThumbnailUrl = "url",
                        IsPrefferedService = false,
                        Category = Categories["Процедуры и услуги"]
                    },
                    new Service
                    {
                        Name = "Процедура или услуга 2",
                        ShortDescription = "Короткое описание 2",
                        LongDescription = "Полное описание 2",
                        Price = 2000,
                        ImageUrl = "url",
                        ImageThumbnailUrl = "url",
                        IsPrefferedService = true,
                        Category = Categories["Процедуры и услуги"]
                    },
                    new Service
                    {
                        Name = "Процедура или услуга 3",
                        ShortDescription = "Короткое описание 3",
                        LongDescription = "Полное описание 3",
                        Price = 3000,
                        ImageUrl = "url",
                        ImageThumbnailUrl = "url",
                        IsPrefferedService = false,
                        Category = Categories["Процедуры и услуги"]
                    },
                    new Service
                    {
                        Name = "Процедура или услуга 4",
                        ShortDescription = "Короткое описание 4",
                        LongDescription = "Полное описание 4",
                        Price = 4000,
                        ImageUrl = "url",
                        ImageThumbnailUrl = "url",
                        IsPrefferedService = true,
                        Category = Categories["Процедуры и услуги"]
                    },
                    new Service
                    {
                        Name = "Процедура или услуга 5",
                        ShortDescription = "Короткое описание 5",
                        LongDescription = "Полное описание 5",
                        Price = 5000,
                        ImageUrl = "url",
                        ImageThumbnailUrl = "url",
                        IsPrefferedService = true,
                        Category = Categories["Процедуры и услуги"]
                    }
                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Category> categories;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var categoryList = new Category[]
                    {
                        new Category { Name = "Прием у врача", Description="Запись на прием к специалисту" },
                        new Category { Name = "Процедуры и услуги", Description="Бронирование времени для процедур и иных услуг" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category category in categoryList)
                    {
                        categories.Add(category.Name, category);
                    }
                }

                return categories;
            }
        }
    }
}
