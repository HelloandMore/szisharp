using OOT.Database;
using OOT.Database.Entities;

var dbContext = new AppDbContext();

void AddDataToDatabase()
{

    var members = new List<MemberEntity>
    {
        new MemberEntity()
        {
            Name = "Matthew",
            Location = new LocationEntity()
            {
                PostalCode = 6800,
                Name = "Vásárhely",
                Street = "Zrinyi",
                HouseNumber = 3
            },
            CardNumber = 1234,
            MemberSince = DateTime.Now
        },
        new MemberEntity()
        {
            Name = "StandingMatthew",
            Location = new LocationEntity()
            {
                PostalCode = 6800,
                Name = "Vásárhely",
                Street = "Malom",
                HouseNumber = 4
            },
            CardNumber = 4321,
            MemberSince = DateTime.Now.AddDays(-10)
        }
    };

    var watchings = new List<WatchingEntity>
    {
        new WatchingEntity()
        {
            Member = members[0],
            Date = DateTime.Now,
            Bird = new BirdEntity()
            {
                Classification = new ClassificationEntity()
                {

                }
            }
        }
    };
}