using System;
using System.Text.RegularExpressions;

namespace PL
{
    class Validator
    {
        public string validator_name(string name)
        {
            if (Regex.IsMatch(name, "[a-z]"))
            {
                return name;
            }
            else
            {
                throw new Exception("invalid exception");
            }
        }
        public string validator_day(string day)
        {
            if (Regex.IsMatch(day, "(^[1-9]{1}$|^[1-2]{1}[0-9]{1}$|^30$)"))
            {
                return day;
            }
            else
            {
                throw new ArgumentException("Error");
            }
        }
        public string validator_countplace(string numberofPlace)
        {
            if (Regex.IsMatch(numberofPlace, "(^[1-9]{1}$|^[1-9]{1}[0-9]{1}$|^100$)"))
            {
                return numberofPlace;
            }
            else
            {
                throw new ArgumentException("Error");
            }
        }
        public string validator_priceofTicket(string price)
        {
            if (Regex.IsMatch(price, "(^[1-9]{1}$|^[1-9]{1}[0-9]{1}$|^100$)"))
            {
                return price;
            }
            else
            {
                throw new ArgumentException("Error");
            }
        }
        public string validator_salary(string salary)
        {
            if(Regex.IsMatch(salary, "([1-8][0-9]{3}|9[0-8][0-9]{2}|99[0-8][0-9]|999[0-9]|10000)"))
            {
                return salary;
            }
            else
            {
                throw new Exception("ERROR");
            }
        }
    }
}
