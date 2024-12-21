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
        private void ValidateDateOfBirth(DateTime value)
        {
            if (value >= DateTime.Today)
            {
                throw new ArgumentException("Дата рождения не может быть в будущем");
            }
        }

        //Создаю поля.
        /// <summary>
        /// Имя матери
        /// </summary>
        private string _motherName = "Неизвестно";
        /// <summary>
        /// Фамилия матери
        /// </summary>
        private string _motherSurname = "Неизвестно";
        /// <summary>
        /// Отчество матери
        /// </summary>
        private string _motherPatronymic = "Неизвестно";
        /// <summary>
        /// Номер телефона матери
        /// </summary>
        private string _motherPhoneNumber = "Неизвестно";
        /// <summary>
        /// Дата рождения матери
        /// </summary>
        private DateTime _motherDateOfBirth;
        /// <summary>
        /// Имя отца
        /// </summary>
        private string _fatherName = "Неизвестно";
        /// <summary>
        /// Фамилия отца
        /// </summary>
        private string _fatherSurname = "Неизвестно";
        /// <summary>
        /// Отчество отца
        /// </summary>
        private string _fatherPatronymic = "Неизвестно";
        /// <summary>
        /// Номер телефона отца
        /// </summary>
        private string _fatherPhoneNumber = "Неизвестно";
        /// <summary>
        /// Дата рождения отца
        /// </summary>
        private DateTime _fatherDateOfBirth;
        /// <summary>
        /// Наличие детей(да/нет)
        /// </summary>
        private bool _havingKids;

        // Создаю свойства.
        public string MotherName
        {
            get { return _motherName; }
            set
            {
                ValidateString(value);
                _motherName = value;
            }
        }

        public string MotherSurname
        {
            get { return _motherSurname; }
            set
            {
                ValidateString(value);
                _motherSurname = value;
            }
        }

        public string MotherPatronymic
        {
            get { return _motherPatronymic; }
            set
            {
                ValidateString(value);
                _motherPatronymic = value;
            }
        }

        public string MotherPhoneNumber
        {
            get { return _motherPhoneNumber; }
            set
            {
                ValidateString(value);
                _motherPhoneNumber = value;
            }
        }

        public string FatherName
        {
            get { return _fatherName; }
            set
            {
                ValidateString(value);
                _fatherName = value;
            }
        }

        public string FatherSurname
        {
            get { return _fatherSurname; }
            set
            {
                ValidateString(value);
                _fatherSurname = value;
            }
        }

        public string FatherPatronymic
        {
            get { return _fatherPatronymic; }
            set
            {
                ValidateString(value);
                _fatherPatronymic = value;
            }
        }

        public string FatherPhoneNumber
        {
            get { return _fatherPhoneNumber; }
            set
            {
                ValidateString(value);
                _fatherPhoneNumber = value;
            }
        }

        public DateTime MotherDateOfBirth
        {
            get { return _motherDateOfBirth; }

            set
            {
                ValidateDateOfBirth(value);
                _motherDateOfBirth = value;
            }
        }

        public DateTime FatherDateOfBirth
        {
            get { return _fatherDateOfBirth; }
            set
            {
                ValidateDateOfBirth(value);
                _fatherDateOfBirth = value;
            }
        }

        public bool HavingKids
        {
            get { return _havingKids; }
            set
            {
                _havingKids = value;
            }
        }

        public Family(

            string motherName,
            string motherSurname,
            string motherPatronymic,
            string motherPhoneNumber,

            string fatherName,
            string fatherSurname,
            string fatherPatronymic,
            string fatherPhoneNumber,

            bool havingKids = false,

            DateTime motherDateOfBirth = default,
            DateTime fatherDateOfBirth = default
            )// возможно стоит сюда добавить айди воркера, чтобы к нему конкретно привязалось всё это, аналогично с адресами.
        {
            MotherName = motherName;
            MotherSurname = motherSurname;
            MotherPatronymic = motherPatronymic;
            MotherPhoneNumber = motherPhoneNumber;
            FatherName = fatherName;
            FatherSurname = fatherSurname;
            FatherPatronymic = fatherPatronymic;
            FatherPhoneNumber = fatherPhoneNumber;
            HavingKids = havingKids;
            MotherDateOfBirth =   motherDateOfBirth;
            FatherDateOfBirth = fatherDateOfBirth;  


        }

    }






    public struct Workers
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
        /// Перегружаем методы для того, чтобы они проверяли больше ли значение или равно чем ноль.
        /// </summary>
        private void ValidatePositiveNumber(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Значение должно быть больше или равно нулю");
            }
        }

        private void ValidatePositiveNumber(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Значение должно быть больше или равно нулю");
            }
        }
        /// <summary>
        /// Проверяет, что дата рождения не является будущей или сегодняшней датой.
        /// </summary>
        /// <param name="value"> Дата рождения для проверки</param>
        /// <exception cref="ArgumentException"> Выбрасываеися, если дата рождения является будущей или сегодняшней датой</exception>

        private void ValidateDateOfBirth(DateTime value)
        {
            if (value > DateTime.Today)
            {
                throw new ArgumentException("Дата рождения не может быть в будущем");
            }
        }
       

        
        private string _firstName = "Неизвестно"; // создаю поля
        private string _surname = "Неизвестно";
        private string _patronymic = "Неизвестно";
        private string _phoneNumber = "Неизвестно";
        private string _post = "Неизвестно";
        private string _education = "Неизвестно";
        private string _email = "Неизвестно";


       




        private Addres _homeAdress;
        private DateTime _dateOfBirth;
        private DateTime _dateOfEnrollment;
        private int _workExp;
        private double _salary;
       

      

        /// <summary>
        /// конструктор для данной структуры. пока не знаю, что добавить можно в входные переменные. планирую добавить параметры по умолчанию.
        /// </summary>
        public Workers(
            string firstName,
            string surname,
            string patronymic,
            string phoneNumber = "Неизвестный номер",
            string post = "Неизвестная должность",
            string education = "Неизвестное образование",
            string email = "Неизвестная эл. почта",
            Addres homeAdress = default,
            DateTime dateOfBirth = default,
            DateTime dateOfEnrollment = default,
            int workExp = 0,
            double salary = 0.0)
        {
          
           
            FirstName = firstName;
            Surname = surname;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
            Post = post;
            Education = education;
            Email = email;

            HomeAdress = homeAdress.Equals(default(Addres)) == default ? new Addres() : homeAdress; // проверяет является ли значение равным значением по умолчанию.
            DateOfBirth = dateOfBirth;
            DateOfEnrollment = dateOfEnrollment == default ? DateTime.Today : dateOfEnrollment; // Если по умолчанию значение, то ставит сегодняшнюю дату

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
                ValidateString(value);// вызываем метод который проверяет на валидность строки
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
                if (value == null)
                {
                    value = "Неизвестный номер"; /// как же я люблю добавлять костыли
                }
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
                if (value == null)
                {
                    value = "Неизвестная должность"; /// как же я люблю добавлять костыли
                }
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
                if (value == null)
                {
                    value = "Неизвестное образование"; /// как же я люблю добавлять костыли
                }
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
                if (value == null)
                {
                    value = "Неизвестная эл. почта"; /// как же я люблю добавлять костыли
                }
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
                int age = today.Year - _dateOfBirth.Year;
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
                ValidatePositiveNumber(value);
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
                ValidatePositiveNumber(value);
                _salary = value;
            }
        }
    }
}
