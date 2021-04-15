using Xunit;
using BLL.Services;
using DAL.Entities;
using XMLSerialization;
namespace XUnitTest
{
    public class PlayerServiceTests
    {

        [Fact]
        public void AddBday_should_return_NewBday()
        {
            //arrange
            Player player = new Player();
            var pl = new PlayerService(new XMLProvider<Player>("player.xml"));
            var day = 10;
            var expected = player.BDay= 10;
           
            //act
            pl.AddBDay(day);
            //assert
            Assert.Equal(expected, player.BDay);

        }
        [Fact]
        public void ChangeBday_should_return_NewBday()
        {
            //arrange

            var pl = new PlayerService(new XMLProvider<Player>("player.xml"));
            pl.AddBDay(10);
            int day = 10;
            int index = 0;
            var expected = 10;

            //act
            pl.ChangeBDay(day, index);
            //assert
            Assert.Equal(expected, pl[index].BDay);
        }
        [Fact]
        public void AddRole_should_AddRole()
        {
            Player player = new Player();
            var pl = new PlayerService(new XMLProvider<Player>("player.xml"));
            string role= "role";
            var expected = player.Role = "role";

            //act
            pl.AddRole(role);
            //assert
            Assert.Equal(expected, player.Role);

        }
        [Fact]
        public void ChangeRole_should_AddNewRole()
        {
            //arrange

            var pl = new PlayerService(new XMLProvider<Player>("player.xml"));
            pl.AddBDay(10);
            string roley = "role";
            int index = 0;
            var expected = "role";

            //act
            pl.ChangeRole(roley, index);
            //assert
            Assert.Equal(expected, pl[index].Role);
        }
        [Fact]
        public void AddRHealth_should_AddHealth()
        {
            Player player = new Player();
            var pl = new PlayerService(new XMLProvider<Player>("player.xml"));
            string health = "health";
            var expected = player.Health = "health";

            //act
            pl.AddHealth(health);
            //assert
            Assert.Equal(expected, player.Health);

        }
        [Fact]
        public void ChangeHealth_should_AddNewHealth()
        {
            //arrange

            var pl = new PlayerService(new XMLProvider<Player>("player.xml"));
            pl.AddHealth("health");
            string health = "health";
            int index = 0;
            var expected = "health";

            //act
            pl.ChangeRole(health, index);
            //assert
            Assert.Equal(expected, pl[index].Health);
        }
        [Fact]
        public void AddSalary_should_AddSalary()
        {
            Player player = new Player();
            var pl = new PlayerService(new XMLProvider<Player>("player.xml"));
            int sal = 10;
            var expected = player.Salary =10;

            //act
            pl.AddSalary(sal);
            //assert
            Assert.Equal(expected, player.Salary);

        }
        [Fact]
        public void ChangeSalary_should_AddNewHealth()
        {
            //arrange

            var pl = new PlayerService(new XMLProvider<Player>("player.xml"));
            pl.AddHealth("health");
            int sal = 10;
            int index = 0;
            var expected =10;

            //act
            pl.ChangeSalery(sal, index);
            //assert
            Assert.Equal(expected, pl[index].Salary);
        }
    }
}
