using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyuiu.ShmidtAA.Sprint7.Project.V11.Lib
{
    public struct Addres
    {
        private void ValidateString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Строка не может быть пустым.");
            }
        }

        private void ValidatePositiveNumber(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Значение должно быть больше нуля");
            }
        }



        private string _city = "Неизвестно";
        private string _street = "Неизвестно";
        private int _numberHouse = 0;
        private int _numberApartment = 0;


        /// <summary>
        /// Название города
        /// </summary>
        public string City 
        {
            get { return _city; }

            set
            {
                ValidateString(value);
                _city = value;
            } 
        
        }


        /// <summary>
        /// Название улицы
        /// </summary>
        public string Street 
        {  
            get { return _street; }
            set
            {
                ValidateString(value);
                _street = value;
            }
        }

        /// <summary>
        /// Номер дома
        /// </summary>
        public int NumberHouse
        {
            get { return _numberHouse; }
            set
            {
                ValidatePositiveNumber(value);
                _numberHouse = value;
            }

        }

        /// <summary>
        /// Номер квартиры
        /// </summary>
        public int NumberApartment
        {
            get { return _numberApartment; }
            set
            {
                ValidatePositiveNumber(value);
                _numberApartment = value;
            }
        }

        public Addres(
            string city,
            string street,
            int numberHouse,
            int numberApartment
            )
        {
            City = city;
            Street = street;
            NumberHouse = numberHouse;
            NumberApartment = numberApartment;

           
        }
    }
}
