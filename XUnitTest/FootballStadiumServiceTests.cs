using Xunit;
using BLL.Services;
using DAL.Entities;
using XMLSerialization;
namespace XUnitTest
{
    public class FootballStadiumServiceTests
    {

        [Fact]
        public void AddFootballStadium_should_return_NameOfStadium()
        {
            //arrange
            FootballStadium footballStadium = new FootballStadium();
            var football = new FootballStadiumService(new XMLProvider<FootballStadium>("footballl.xml"));
            string name = "Football";
            var expected = footballStadium.Name = "Football";
            //act
            football.AddFoortballStadium(name);
            //assert
            Assert.Equal(expected, footballStadium.Name);

        }
        [Fact]
        public void ChangeFootballStadium_should_return_NewNameOfStadium()
        {
            //arrange
            
            var football = new FootballStadiumService(new XMLProvider<FootballStadium>("footballl.xml"));
            football.AddFoortballStadium("hello");
            string name = "hello";
            int index = 0;
            string expected = "hello";
          
            //act
            football.ChangeFootballStadium(name, index);
            //assert
            Assert.Equal(expected, football[index].Name);
        }
        [Fact]
        public void AddCountOfPlace_should_AddCountOfPlace_2()
        {
            //arrange
            FootballStadium footballStadia = new FootballStadium();
            var football = new FootballStadiumService(new XMLProvider<FootballStadium>("footballl.xml"));
            int place = 2;
            var expected = footballStadia.NumberofPlace = 2;

            //act
            football.AddCountOfPlace(place);
            //assert
            Assert.Equal(expected, footballStadia.NumberofPlace);
        }
        [Fact]
        public void ChangeCountofPlace_should_AddCountOfPlace_2()
        {
            //arrange

            var football = new FootballStadiumService(new XMLProvider<FootballStadium>("footballl.xml"));
            football.AddCountOfPlace(1);
            int place = 2;
            int index = 0;
            var expected = 2;

            //act
            football.ChangeCountofPlace(index, place);
            //assert
            Assert.Equal(expected, football[index].NumberofPlace);
        }
        [Fact]
        public void AddPriceofTicket_should_AddPriceOfTicket()
        {
            //arrange
            FootballStadium footballStadia = new FootballStadium();
            var football = new FootballStadiumService(new XMLProvider<FootballStadium>("footballl.xml"));
            double price = 10;
            var expected = footballStadia.PriceOfTicket = 10;

            //act
            football.AddPriceofTicket(price);
            //assert
            Assert.Equal(expected, footballStadia.PriceOfTicket);
        }
        [Fact]
        public void ChangePriceofTicket_should_AddNewPriceOfTicket()
        {
          
            //arrange
            
            var football = new FootballStadiumService(new XMLProvider<FootballStadium>("footballl.xml"));
            football.AddPriceofTicket(1);
            double price = 10;
            int index = 0;
            double expected = 10;

            //act
            football.ChangePriceofTicket(index, price);
            //assert
            Assert.Equal(expected, football[index].PriceOfTicket);
        }
        [Fact]
        public void AddDayofGame_should_AddDayofTheGame()
        {
            //arrange
            FootballStadium footballStadia = new FootballStadium();
            var football = new FootballStadiumService(new XMLProvider<FootballStadium>("footballl.xml"));
            int day = 10;
            var expected = footballStadia.DayoOfGame = 10;

            //act
            football.AddDayofGame(day);
            //assert
            Assert.Equal(expected, footballStadia.DayoOfGame);
        }
        [Fact]
        public void ChangeDayofGame_should_AddNewPriceOfTicket()
        {
            //arrange
            
            var football = new FootballStadiumService(new XMLProvider<FootballStadium>("footballl.xml"));
            football.AddDayofGame(1);
            int day = 10;
            int idex = 0;
            var expected = 10;

            //act
            football.ChangeDayofGame(day, idex);
            //assert
            Assert.Equal(expected, football[idex].DayoOfGame);
        }
        [Fact]
        public void AddComand_should_AddDayofTheGame()
        {
            //arrange
            string first = "First";
            string second = "Second";

            var football = new FootballStadiumService(new XMLProvider<FootballStadium>("footballl.xml"));

            int index = 0;
            football.AddComand("das","dsa");
            


            //act
            football.AddComand(first, second);
            //assert
           
            Assert.NotNull(football[index]);
        }
        [Fact]
        public void ChangeComad_should_AddNewNameOfComands()
        {
            //arrange
            string first = "First";
            string second = "Second";

            var football = new FootballStadiumService(new XMLProvider<FootballStadium>("footballl.xml"));

            int index = 0;
            football.AddComand("das", "dsa");
           



            //act
            football.AddComand(first, second);
            //assert
            
            Assert.NotNull(football[index]);
        }
    }
}
