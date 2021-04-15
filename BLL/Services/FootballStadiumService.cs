using System;
using System.Collections.Generic;
using DAL.Entities;
using DataProvider;
using System.Collections;

namespace BLL.Services
{
    public class FootballStadiumService :IEnumerable<FootballStadium>
    {
        
        private readonly List<FootballStadium> footballStadia  = new List<FootballStadium>();
        private readonly IDataProvider<FootballStadium> serialization;

        public FootballStadiumService(IDataProvider<FootballStadium> dataProvider)
        {
            serialization =dataProvider;        
        }
        public FootballStadium this[int index]
        {
            get
            {
                return footballStadia[index];
            }
            set
            {
                footballStadia[index] = value;
            }
        }


        public void AddFoortballStadium(string name)
        {
            footballStadia.Add(new FootballStadium
            {
                Name = name
            });
        }
        public void ChangeFootballStadium(string name, int index)
        {
            if(index < 0 && index < footballStadia.Count)
            {
                throw new IndexOutOfRangeException("Wrong index");
            }
            footballStadia[index].Name = name;
        }
        public void DeleteStadium(int index)
        {
            if (index < 0 && index < footballStadia.Count)
            {
                throw new IndexOutOfRangeException("Wrong index");
            }
            footballStadia.RemoveAt(index);

        }
        public void AddCountOfPlace(int place)
        {
            footballStadia.Add(new FootballStadium
            {
                NumberofPlace = place
            });

        }
        public void ChangeCountofPlace(int index, int numberOfPlace)
        {
            if (index < 0 && index < footballStadia.Count)
            {
                throw new IndexOutOfRangeException("Wrong index");
            }
            footballStadia[index].NumberofPlace = numberOfPlace;
        }

        public void AddPriceofTicket(double price)=>            
            footballStadia.Add(new FootballStadium{PriceOfTicket = price});

        
        public void ChangePriceofTicket(int index, double price)
        {
            if (index < 0 && index < footballStadia.Count)
            {
                throw new IndexOutOfRangeException("Wrong index");
            }
            footballStadia[index].PriceOfTicket = price;
            
        }

        public void AddDayofGame(int day)=>     
            footballStadia.Add(new FootballStadium {DayoOfGame = day });
        
        public void ChangeDayofGame(int day, int index)
        {
            if (index < 0 && index < footballStadia.Count)
            {
                throw new IndexOutOfRangeException("Wrong index");
            }
            footballStadia[index].DayoOfGame = day;
        }
        public void AddComand(string nameofirstComand, string secondCommand)=>
            footballStadia.Add(new FootballStadium { NameofCommand = (nameofirstComand, secondCommand) });

          
            
          

        public void ChangeComad(int index, string nameofirstComand, string secondCommand)
        {
            if (index < 0 && index < footballStadia.Count)
            {
                throw new IndexOutOfRangeException("Wrong index");
            }
            footballStadia[index].NameofCommand = (nameofirstComand, secondCommand);
        }
        public List<FootballStadium> SearchFootballStadia(string name)
        {
            var temp = footballStadia.FindAll(x => x.Name == name);
            if (temp != null)
                return temp;
            else
            {
                throw new Exception("eror");
            }

        }
        public void Save()=>
            serialization.Write(footballStadia);
        

        public IEnumerator<FootballStadium> GetEnumerator()
        {
            return ((IEnumerable<FootballStadium>)footballStadia).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)footballStadia).GetEnumerator();
        }
    }
}
