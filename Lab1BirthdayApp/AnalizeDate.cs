using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KMA.ProgrammingInCSharp2023
{
    public class AnalizeDate
    {
        #region Fields
        private DateTime _birthDate;
        private int _age;
        #endregion

        public AnalizeDate(DateTime birthDate)
        {
            this._birthDate = birthDate;
            this._age = GetAge();

        }
    
        public int GetAge()
        {
            var currentDate = DateTime.Today;

            int age = currentDate.Year - _birthDate.Year;

            if (_birthDate > currentDate.AddYears(-age))
                age--;

            return age;
        }

        public bool IsValidAge()
        {
            return (_age >= 0 && _age <= 135);
        }

       
        public bool IsBirthday()
        {
            return (_birthDate.Month == DateTime.Today.Month && _birthDate.Day == DateTime.Today.Day);
           
        }

        public string GetWesternSign()
        {

            var day = _birthDate.Day;
            var month = _birthDate.Month;

            switch (month)
            {
                case 1: 
                    return day <= 20 ? "Capricorn" : "Aquarius";
                case 2: 
                    return day <= 19 ? "Aquarius" : "Pisces";
                case 3: 
                    return day <= 20 ? "Pisces" : "Aries";
                case 4: 
                    return day <= 20 ? "Aries" : "Taurus";
                case 5: 
                    return day <= 21 ? "Taurus" : "Gemini";
                case 6: 
                    return day <= 21 ? "Gemini" : "Cancer";
                case 7:
                    return day <= 22 ? "Cancer" : "Leo";
                case 8:
                    return day <= 23 ? "Leo" : "Virgo";
                case 9:
                    return day <= 23 ? "Virgo" : "Libra";
                case 10:
                    return day <= 23 ? "Libra" : "Scorpio";
                case 11:
                    return day <= 22 ? "Scorpio" : "Sagittarius";
                case 12:
                    return day <= 21 ? "Sagittarius" : "Capricorn";
                default:
                    throw new ArgumentException("Invalid birth month.");
            }
        }

        public string GetChineseSign()
        {
            string[] zodiacSigns = { "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Sheep" };
            int zodiacIndex = _birthDate.Year % 12;
            return zodiacSigns[zodiacIndex];
        }
    }
}
