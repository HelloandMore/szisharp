using AtletikaBajnoksag.Database;
using AtletikaBajnoksag.Database.Entities;

using var dbContext = new AppDbContext();

await AddToDatabaseAsync();

async Task AddToDatabaseAsync()
{
    var cities = new List<CityEntity>
    {
        new CityEntity()
        {
            PostalCode = 6758,
            CityName = "Röszke"
        },
        new CityEntity()
        {
            PostalCode = 6725,
            CityName = "Szeged"
        },
        new CityEntity()
        {
            PostalCode = 3300,
            CityName = "Eger"
        }
    };
    await dbContext.City.AddRangeAsync(cities);
    await dbContext.SaveChangesAsync();
    var organizations = new List<OrganizationEntity>
    {
        new OrganizationEntity()
        {
            Name = "Pick Szeged",
            Email = "szeged.szalamia@citromail.hu",
            PhoneNumber = "+36301234567",
            Location = new LocationEntity()
            {
                City = cities[1],
                StreetName = "Szabadkai út",
                HouseNumber = 18
            } 
        }
    };
    await dbContext.Organization.AddRangeAsync(organizations);
    await dbContext.SaveChangesAsync();
    var competitions = new List<CompetitionEntity>
    {
        new CompetitionEntity()
        {
            BeginDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(3.61),
            Name = "control pont",
            Year = 20204,
            CompetitionNumber = new List<CompetitionNumberEntity>
            {
                new CompetitionNumberEntity()
                {
                    Category = CategoryEnum.running,
                    Subcategory = SubcategoryEnum.flat10000m,
                    Competitors = new List<CompetitorEntity>
                    {
                        new CompetitorEntity()
                        {
                            Name = "Kis Pista",
                            BirthDate = DateTime.Now.AddDays(-4584.4),
                            Gender = GenderEnum.Male,
                            AgeGroup = AgeGroupEnum.U13,
                            Organization = organizations[0],
                            Location = new LocationEntity()
                            {
                                City = cities[2],
                                StreetName = "Gárdonyi Géza utca",
                                HouseNumber = 24
                            },
                            Supervisor = new SupervisorEntity()
                            {
                                Name = "Nagy Béla",
                                PhoneNumber = "+36706852197"
                            }                            
                        }
                    }
                }
            },
            Location = new LocationEntity()
            {
                CityPostalCode = cities[0].PostalCode,
                StreetName = "Szegfű utca",
                HouseNumber = 16
            }
        }
    };
    await dbContext.Competition.AddRangeAsync(competitions);
    await dbContext.SaveChangesAsync();
}