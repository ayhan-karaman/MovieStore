using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreUI.Common.Mappings;
using MovieStoreUI.DbOperations;

namespace MovieStore.UnitTests.TestSetup
{
     public class CommonTestFixture
    {
        public MovieStoreDbContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<MovieStoreDbContext>().UseInMemoryDatabase(databaseName: "MovieStoreTestDb").Options;
            Context = new MovieStoreDbContext(options);
            Context.Database.EnsureCreated();
            Context.AddActors();
            Context.SaveChanges();
            Mapper = new MapperConfiguration(cfg=>{cfg.AddProfile<MappingProfile>(); }).CreateMapper();
        }
    }
}