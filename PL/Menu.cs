using System;
using System.Text.RegularExpressions;
using BLL.Services;
using XMLSerialization;
using DAL.Entities;
namespace PL
{
    public class Menu
    {
        readonly FootballStadiumService Fts;
        readonly GamesService ges;
        readonly PlayerService pls;
        readonly Validator validator = new Validator();
        public Menu()
        {
            Fts = new FootballStadiumService(new XMLProvider<FootballStadium>("footballl.xml"));
            ges = new GamesService(new XMLProvider<Games>("games.xml"));
            pls = new PlayerService(new XMLProvider<Player>("player.xml"));

        }
        private int pars(string number) => !Regex.IsMatch(number, "[0-9]") ? -1 : int.Parse(number) - 1;

        public int IndexFootball()
        {
            int count = 1;
            foreach (var a in Fts)
            {
                Console.WriteLine((count++) + ". Football stadium: " + a.Name + ". All number of place " + a.NumberofPlace + ". Price of ticket: " + a.PriceOfTicket + ". Day of the game: " + a.DayoOfGame + ". Command: " + a.NameofCommand.first + ":" + a.NameofCommand.second);

            }

            Console.Write("Index: ");
            return pars(Console.ReadLine());
        }

        public int IndexGames()
        {
            int count = 1;
            foreach (var a in ges)
                Console.WriteLine((count++) + ". Games: " + a.Name + ". Day of the game " + a.Day + ". Count of the game: " + a.CountOfGame[0] + ":" + a.CountOfGame[1] + ". Count of visitors: " + a.CountVisitors + ". City of the game: " + a.CityOfGame);
            Console.Write("Index: ");
            return pars(Console.ReadLine());
        }

        public int IndexPlayer()
        {
            int count = 1;
            foreach (var a in pls)
                Console.WriteLine((count++) + ". Player name: " + a.Name + ". Player surname: " + a.Surname + ". Health of player: " + a.Health + ". Role of player: " + a.Role + ". Salary of player" + a.Salary + ". Birthady of player" + a.BDay);
            Console.Write("Index: ");
            return pars(Console.ReadLine());
        }
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Stadium\n2. Games\n3. Players\n0. Exit");
                Console.Write("Action: ");
                switch (Console.ReadLine())
                {
                    case "0":
                        Fts.Save();
                        ges.Save();
                        pls.Save();
                        return;
                    case "1":
                        Stadium();
                        break;
                    case "2":
                        Game();
                        break;
                    case "3":
                        Player();
                        break;
                    default:
                        Console.WriteLine("Wrong index\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }


        public void Stadium()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Stadium\n1. Add\n2. Delete\n3. Count of place\n4. Price of ticket\n5. Add day of game\n6. Add command\n7. View all information\n8. Search a stadium\n0. Back");
                Console.Write("Action: ");
                string choise = Console.ReadLine();
                Console.Clear();
                switch (choise)
                {
                    case "0":
                        return;
                    case "1":
                        try
                        {
                            NameofStadium();
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Delete stadium:");
                            Fts.DeleteStadium(IndexFootball());
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "3":
                        try
                        {
                            CountofPlace();
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "4":
                        try
                        {
                            PriceOfofTicket();
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "5":
                        try
                        {
                            DayofGameForStadium();
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "6":
                        try
                        {
                            AddComandServ();
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "7":
                        try
                        {
                            IndexFootball();
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;

                    case "8":
                        try
                        {
                            SearchStadium();
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    default:
                        Console.WriteLine("Wrong index\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void Game()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Games\n1. Add game\n2. Delete game\n3. Add player\n4. Delete player\n5. Time of game\n6. Place of game\n7. Count of visitors \n8. Change count of game\n9. Sort\n10. Sort for 4 part\n11 View all\n12. Search a game\n0. Back");
                Console.Write("Action: ");
                string choise = Console.ReadLine();
                Console.Clear();
                switch (choise)
                {

                    case "0":
                        return;
                    case "1":
                        try
                        {
                            NameofGame();
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "2":
                        try
                        {
                            int index = IndexGames();
                            Console.Write("Delete game: ");
                            ges.DeleteGame(index);
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "3":
                        try
                        {
                            Console.WriteLine("Add player");
                            int index = IndexGames();
                            Console.Write("Add name of player: ");
                            string name = validator.validator_name(Console.ReadLine());
                            Console.WriteLine("Add surname of player");
                            string surname = validator.validator_name(Console.ReadLine());
                            ges.AddPlayer(name, surname, index);
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "4":
                        try
                        {
                            Console.WriteLine("Delete player");
                            int index = IndexGames();
                            ges.DeletePlayer(index);
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "5":
                        try
                        {
                            DayofGame();
                        }

                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "6":
                        try
                        {
                            CityoftheGame();
                        }

                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "7":
                        try
                        {
                            Visitors();
                        }

                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "8":
                        try
                        {
                            CountofGame();
                        }

                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "9":
                        try
                        {
                            Console.WriteLine("Sort");

                            ges.Sort();
                        }

                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "10":
                        try
                        {
                            Console.WriteLine("Sort for 4 part");
                            int index = IndexGames();
                            ges.SortFour(index);
                        }

                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "11":
                        try
                        {
                            IndexGames();
                        }

                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "12":
                        try
                        {
                            SerchGame();
                        }

                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    default:
                        Console.WriteLine("Wrong index\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void Player()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Player\n1. Add player\n2. Delete player\n3. Change name\n4. Change surname\n5. BDay\n6. Role\n7. Health of player \n8. Salary\n9. View all\n10. Search a player\n0.  Back");
                Console.Write("Action: ");
                string choise = Console.ReadLine();
                Console.Clear();
                switch (choise)
                {

                    case "0":
                        return;
                    case "1":
                        try
                        {
                            NameSurnamePlayer();
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "2":
                        try
                        {
                            Console.Write("Delete player: ");
                            var index = IndexPlayer();
                            pls.DeletePlayer(index);
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "3":
                        try
                        {
                            Console.Write("Change name of player: ");
                            var index = IndexPlayer();
                            Console.WriteLine("Add new name of player");
                            string newname =validator.validator_name(Console.ReadLine());
                            pls.ChangeName(newname, index);
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "4":
                        try
                        {
                            Console.Write("Change surname of player: ");
                            var index = IndexPlayer();
                            Console.WriteLine("Add new surname of player");
                            string newsurname =validator.validator_name(Console.ReadLine());
                            pls.ChangeSurname(newsurname, index);
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "5":
                        try
                        {
                            BDay();
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "6":
                        try
                        {
                            Role();
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "7":
                        try
                        {
                            Health();
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "8":
                        try
                        {
                            Salary();
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "9":
                        try
                        {
                            Salary();
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "10":
                        try
                        {
                            SearchPlayer();
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    default:
                        Console.WriteLine("Wrong index\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }


        public void CountofPlace()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Place\n1. Add count of place\n2. Change count of place\n0.  Back");
                Console.Write("Action: ");
                string choise = Console.ReadLine();
                Console.Clear();
                switch (choise)
                {

                    case "0":
                        return;
                    case "1":
                        try
                        {
                            Console.Write("(Count of place < 100) Add count of place: ");
                            var place = validator.validator_countplace(Console.ReadLine());
                            Fts.AddCountOfPlace(Convert.ToInt32(place));
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("(Count of place < 100) Change count of place");
                            int ind = IndexFootball();
                            Console.Write("New count of place: ");
                            var place = validator.validator_countplace(Console.ReadLine());

                            Fts.ChangeCountofPlace(ind, Convert.ToInt32(place));
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    default:
                        Console.WriteLine("Wrong index\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void PriceOfofTicket()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Price\n1. Add price of ticket\n2. Change price of ticket\n0.  Back");
                Console.Write("Action: ");
                string choise = Console.ReadLine();
                Console.Clear();
                switch (choise)
                {

                    case "0":
                        return;
                    case "1":
                        try
                        {
                            Console.WriteLine("Price < 100");
                            Console.Write("Add price of ticket: ");
                            var rpice = validator.validator_priceofTicket(Console.ReadLine());
                            Fts.AddPriceofTicket(Convert.ToDouble(rpice));
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Price < 100");
                            Console.WriteLine("Change price if ticket");
                            int ind = IndexFootball();
                            Console.Write("New price: ");
                            var price = validator.validator_priceofTicket(Console.ReadLine());

                            Fts.ChangePriceofTicket(ind, Convert.ToDouble(price));
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    default:
                        Console.WriteLine("Wrong index\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void DayofGameForStadium()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Day\n1. Add day of the game\n2. Change day of the game\n0.  Back");
                Console.Write("Action: ");
                string choise = Console.ReadLine();
                Console.Clear();
                switch (choise)
                {

                    case "0":
                        return;
                    case "1":
                        try
                        {
                            Console.Write("Add day of the game: ");
                            var day = validator.validator_day(Console.ReadLine());
                            Fts.AddDayofGame(Convert.ToInt32(day));
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Change day of game");
                            int index = IndexFootball();
                            Console.WriteLine("Add new time of game");
                            var data =validator.validator_day(Console.ReadLine());
                            Fts.ChangeDayofGame(Convert.ToInt32(data), index);
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    default:
                        Console.WriteLine("Wrong index\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                }
            }
        }
        public void DayofGame()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Day\n1. Add day of the game\n2. Change day of the game\n0.  Back");
                Console.Write("Action: ");
                string choise = Console.ReadLine();
                Console.Clear();
                switch (choise)
                {

                    case "0":
                        return;
                    case "1":
                        try
                        {
                            Console.Write("Add day of the game: ");
                            var day =validator.validator_day(Console.ReadLine());
                            ges.AddTimeofGame(Convert.ToInt32(day));
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Change day of game");
                            int index = IndexGames();
                            Console.WriteLine("Add new time of game");
                            var data = validator.validator_day(Console.ReadLine());
                            ges.ChangeTimeOfGame(Convert.ToInt32(data), index);
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    default:
                        Console.WriteLine("Wrong index\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                }
            }
        }
        public void NameofStadium()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Name\n1. Add name of the stadium\n2. Change name of the stadium\n0.  Back");
                Console.Write("Action: ");
                string choise = Console.ReadLine();
                Console.Clear();
                switch (choise)
                {

                    case "0":
                        return;
                    case "1":
                        try
                        {
                            Console.Write("Name of the stadium: ");
                            var name = validator.validator_name(Console.ReadLine());
                            Fts.AddFoortballStadium(name);
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Change name of stadium");
                            int index = IndexFootball();
                            Console.WriteLine("Add new name of game");
                            string name = validator.validator_name(Console.ReadLine());
                            Fts.ChangeFootballStadium(name, index);
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    default:
                        Console.WriteLine("Wrong index\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }

        }
        public void NameSurnamePlayer()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Name and surname\n1. Add name and surname of the stadium\n2. Change name and surname of the stadium\n0.  Back");
                Console.Write("Action: ");
                string choise = Console.ReadLine();
                Console.Clear();
                switch (choise)
                {

                    case "0":
                        return;
                    case "1":
                        try
                        {
                            Console.Write("Name of the player: ");
                            var name = validator.validator_name(Console.ReadLine());
                            Console.Write("Surname: ");
                            var surname =validator.validator_name(Console.ReadLine());
                            pls.AddPlayer(name, surname);
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Change name of ");
                            int index = IndexPlayer();
                            Console.WriteLine("Add new name of player");
                            string name = validator.validator_name(Console.ReadLine());
                            Console.WriteLine("Add new surname of player");
                            string surname = validator.validator_name(Console.ReadLine());
                            pls.ChangeNamePlayer(name,surname, index);
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    default:
                        Console.WriteLine("Wrong index\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void NameofGame()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Name\n1. Add name of the game\n2. Change name of the game\n0.  Back");
                Console.Write("Action: ");
                string choise = Console.ReadLine();
                Console.Clear();
                switch (choise)
                {

                    case "0":
                        return;
                    case "1":
                        try
                        {
                            Console.Write("Name of the game: ");
                            var name = validator.validator_name(Console.ReadLine());
                            ges.AddGame(name);
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Change name of game");
                            int index = IndexGames();
                            Console.WriteLine("Add new name of game");
                            string name = validator.validator_name(Console.ReadLine());
                            ges.ChangeGame(name, index);
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    default:
                        Console.WriteLine("Wrong index\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }

        }
        public void CityoftheGame()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("City\n1. Add place of the game\n2. Change placce of the game\n0.  Back");
                Console.Write("Action: ");
                string choise = Console.ReadLine();
                Console.Clear();
                switch (choise)
                {

                    case "0":
                        return;
                    case "1":
                        try
                        {
                            Console.Write("Add city of the game: ");
                            string city = validator.validator_name(Console.ReadLine());
                            ges.AddPlaceofGame(city);
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Change place of game");
                            int index = IndexGames();
                            Console.WriteLine("Add new city of game");
                            string city = validator.validator_name(Console.ReadLine());
                            ges.ChangePlaceOfGame(city, index);
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    default:
                        Console.WriteLine("Wrong index\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void Visitors()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Visitors\n1. Add count of visitors\n2. Change count of visitors\n0.  Back");
                Console.Write("Action: ");
                string choise = Console.ReadLine();
                Console.Clear();
                switch (choise)
                {

                    case "0":
                        return;
                    case "1":
                        try
                        {
                            Console.WriteLine("Count of visitors < 100");
                            Console.Write("Add count of visitors: ");
                            var visitors = validator.validator_countplace(Console.ReadLine());
                            ges.AddCountofVisitors(Convert.ToInt32(visitors));
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Change count of visitors");
                            int index = IndexGames();
                            Console.WriteLine("Add new count of visitors");
                            var newvisitors = validator.validator_countplace(Console.ReadLine());
                            ges.ChangeCountOfVisitors(index, Convert.ToInt32(newvisitors));
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    default:
                        Console.WriteLine("Wrong index\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                }
            }
        }
        public void CountofGame()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Count of game\n1. Add count of count of game\n2. Change count of game\n0.  Back");
                Console.Write("Action: ");
                string choise = Console.ReadLine();
                Console.Clear();
                switch (choise)
                {

                    case "0":
                        return;
                    case "1":
                        try
                        {
                            Console.WriteLine("Result of game");
                            ges.AddCountofGame();

                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Change count of game");
                            int index = IndexGames();
                            ges.ChangeCountOfGame(index);
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    default:
                        Console.WriteLine("Wrong index\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void BDay()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("BDay\n1. Add day of birthday of player\n2. Change day of birthday of player\n0.  Back");
                Console.Write("Action: ");
                string choise = Console.ReadLine();
                Console.Clear();
                switch (choise)
                {

                    case "0":
                        return;
                    case "1":
                        try
                        {
                            Console.WriteLine("Add day of birthday");
                            var day = validator.validator_day(Console.ReadLine());
                            pls.AddBDay(Convert.ToInt32(day));

                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "2":
                        try
                        {
                            Console.Write("Change BDay of player: ");
                            var index = IndexPlayer();
                            Console.WriteLine("Add new BDay of player");
                            var day = validator.validator_day(Console.ReadLine());
                            pls.ChangeBDay(Convert.ToInt32(day), index);

                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    default:
                        Console.WriteLine("Wrong index\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                }
            }
        }
        public void Role()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Role\n1. Add role of player\n2. Change role of birthday of player\n0.  Back");
                Console.Write("Action: ");
                string choise = Console.ReadLine();
                Console.Clear();
                switch (choise)
                {

                    case "0":
                        return;
                    case "1":
                        try
                        {
                            Console.WriteLine("Add role of birthday");
                            string role =validator.validator_name(Console.ReadLine());
                            pls.AddRole(role);

                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "2":
                        try
                        {
                            Console.Write("Change role of player: ");
                            var index = IndexPlayer();
                            Console.WriteLine("Add new role of player");
                            string role = validator.validator_name(Console.ReadLine());
                            pls.ChangeRole(role, index);

                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    default:
                        Console.WriteLine("Wrong index\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void Health()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Heatlth\n1. Add health of player\n2. Change health of birthday of player\n0.  Back");
                Console.Write("Action: ");
                string choise = Console.ReadLine();
                Console.Clear();
                switch (choise)
                {

                    case "0":
                        return;
                    case "1":
                        try
                        {
                            
                            Console.WriteLine("Add health of birthday(good/bad....) : ");
                            string health =validator.validator_name(Console.ReadLine());
                            pls.AddHealth(health);

                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "2":
                        try
                        {
                            Console.Write("Change health of player: ");
                            var index = IndexPlayer();
                            Console.WriteLine("Add new health of player");
                            string health = validator.validator_name(Console.ReadLine());
                            pls.ChangeHealth(health, index);

                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    default:
                        Console.WriteLine("Wrong index\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void Salary()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Salary\n1. Add salary of player\n2. Change salary of birthday of player\n0.  Back");
                Console.Write("Action: ");
                string choise = Console.ReadLine();
                Console.Clear();
                switch (choise)
                {

                    case "0":
                        return;
                    case "1":
                        try
                        {
                            Console.WriteLine("Add salary of player (<10000)");
                            var salary = validator.validator_salary(Console.ReadLine());
                            pls.AddSalary(Convert.ToInt32(salary));

                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "2":
                        try
                        {
                            Console.Write("Change salry of player: ");
                            var index = IndexPlayer();
                            Console.WriteLine("Add new salary of player");
                            var newsalary = validator.validator_salary(Console.ReadLine());
                            pls.ChangeSalery(Convert.ToInt32(newsalary), index);
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    default:
                        Console.WriteLine("Wrong index\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void SearchStadium()
        {
            Console.WriteLine("Write name of a stadium");
            foreach (var a in Fts.SearchFootballStadia(Console.ReadLine()))
                Console.WriteLine(a);
            Console.ReadKey();

        }
        public void SerchGame()
        {
            Console.WriteLine("Write day of the game");
            foreach (var a in ges.SearchGame(Convert.ToInt32(Console.ReadLine())))
                Console.WriteLine(a);
            Console.ReadKey();
        }
        public void SearchPlayer()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Search\n1. Search for name \n2.  Search for surname\n0.  Back");
                Console.Write("Action: ");
                string choise = Console.ReadLine();
                Console.Clear();
                switch (choise)
                {

                    case "0":
                        return;
                    case "1":
                        try
                        {
                            Console.WriteLine("Write nane of a player");
                            foreach (var a in pls.SearchGameName(Console.ReadLine()))
                                Console.WriteLine(a);
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Write surnane of a player");
                            foreach (var a in pls.SearchGameSurnName(Console.ReadLine()))
                                Console.WriteLine(a);
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    default:
                        Console.WriteLine("Wrong index\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                }

            }
        }
        public void AddComandServ()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Comand\n1. Add comand \n2.  Add command for index\n0.  Back");
                Console.Write("Action: ");
                string choise = Console.ReadLine();
                Console.Clear();
                switch (choise)
                {

                    case "0":
                        return;
                    case "1":
                        try
                        {
                            Console.WriteLine("Write nane of first comand");
                            string namefirst =validator.validator_name(Console.ReadLine());
                            Console.WriteLine("Write nane of second comand");
                            string namesecond = validator.validator_name(Console.ReadLine());
                            Fts.AddComand(namefirst, namesecond);

                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "2":
                        try
                        {
                            
                            int index = IndexFootball();
                            Console.WriteLine("Write name of first comands");
                            string namefirst = validator.validator_name(Console.ReadLine());
                            Console.WriteLine("Write nane of second comand");
                            string namesecond = validator.validator_name(Console.ReadLine());
                            Fts.ChangeComad(index,namefirst, namesecond);
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    default:
                        Console.WriteLine("Wrong index\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                }

            }
        }
    }
}

