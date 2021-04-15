using System;
using System.Collections.Generic;
using DAL.Entities;
using DataProvider;
using System.Collections;

namespace BLL.Services
{
    public class PlayerService : IEnumerable<Player>
    {
        private readonly List<Player> players = new List<Player>();
        private readonly IDataProvider<Player> prov;
     
        public PlayerService(IDataProvider<Player> dataProvider)
        {

            prov = dataProvider;

        }
        public Player this[int index]
        {
            get
            {
                return players[index];
            }
            set
            {
                players[index] = value;
            }
        }

        public void AddPlayer(string name, string surname)
        {
            players.Add(new Player
            {
                Name = name,
                Surname = surname
            });
        }
        public void ChangeNamePlayer(string name, string surname, int index)
        {
            if (index < 0 && index < players.Count)
            {
                throw new IndexOutOfRangeException("Wrong index");
            }
            players[index].Name = name;
            players[index].Surname = surname;
        }
        public void DeletePlayer(int index)
        {
            if (index < 0 && index < players.Count)
            {
                throw new IndexOutOfRangeException("Wrong index");
            }
            players.RemoveAt(index);
        }
        public void ChangeName(string name, int index)
        {
            if (index < 0 && index < players.Count)
            {
                throw new IndexOutOfRangeException("Wrong index");
            }
            players[index].Name = name;
        }
        public void ChangeSurname(string surname, int index)
        {
            if (index < 0 && index < players.Count)
            {
                throw new IndexOutOfRangeException("Wrong index");
            }
            players[index].Surname = surname;
        }
        public void AddBDay(int day)
        {
           
            players.Add(new Player { BDay = day });
        }
        public void ChangeBDay(int day, int index)
        {
            if (index < 0 && index < players.Count)
            {
                throw new IndexOutOfRangeException("Wrong index");
            }
            players[index].BDay = day;
        }
        public void AddRole(string role)
        {
            
            players.Add(new Player { Role = role });
        }
        public void ChangeRole(string role, int index)
        {
            if (index < 0 && index < players.Count)
            {
                throw new IndexOutOfRangeException("Wrong index");
            }
            players[index].Role = role;
        }
        public void AddHealth(string health)
        {
            
            players.Add(new Player { Health = health });
        }
        public void ChangeHealth(string health, int index)
        {
            if (index < 0 && index < players.Count)
            {
                throw new IndexOutOfRangeException("Wrong index");
            }
            players[index].Health = health;
        }
        public void AddSalary(int salary)
        {
            
            players.Add(new Player { Salary = salary });
        }
        public void ChangeSalery(int salary, int index)
        {
            if (index < 0 && index < players.Count)
            {
                throw new IndexOutOfRangeException("Wrong index");
            }
            players[index].Salary = salary;
        }
        public List<Player> SearchGameName(string name)
        {
            var temp = players.FindAll(x => x.Name == name);
            if (temp != null)
                return temp;

            else
            {
                throw new Exception("EROOR");
            }
        

        }
        public List<Player> SearchGameSurnName(string surname)
        {
            var temp = players.FindAll(x => x.Surname == surname);
            if (temp != null)
                return temp;

            else
            {
                throw new Exception("EROOR");
            }


        }
        public void Save()
        {
            prov.Write(players);
        }

        public IEnumerator<Player> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
