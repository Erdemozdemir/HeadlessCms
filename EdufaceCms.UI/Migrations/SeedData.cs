using EdufaceCms.DataAccessLayer;
using EdufaceCms.Entities.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace EdufaceCms.UI.Migrations
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            DatabaseContext context = app.ApplicationServices.GetRequiredService<DatabaseContext>();

            context.Database.Migrate();

            if (context.Students.Count() < 10)
            {
                for (int i = 0; i < 20; i++)
                {
                    var name = Faker.NameFaker.FirstName();
                    var lastName = Faker.NameFaker.LastName();
                    var phone = Faker.PhoneFaker.Phone();
                    var address = Faker.LocationFaker.Country();
                    var tc = "11111111111";
                    var neigh = Faker.LocationFaker.StreetName();
                    var email = Faker.InternetFaker.Email();
                    var emerPerson = string.Format("{0} {1}", Faker.NameFaker.FirstName(), Faker.NameFaker.LastName());
                    string gender = "";

                    if (i % 2 == 0)
                        gender = "Kadın";
                    else
                        gender = "Erkek";

                    var proxi = "Yakın";
                    var refere = "Referans";

                    var cityId = new Random().Next(1, 80);


                    var city = context.Cities.Find(cityId);

                    var county = context.Counties.FirstOrDefault(x => x.City.Id == cityId);

                    var branchId = new Random().Next(1, 3);

                    context.Add(new StudentEntity
                    {
                        Name = name,
                        Surname = lastName,
                        TC = tc,
                        CellPhone = phone,
                        Email = email,
                        Neighborhood = neigh,
                        Address = address,
                        BranchId = branchId,
                        CityId = cityId,
                        CountyId = county.Id,
                        Reference = refere,
                        Proximity = proxi,
                        Gender = gender,
                        EmergencyPerson = emerPerson,
                        CreDate = DateTime.Now,
                        IsActive = true,
                    });
                }
            }

            if (!context.PaymentTypes.Any())
            {
                context.PaymentTypes.AddRange(
                    new PaymentTypeEntity { Name = "Peşin", IsActive = true, CreDate = DateTime.Now },
                    new PaymentTypeEntity { Name = "Taksit", IsActive = true, CreDate = DateTime.Now },
                    new PaymentTypeEntity { Name = "Senet", IsActive = true, CreDate = DateTime.Now });
            }

            if (!context.Educations.Any())
            {
                context.Educations.AddRange(
                    new EducationEntity { Name = "İngilizce", IsActive = true, CreDate = DateTime.Now },
                    new EducationEntity { Name = "Arapça", IsActive = true, CreDate = DateTime.Now },
                    new EducationEntity { Name = "Türkçe", IsActive = true, CreDate = DateTime.Now },
                    new EducationEntity { Name = "TOEFL", IsActive = true, CreDate = DateTime.Now },
                    new EducationEntity { Name = "IELTS", IsActive = true, CreDate = DateTime.Now },
                    new EducationEntity { Name = "Diğer", IsActive = true, CreDate = DateTime.Now });
            }

            if (!context.Levels.Any())
            {
                context.Levels.AddRange(
                    new LevelEntity { Name = "Belirsiz", IsActive = true, CreDate = DateTime.Now },
                    new LevelEntity { Name = "Elemantary", IsActive = true, CreDate = DateTime.Now },
                    new LevelEntity { Name = "Pre Intermediate", IsActive = true, CreDate = DateTime.Now },
                    new LevelEntity { Name = "Intermediate", IsActive = true, CreDate = DateTime.Now },
                    new LevelEntity { Name = "Upper Intermediate", IsActive = true, CreDate = DateTime.Now },
                    new LevelEntity { Name = "Advanced", IsActive = true, CreDate = DateTime.Now });
            }

            if (!context.Times.Any())
            {
                context.Times.AddRange(
                    new TimeEntity { Name = "Hafta İçi Sabah", IsActive = true, CreDate = DateTime.Now },
                    new TimeEntity { Name = "Hafta İçi Öğlen", IsActive = true, CreDate = DateTime.Now },
                    new TimeEntity { Name = "Hafta İçi Akşam", IsActive = true, CreDate = DateTime.Now },
                    new TimeEntity { Name = "Hafta Sonu Sabah", IsActive = true, CreDate = DateTime.Now },
                    new TimeEntity { Name = "Hafta Sonu Öğlen", IsActive = true, CreDate = DateTime.Now },
                    new TimeEntity { Name = "Hafta Sonu Akşam", IsActive = true, CreDate = DateTime.Now });
            }

            if (!context.DataQualities.Any())
            {
                context.DataQualities.AddRange(
                    new DataQualityEntity { Name = "Az İlgili", IsActive = true, CreDate = DateTime.Now },
                    new DataQualityEntity { Name = "İlgili", IsActive = true, CreDate = DateTime.Now },
                    new DataQualityEntity { Name = "Çok İlgili", IsActive = true, CreDate = DateTime.Now },
                    new DataQualityEntity { Name = "Olumsuz", IsActive = true, CreDate = DateTime.Now },
                    new DataQualityEntity { Name = "Tekrar Aranacak", IsActive = true, CreDate = DateTime.Now });
            }

            if (!context.DataSources.Any())
            {
                context.DataSources.AddRange(
                    new DataSourceEntity { Name = "Google", IsActive = true, CreDate = DateTime.Now },
                    new DataSourceEntity { Name = "Table", IsActive = true, CreDate = DateTime.Now },
                    new DataSourceEntity { Name = "Referans", IsActive = true, CreDate = DateTime.Now },
                    new DataSourceEntity { Name = "Sosyal Medya", IsActive = true, CreDate = DateTime.Now },
                    new DataSourceEntity { Name = "Stand", IsActive = true, CreDate = DateTime.Now },
                    new DataSourceEntity { Name = "Diğer", IsActive = true, CreDate = DateTime.Now });
            }

            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new UserEntity
                    {
                        UserName = "Erdem Özdemir",
                        Email = "erdem.ozdemirr@yandex.com",
                        PasswordHash = "123456"
                    },

                    new UserEntity
                    {
                        UserName = "Test User",
                        Email = "test@yandex.com",
                        PasswordHash = "123456"
                    }
                    );
            }

            context.SaveChanges();
        }
    }
}
