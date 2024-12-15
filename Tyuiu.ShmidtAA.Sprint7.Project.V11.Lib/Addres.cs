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
        /// <summary>
        /// Название города
        /// </summary>
        public string City{ get; set; }


        /// <summary>
        /// Название улицы
        /// </summary>
        public string Street {  get; set; }

        /// <summary>
        /// Номер дома
        /// </summary>
        public int NumberHouse {  get; set; }

        /// <summary>
        /// Номер квартиры
        /// </summary>
        public int NumberApartment {  get; set; }

        public Addres(
            string city = "Неизвестно",
            string street = "Неизввестно",
            int numberHouse = 0,
            int numberApartment = 0
            )
        {
            City = city;
            Street = street;
            NumberHouse = numberHouse;
            NumberApartment = numberApartment;
        }
    }
}
