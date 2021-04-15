using System;
using System.Collections.Generic;


namespace DAL.Entities
{
    [Serializable]
    public class Games
    {
        public List<Player> Players { get; set; } = new List<Player>();
        public string Name { get; set; }
        public int CountVisitors { get; set; }
        public int[] CountOfGame { get; set; } = new int[2];
        public string CityOfGame { get; set; }

        public int Day { get; set; }
        public override string ToString()
        {
            return "Day of the game: " + Day+ ". And name of this game is: " + Name;
        }

    }
}
