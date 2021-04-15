using System;


namespace DAL.Entities
{
    [Serializable]
    public class Player
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int BDay { get; set; }
        public string Role { get; set; }
        public string Health { get; set; }
        public double Salary { get; set; }
        public override string ToString()
        {
            return "Name of the player: " + Name + ". Surname of the player: " + Surname;
        }

    }
}
