using System;


namespace DAL.Entities
{
    [Serializable]
    public class FootballStadium
    {
        public string Name { get; set; }
        public int NumberofPlace { get; set; }
        public double PriceOfTicket { get; set; }
        public int DayoOfGame { get; set; }

        public (string first, string second) NameofCommand { get; set; }
        
        public override string ToString()
        {
            return "Name of Stadium: " + Name;
        }


    }
}
