using Infotecs.Domain;
using Infotecs.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infotecs.Tests.Common
{
    public class InfotecsContextFactory
    {
        public const string FileForDeleteName = "test5.csv";
        public const string FirstFileName = "test01.csv";
        public const string SecondFileName = "test.csv";
        public const string ThirdFileName = "test3.csv";


        public static InfotecsDbContext Create()
        {
            var options = new DbContextOptionsBuilder<InfotecsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new InfotecsDbContext(options);

            context.Values.AddRange(
                new Value
                {
                    Id = Guid.Parse("310E9D19-45AF-4226-92A4-C84C13BE81F6"),
                    FileName = FirstFileName,
                    DateAndTime = new DateTime(2021, 1, 1, 8, 5, 4),
                    Seсonds = 1024,
                    Indicator = 744.5f
                },

                new Value
                {
                    Id = Guid.Parse("3B1DAD59-E5CB-48C9-8C59-3FAAE8EFAE4B"),
                    FileName = FirstFileName,
                    DateAndTime = new DateTime(2021, 1, 1, 8, 7, 4),
                    Seсonds = 1324,
                    Indicator = 1400.5f
                },

                new Value
                {
                    Id = Guid.Parse("D7996CEF-2588-4257-9D84-14F6548EFE2C"),
                    FileName = SecondFileName,
                    DateAndTime = new DateTime(2022, 1, 1, 8, 7, 4),
                    Seсonds = 1324,
                    Indicator = 1400.5f
                }
            );

            context.Results.AddRange(
                new Result
                {
                    Id = Guid.Parse("C1095CBC-8339-49A1-9C51-E6633D00F560"),
                    FileName = FirstFileName,
                    AllTime = new TimeSpan(0, 2, 0),
                    MinDateAndTime = new DateTime(2021, 1, 1, 8, 5, 4),
                    AvgSeсonds = 1174,
                    AvgIndicator = 1072.5f,
                    MedianIndicator = 1072.5f,
                    MinIndicator = 744.5f,
                    MaxIndicator = 1400.5f,
                    CountStrings = 2
                },

                new Result
                {
                    Id = Guid.Parse("EE9F6306-09CD-4263-9232-C5C5B5690A16"),
                    FileName = SecondFileName,
                    AllTime = new TimeSpan(0, 0, 0),
                    MinDateAndTime = new DateTime(2022, 1, 1, 8, 7, 4),
                    AvgSeсonds = 1324,
                    AvgIndicator = 1400.5f,
                    MedianIndicator = 1400.5f,
                    MinIndicator = 1400.5f,
                    MaxIndicator = 1400.5f,
                    CountStrings = 1
                }
            );

            context.SaveChanges();
            return context;
        }

        public static void Destroy(InfotecsDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
