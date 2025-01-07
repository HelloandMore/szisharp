using Tancverseny.Database;
using Tancverseny.Database.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

using var dbContext = new AppDbContext();

await AddDataToDbAsync();

async Task AddDataToDbAsync()
{
    var countries = new List<CountryEntity>
    {
        new CountryEntity()
        {
            CountryName = "Oroszország"
        },
        new CountryEntity()
        {
            CountryName = "Magyarország"
        }
    };

    await dbContext.Country.AddRangeAsync(countries);
    await dbContext.SaveChangesAsync();

    var cities = new List<CityEntity>
    { 
        new CityEntity()
        {
            CountryId = countries[0].Id,
            CityName = "Leningrád",
            PostalCode = "As34ed32"
        },
        new CityEntity()
        {
            CountryId = countries[1].Id,
            CityName = "Szeged",
            PostalCode = "6725"
        },
        new CityEntity()
        {
            CountryId = countries[1].Id,
            CityName = "Röszke",
            PostalCode = "6758"
        }
    };

    await dbContext.City.AddRangeAsync(cities);
    await dbContext.SaveChangesAsync();

    var competitions = new List<CompetitionEntity>
    {
        new CompetitionEntity()
        {
            Name = "Sztepper",
            BeginDate = DateTime.Now.AddDays(-2).Date,
            EndDate = DateTime.Now.AddDays(1).Date,
            Location = new LocationEntity()
            {
                CityId = cities[1].Id,
                HouseNumber = 12,
                StreetName = "Sajt utca"
            },
            Groups = new List<GroupEntity>()
            {
                new GroupEntity()
                {
                    Choreographer = "Adolf Hitler",
                    Points = 50,
                    GroupName = "Novaja Ekonomicheskaja Politika",
                    Participants = new List<ParticipantEntity>
                    {
                        new ParticipantEntity()
                        {
                            Name = "Joseph Stalin",
                            Gender = "male",
                            DateOfBirth = DateTime.Now.AddYears(-50).Date,
                            Location = new LocationEntity()
                            {
                                CityId = cities[0].Id,
                                HouseNumber = 12,
                                StreetName = "Valami utca"
                            }
                        },
                        new ParticipantEntity()
                        {
                            Name = "Taylor Swift",
                            Gender = "female",
                            DateOfBirth = DateTime.Now.AddYears(-43).Date,
                            Location = new LocationEntity()
                            {
                                CityId = cities[0].Id,
                                HouseNumber = 12,
                                StreetName = "Valami utca"
                            }
                        }
                    }
                }
            }
        },
        new CompetitionEntity()
        {
            Name = "Sztepper",
            BeginDate = DateTime.Now.AddDays(3).Date,
            EndDate = DateTime.Now.AddDays(10).Date,
            Location = new LocationEntity()
            {
                CityId = cities[1].Id,
                HouseNumber = 3,
                StreetName = "Galamb utca"
            },
            Groups = new List<GroupEntity>()
            {
                new GroupEntity()
                {
                    Choreographer = "Horthy Miklós",
                    Points = 69,
                    GroupName = "Katonája",
                    Participants = new List<ParticipantEntity>()
                    {
                        new ParticipantEntity()
                        {
                            Name = "John Doe",
                            DateOfBirth = DateTime.Now.AddYears(-40).Date,
                            Gender = "male",
                            Location = new LocationEntity()
                            {
                                CityId = cities[1].Id,
                                HouseNumber = 43,
                                StreetName = "Galamb utca"
                            }
                        }
                    }
                }
            }
        },
        new CompetitionEntity()
        {
            Name = "Katyusa",
            BeginDate = DateTime.Now.AddDays(20).Date,
            EndDate = DateTime.Now.AddDays(21).Date,
            Location = new LocationEntity()
            {
                CityId = cities[2].Id,
                HouseNumber = 5,
                StreetName = "Szegfű utca"
            },
            Groups =new List<GroupEntity>{
                new GroupEntity()
                {
                    Choreographer = "Vladimir Putin",
                    Points = 120,
                    GroupName = "Soyuz Sovetskih Socialisticheskih Respublik",
                    Participants = new List<ParticipantEntity>()
                    {
                        new ParticipantEntity()
                        {
                            Name = "Vladimir Lenin",
                            Gender = "male",
                            DateOfBirth = DateTime.Now.Date,
                            Location = new LocationEntity()
                            {
                                CityId = cities[0].Id,
                                HouseNumber = 41,
                                StreetName = "Soviet utca"
                            }
                        }
                    }
                }
            }
        },
        new CompetitionEntity()
        {
            Name = "Táncoló talpak",
            BeginDate = DateTime.Now.Date,
            EndDate = DateTime.Now.AddDays(3).Date,
            Location = new LocationEntity()
            {
                CityId = cities[2].Id,
                HouseNumber = 21,
                StreetName = "Május 1. utca"
            },
            Groups = new List<GroupEntity>()
            {
                new GroupEntity()
                {
                    Choreographer = "Barack Obama",
                    Points = 70,
                    GroupName = "Freedom",
                    Participants = new List<ParticipantEntity>
                    {
                        new ParticipantEntity()
                        {
                            Name = "Donald Trump",
                            Gender = "male",
                            DateOfBirth = DateTime.Now.AddYears(-50).Date,
                            Location = new LocationEntity()
                            {
                                CityId = cities[1].Id,
                                HouseNumber = 46,
                                StreetName = "Galamb utca"
                            }
                        },
                        new ParticipantEntity()
                        {
                            Name = "Hillary Clinton",
                            Gender = "female",
                            DateOfBirth = DateTime.Now.AddYears(-43).Date,
                            Location = new LocationEntity()
                            {
                                CityId = cities[0].Id,
                                HouseNumber = 2,
                                StreetName = "Soviet utca"
                            }
                        }
                    }
                }
            }
        }
    };

    await dbContext.AddRangeAsync(competitions);
    await dbContext.SaveChangesAsync();
}