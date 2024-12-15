using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tyuiu.ShmidtAA.Sprint7.Project.V11.Lib
{
    public struct Family
    {

        /// <summary>
        /// Проверяет, что строка не является пустой или состоит только из пробелов
        /// </summary>
        /// <param name="value"> сама строчка </param> 
        /// <exception cref="ArgumentException">Выбрасывается, если строка пустая или в ней есть один пробел. </exception>
        private void ValidateString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Строка не может быть пустым.");
            }
        }


        /// <summary>
        /// Имя матери
        /// </summary>
        public string MotherName;

        /// <summary>
        /// Фамилия матери
        /// </summary>
        public string MotherSurname;

        /// <summary>
        /// Отчество матери
        /// </summary>
        public string MotherPatronymic;

        /// <summary>
        /// Номер телефона матери
        /// </summary>
        public string MotherPhoneNumber;

        /// <summary>
        /// Дата рождения матери
        /// </summary>
        public DateTime MotherDateOfBirth;

        /// <summary>
        /// Имя отца
        /// </summary>
        public string FatherName;

        /// <summary>
        /// Фамилия отца
        /// </summary>
        public string FatherSurname;

        /// <summary>
        /// Отчество отца
        /// </summary>
        public string FatherPatronymic;

        /// <summary>
        /// Номер телефона отца
        /// </summary>
        public string FatherPhoneNumber;

        /// <summary>
        /// Дата рождения отца
        /// </summary>
        public DateTime FatherDateOfBirth;

        /// <summary>
        /// Наличие детей(да/нет)
        /// </summary>
        public bool HavingKids;

    }

    public struct Workers
    {
        /// надо будет добавить проверки для остальных свойств.



        /// <summary>
        /// Проверяет, что строка не является пустой или состоит только из пробелов
        /// </summary>
        /// <param name="value"> сама строчка </param> 
        /// <exception cref="ArgumentException">Выбрасывается, если строка пустая или в ней есть один пробел. </exception>
        private void ValidateString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Строка не может быть пустым.");
            }
        }

        /// <summary>
        /// Проверяет, что дата рождения не является будущей или сегодняшней датой.
        /// </summary>
        /// <param name="value"> Дата рождения для проверки</param>
        /// <exception cref="ArgumentException"> Выбрасываеися, если дата рождения является будущей или сегодняшней датой</exception>

        private void ValidateDateOfBirth(DateTime value)
        {
            if (value >= DateTime.Today)
            {
                throw new ArgumentException("Дата рождения не может быть в будущем");
            }
        }

        private static int _nextId = 1; // счетчик для генерации уникальных ID
        private string _firstName; // создаю поля
        private string _surname;
        private string _patronymic;
        private string _phoneNumber;
        private string _post;
        private string _education;
        private string _email;

       
        private Addres _homeAdress;
        private DateTime _dateOfBirth;
        private DateTime _dateOfEnrollment;
        private int _workExp;
        private double _salary;

        public int Id { get; private set; } // уникальный индентификатор без возможности изменения извне 


        /// <summary>
        /// конструктор для данной структуры. пока не знаю, что добавить можно в входные переменные. планирую добавить параметры по умолчанию.
        /// </summary>
        public Workers(
            string firstName,
            string surname,
            string patronymic = "Неизвестно",
            string phoneNumber = "Неизвестно",
            string post = "Неизвестно",
            string education = "Неизвестно",
            string email = "Неизвестно",
            Addres homeAdress = default,
            DateTime dateOfBirth = default,
            DateTime dateOfEnrollment = default,
            int workExp  = 0,
            double salary = 0.0)
        {
            Id = _nextId++; // автоматическая генерация id
            _firstName = firstName;
            _surname = surname;
            _patronymic = patronymic;
            _phoneNumber = phoneNumber;
            _post = post;
            _education = education;
            _email = email;




            // Вызов свойств для валидации, но я чет сильно сомневаюсь в этом всём, надо уточнить процесс.
            FirstName = firstName;
            Surname = surname;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
            Post = post;
            Education = education;
            Email = email;

            HomeAdress = homeAdress.Equals(default(Addres)) == default ? new Addres() : homeAdress; // проверяет является ли значение равным значением по умолчанию.
            DateOfBirth = dateOfBirth == default ? DateTime.Today : dateOfBirth;
            DateOfEnrollment = dateOfEnrollment == default ? DateTime.Today : dateOfEnrollment;

            WorkExp = workExp;
            Salary = salary;


            


        }

        
        
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                //ValidateString(value);// вызываем метод который проверяет на валидность строки
                // если проверка не проходит, то срабатывает исключение и значение не задается в поле.
                _firstName = value;
            }
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname
        {
            get { return _surname; }
            set
            {
                ValidateString(value);
                _surname = value;
            }

        }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic
        {
            get { return _patronymic; }
            set
            {
                ValidateString(value);
                _patronymic = value;
            }
        }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                ValidateString(value);
                _phoneNumber = value;
            }
        }

        /// <summary>
        /// Должность
        /// </summary>
        public string Post
        {
            get { return _post; }
            set
            {
                ValidateString(value);
                _post = value;
            }
        }

        /// <summary>
        /// Образование
        /// </summary>
        public string Education
        {
            get { return _education; }
            set
            {
                ValidateString(value);
                _education = value;
            }
        }

        /// <summary>
        /// эл. почта
        /// </summary>
        public string Email
        {
            get { return _email; }
            set
            {
                ValidateString(value);
                _email = value;
            }
        }

        /// <summary>
        /// Возраст
        /// Здесь мы автоматические подсчитываем возраст, исходя из даты рождения
        /// </summary>
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age  = today.Year - _dateOfBirth.Year;
                if (_dateOfBirth.Date > today.AddYears(-age)) age--; // используется для корректировки возраста, если дата рождения в текущем году еще не наступила.
                return age;

            }
        }


        /// <summary>
        /// Домашний адрес
        /// </summary>
        public Addres HomeAdress
        {
            get { return _homeAdress; }
            set
            {
                _homeAdress = value;
            }

        }

       

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                ValidateDateOfBirth(value);
                _dateOfBirth = value;
            }
        }

        /// <summary>
        /// Дата зачисления
        /// </summary>
        public DateTime DateOfEnrollment
        {
            get { return _dateOfEnrollment; }
            set
            {
                _dateOfEnrollment = value;
            }
        }

     

        /// <summary>
        /// Опыт работы
        /// </summary>
        public int WorkExp
        {
            get { return _workExp; }
            set
            {
                _workExp = value;
            }
        }


      

        /// <summary>
        /// Оклад
        /// </summary>
        public double Salary
        {
            get { return _salary; }
            set
            {
                _salary = value;
            }
        }

      


       

    }
}
