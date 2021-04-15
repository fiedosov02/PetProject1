using System;
using System.Collections.Generic;
using DAL.Entities;
using System.Linq;
using DataProvider;
using System.Collections;

namespace BLL.Services
{
    public class GamesService : IEnumerable<Games>
    {
        private readonly List<Games> games = new List<Games>();
        private readonly IDataProvider<Games> prov;
        public GamesService(IDataProvider<Games> dataProvider)
        {
            prov = dataProvider;
           
        }

        public Games this[int index]
        {
            get
            {
                return games[index];
            }
            set
            {
                games[index] = value;
            }
        }
        public void AddGame(string name)
        {
            games.Add(new Games
            {
                Name = name
            });
        }
        public void ChangeGame(string name, int index)
        {
            if (index < 0 && index < games.Count)
            {
                throw new IndexOutOfRangeException("Wrong index");
            }
            games[index].Name = name;
        }
        public void DeleteGame(int index)
        {
            if (index < 0)
            {
                Console.WriteLine("EROOR");
            }
            games.RemoveAt(index);
        }
     
        public void AddPlayer(string name, string surname, int index)
        {
            if (index < 0 && index < games.Count)
            {
                throw new IndexOutOfRangeException("Wrong index");
            }
            games[index].Players.Add(new Player
            {
                Name = name,
                Surname = surname
            });
        }
        public void DeletePlayer(int index)
        {
            if (index < 0 && index < games.Count)
            {
                throw new IndexOutOfRangeException("Wrong index");
            }
            games[index].Players.RemoveAt(index);
        }
        public void AddTimeofGame(int time)
        {
            if(time< 0)
            {

                Console.WriteLine("ERROR");
            }
            games.Add(new Games
            { 
            Day = time
            });
        }
        public void ChangeTimeOfGame(int day, int index)
        {
            if (index < 0 && index < games.Count)
            {
                throw new IndexOutOfRangeException("Wrong index");
            }
            games[index].Day = day;
        }
        public void AddPlaceofGame(string city)
        {
           
            games.Add(new Games
            {
                CityOfGame = city
            });
        }
        public void ChangePlaceOfGame(string city, int index)
        {
            if (index < 0 && index < games.Count)
            {
                throw new IndexOutOfRangeException("Wrong index");
            }
            games[index].CityOfGame = city;
        }
        public void AddCountofVisitors(int count)
        {
          
            games.Add(new Games
            {
                CountVisitors = count
            });
        }
        public void ChangeCountOfVisitors(int index, int visitors)
        {
            if (index < 0 && index < games.Count)
            {
                throw new IndexOutOfRangeException("Wrong index");
            }
            games[index].CountVisitors = visitors;
        }
        public void AddCountofGame()
        {
            
     
            Random re = new Random();
            int first = re.Next(0, 5);
            int second = re.Next(0, 5);
            int[] mas = new int[] { first, second };
            Console.WriteLine("Count of the game: " + mas[0]+":"+mas[1]);
            games.Add(new Games
            {
                CountOfGame = mas
            });
             
        }
        public void ChangeCountOfGame(int index)
        {
            if (index < 0 && index < games.Count)
            {
                throw new IndexOutOfRangeException("Wrong index");
            }
            Random re = new Random();
            int first = re.Next(1, 5);
            int second = re.Next(1, 7);
            int[] count = new int[] { first, second };
            games[index].CountOfGame[0] = count[0];
            games[index].CountOfGame[1] = count[1];
        }

        public void Sort()
        {
            var sort = from i in games
                       orderby i.Day
                       select i;
            foreach (Games i in sort)
            {
                Console.WriteLine("Game: " + i.Name+". Day"+  i.Day);
            }
            Console.ReadKey();
        }

        public void SortFour(int index)
        {
            if (games[index].CountOfGame[0] > games[index].CountOfGame[1])
            {
                Console.WriteLine("First command WIN");
                Console.WriteLine(games[index].CountOfGame[0] + games[index].CountOfGame[1]);
            }
            else if (games[index].CountOfGame[0] < games[index].CountOfGame[1])
            {
                Console.WriteLine("first command LOOSE");
                Console.WriteLine(games[index].CountOfGame[0] + games[index].CountOfGame[1]);
            }
            else if (games[index].CountOfGame[0] == games[index].CountOfGame[1])
            {
                Console.WriteLine("50/50");
                Console.WriteLine(games[index].CountOfGame[0] + games[index].CountOfGame[1]);
            }
            else
            {
                Console.WriteLine("Will be in the future");
            }
            Console.ReadKey();
        }
        public List<Games> SearchGame(int day)
        {
            var temp = games.FindAll(x => x.Day == day);
            if (temp != null)
                return temp;
            else
            {
                throw new Exception("eror");
            }

        }
        public void Save()
        {
            prov.Write(games);
        }

        public IEnumerator<Games> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
