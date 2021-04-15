using Xunit;
using BLL.Services;
using DAL.Entities;
using XMLSerialization;
namespace XUnitTest
{
    public  class GamesServiceTests
    {

        [Fact]
        public void AddGames_should_return_NameOfGame()
        {
            //arrange
            Games games = new Games();
            var gam = new GamesService(new XMLProvider<Games>("games.xml"));
            string name = "games";
            var expected = games.Name = "games";
            //act
            gam.AddGame(name);
            //assert
            Assert.Equal(expected, games.Name);

        }
        [Fact]
        public void ChangeGame_should_return_NewNameOfStadium()
        {
            //arrange

            var gam = new GamesService(new XMLProvider<Games>("games.xml"));
            gam.AddGame("game");
            string name = "game";
            int index = 0;
            string expected = "game";

            //act
            gam.ChangeGame(name, index);
            //assert
            Assert.Equal(expected, gam[index].Name);
        }
        [Fact]
        public void AddtimeofGame_should_AddTimeofGame()
        {
            //arrange
            Games games = new Games();
            var gam = new GamesService(new XMLProvider<Games>("games.xml"));
            int day  = 1;
            var expected = games.Day = 1;

            //act
            gam.AddTimeofGame(day);
            //assert
            Assert.Equal(expected, games.Day);
        }
        [Fact]
        public void ChangeTimeofGame_should_AddNewTimeofGame()
        {
            //arrange

            var gam = new GamesService(new XMLProvider<Games>("games.xml"));
            gam.AddTimeofGame(1);
            int day = 1;
            int index = 0;
            var expected = 1;

            //act
            gam.ChangeTimeOfGame(day, index);
            //assert
            Assert.Equal(expected, gam[index].Day);
        }
        [Fact]
        public void AddPlaceofGame_should_AddPlaceofGame()
        {
            //arrange
            Games games = new Games();
            var gam = new GamesService(new XMLProvider<Games>("games.xml"));
            string city = "Kiev";
            var expected = games.CityOfGame ="Kiev";

            //act
            gam.AddPlaceofGame(city);
            //assert
            Assert.Equal(expected, games.CityOfGame);
        }
        [Fact]
        public void ChangePlaceofGame_should_AddNewPlaceofGameforIndex()
        {

            //arrange

            var gam = new GamesService(new XMLProvider<Games>("games.xml")); 
            gam.AddPlaceofGame("Kiev");
            string city = "Kiev";
            int index = 0;
            var expected = "Kiev";

            //act
            gam.ChangePlaceOfGame(city,index);
            //assert
            Assert.Equal(expected, gam[index].CityOfGame);
        }
        [Fact]
        public void AddCountofVisitors_should_AddCountofVisitors()
        {
            //arrange
            Games games = new Games();
            var gam = new GamesService(new XMLProvider<Games>("games.xml"));
            int count = 10;
            var expected = games.CountVisitors = 10;

            //act
            gam.AddCountofVisitors(count);
            //assert
            Assert.Equal(expected, games.CountVisitors);
        }
        [Fact]
        public void ChangeCountofVisitors_should_AddNewCountofVisitors()
        {
            //arrange

            var gam = new GamesService(new XMLProvider<Games>("games.xml"));
            gam.AddCountofVisitors(10);
            int count = 10;
            int idex = 0;
            var expected = 10;

            //act
            gam.ChangeCountOfVisitors(idex, count);
            //assert
            Assert.Equal(expected, gam[idex].CountVisitors);
        }

       
    }
}
