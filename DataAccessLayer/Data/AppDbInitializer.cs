using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MobileStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                // mobiles
                if (!context.Mobiles.Any())
                {
                    context.Mobiles.AddRange(new List<Mobile>()
                    {
                        new Mobile()
                        {
                            MobileName = "Huawei P30 Lite",
                            ManufactureDate = new DateTime(2019,03,15),
                            MobilePrice = 450.00,
                            MobileImage = "https://my-techspace.com/wp-content/uploads/2019/05/Huawei-P30-Lite-600x600.jpg",
                        },
                        new Mobile()
                        {
                            MobileName = "Iphone 12",
                            MobilePrice = 850.00,
                            ManufactureDate = new DateTime(2020,10,23),
                            MobileImage = "https://applephone.mk/wp-content/uploads/2020/10/iphone-12-600x600.jpg"
                        },
                        new Mobile()
                        {
                            MobileName = "Huawei P40",
                            ManufactureDate = new DateTime(2020,03,26),
                            MobilePrice = 700.00,
                            MobileImage = "https://vokob.com/wp-content/uploads/2021/10/ZZ-600x600.jpg"
                        }
                    });
                    context.SaveChanges();
                }
                // manufacturers
                if (!context.Manufacturers.Any())
                {
                    context.Manufacturers.AddRange(new List<Manufacturer>
                    {
                        new Manufacturer()
                        {
                            PictureUrl = "https://logos-world.net/wp-content/uploads/2020/04/Huawei-Logo.png",
                            ManufacturerName = "Huawei",
                            ManufacturerBiography = "Huawei Technologies is a Chinese multinational technology corporation headquartered in Shenzhen, China. It designs develops and sells telecommunications equipment, consumer electronics and various smart devices."
                        },
                        new Manufacturer()
                        {
                            PictureUrl = "https://i.pinimg.com/originals/24/13/3a/24133a0cfbc054db31c9ac97c64ea727.jpg",
                            ManufacturerName = "Apple Inc.",
                            ManufacturerBiography = "Apple Inc. is an American multinational technology company that specializes in consumer electronics, computer software and online services. It is the largest information technology company by revenue."
                        },
                        new Manufacturer()
                        {
                            PictureUrl = "https://iconape.com/wp-content/png_logo_vector/meizu.png",
                            ManufacturerName = "Meizu Technology Co.",
                            ManufacturerBiography = "Meizu Technology Co. is a Chinese consumer electronics company based in Zhuhai, China. It is founded in 2003 by Jack Wong and they began as a manufacturer of MP3 & MP4 Players."
                        },
                    });
                    context.SaveChanges();
                }
                // mobile descriptions
                if (!context.MobileDescriptions.Any())
                {
                    context.MobileDescriptions.AddRange(new List<MobileDescription>
                    {
                        new MobileDescription()
                        {
                            Description = "Huawei P30 Lite mobile was launched in March, 2019."
                        },
                        new MobileDescription()
                        {
                            Description = "Iphone 12 mobile was launched in October, 2020."
                        },
                        new MobileDescription()
                        {
                            Description = "Huawei P40 mobile was launched in March, 2020."
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
