using Lecso.Database;
using Lecso.Database.Entities;
using System.Net.Http.Headers;

using var dbContext = new AppDbContext();

#region new record
/*
await dbContext.Vehicles.AddAsync(vehicle);
await dbContext.SaveChangesAsync();
*/
#endregion

await AddCompetitionToDbAsync();


async Task AddCompetitionToDbAsync()
{
    #region AddLocations
    var locations = new List<LocationEntity>
    {
        new LocationEntity()
        {
            PostalCode = 6725,
            Name = "Szeged",
            StreetName = "Moszkvai körút",
            HouseNumber = 6
        },
        new LocationEntity()
        {
            PostalCode = 1007,
            Name = "Budapest",
            StreetName = "Hajós Alfréd sétány",
            HouseNumber = 11
        }
    };
    await dbContext.Location.AddRangeAsync(locations);
    #endregion


    #region AddJudges
    var judges = new List<JudgeEntity>
    {
        new JudgeEntity()
        {
            Name = "Horthy Miklós",
            PhoneNumber = "+3670813251",
            Email = "horthy.miklos@citromail.com"
        },
        new JudgeEntity()
        {
            Name = "Kádár János",
            PhoneNumber = "+36305984261",
            Email = "kadi.jani@freemail.pro"
        }
    };
    #endregion
    await dbContext.Judge.AddRangeAsync(judges);

    #region AddTeams
    var teams = new List<TeamsEntity>
    {
        new TeamsEntity()
        {
            Name = "Menő Lecsó Csapata"
        },
        new TeamsEntity()
        {
            Name = "Patkány L'ecsó"
        }
    };

    await dbContext.Teams.AddRangeAsync(teams);
    await dbContext.SaveChangesAsync();

    var members = new List<MemberEntity>
    {
        new MemberEntity()
        {
            TeamId = teams[0].Id,
            Name = "József Béla"
        },
        new MemberEntity()
        {
            TeamId = teams[0].Id,
            Name = "Karasz Máté"
        },
        new MemberEntity()
        {
            TeamId = teams[0].Id,
            Name = "Báthory János"
        },
        new MemberEntity()
        {
            TeamId = teams[0].Id,
            Name = "Kondor Milán"
        },
        new MemberEntity()
        {
            TeamId = teams[1].Id,
            Name = "Gordon Ramsay"
        },
        new MemberEntity()
        {
            TeamId = teams[1].Id,
            Name = "Gáspár Laci"
        },
        new MemberEntity()
        {
            TeamId = teams[1].Id,
            Name = "Hulk Hogan"
        }
    };

    await dbContext.Member.AddRangeAsync(members);
    await dbContext.SaveChangesAsync();
    #endregion

    #region AddCompetition
    var competititons = new List<CompetitionEntity>
    {
        new CompetitionEntity()
        {
            Date = DateTime.Now,
            Name = "Csaba Lecso Versenye",
            LocationPostalCode = locations[0].PostalCode
        },
        new CompetitionEntity()
        {
            Date = DateTime.Now.AddDays(1),
            Name = "Margin Lecsója",
            LocationPostalCode = locations[1].PostalCode
        }
    };

    await dbContext.Competition.AddRangeAsync(competititons);
    await dbContext.SaveChangesAsync();
    #endregion
}