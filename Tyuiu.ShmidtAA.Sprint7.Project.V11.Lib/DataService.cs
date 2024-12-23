namespace Tyuiu.ShmidtAA.Sprint7.Project.V11.Lib
{
    public class DataService
    {
        public static List<Workers> CreateListWorkers()
        {
            return new List<Workers>();
        }

        /// <summary>
        /// Возвращает лист с добавлением одного работника
        /// Не убирай параметры по умолчанию.
        /// </summary>
        /// <param name="listWorkers"></param>
        /// <param name="firstName"></param>
        /// <param name="surname"></param>
        /// <param name="patronymic"></param>
        /// <param name="phoneNumber">"</param>
        /// <param name="post"></param>
        /// <param name="education"></param>
        /// <param name="email"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="dateOfEnrollment"></param>
        /// <param name="workExp"></param>
        /// <param name="salary"></param>
        /// <returns></returns>
        public List<Workers> AddWorker
            (
            List<Workers> listWorkers,
            string firstName,
            string surname,
            string patronymic,
            string phoneNumber = "Неизвестно",
            string post = "Неизвестно",
            string education = "Неизвестно",
            string email = "Неизвестно",
            DateTime dateOfBirth = default,
            DateTime dateOfEnrollment = default,
            int workExp = 0,
            double salary = 0.0
            )
        {
            try
            {
                Workers worker = new Workers();
                worker.FirstName = firstName;
                worker.Surname = surname;
                worker.Patronymic = patronymic;
                worker.PhoneNumber = phoneNumber;
                worker.Post = post;
                worker.Education = education;
                worker.Email = email;
                worker.DateOfBirth = dateOfBirth;
                worker.DateOfEnrollment = dateOfEnrollment;
                worker.WorkExp = workExp;
                worker.Salary = salary;
                listWorkers.Add(worker);
            }
            catch 
            {
                throw new Exception("Ошибка при добавлении работника в динам. массив");            
            }
            return listWorkers;
        }


        public Workers AddHomeAdressWorker
            (
            Workers worker,
            string city,
            string street,
            int numberHouse,
            int numberApartment
            )
        {
            try
            {
                Addres homeAddres = new Addres();
                homeAddres.City = city;
                homeAddres.Street = street;
                homeAddres.NumberHouse = numberHouse;
                homeAddres.NumberApartment = numberApartment;

                worker.HomeAdress = homeAddres;
            }
            catch
            {
                throw new Exception("Ошибка при добавлении адреса к работнику");
            }
            return worker;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workers"></param>
        /// <exception cref="ArgumentException"></exception>
        private static void ValidateWorkersList(List<Workers> workers)
        {
            if (workers == null || workers.Count == 0)
            {
                throw new ArgumentException("Список работников не должен быть пустым.");
            }
        }


        public Workers FindWorker(List<Workers> workersList, string workerName, string workerSurname, string workerPatronymic)
        {
            Workers worker = new Workers();
            try
            {
                
            ValidateWorkersList(workersList);
            worker = workersList.Find(w => w.FirstName == workerName && w.Surname == workerSurname && w.Patronymic == workerPatronymic);// поиск сотрудника по ФИО.
            }
            catch
            {
                throw new Exception("Ошибка при поиске нужного сотрудника.");
            }
            return worker;
        }
        public Workers AddFamilyWorker
           (
            Workers worker,
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
            )
        {
            try
            {
                Family family = new Family();
                family.MotherName = motherName;
                family.MotherSurname = motherSurname;
                family.MotherPatronymic = motherPatronymic;
                family.MotherPhoneNumber = motherPhoneNumber;

                family.FatherName = fatherName;
                family.FatherSurname = fatherSurname;
                family.FatherPatronymic = fatherPatronymic;
                family.FatherPhoneNumber = fatherPhoneNumber;

                family.HavingKids = havingKids;

                family.MotherDateOfBirth = motherDateOfBirth;
                family.FatherDateOfBirth = fatherDateOfBirth;

                worker.Family = family;
                
            }
            catch
            {
                throw new Exception("Ошибка при добавлении семьи к работнику");
            }
            return worker;
        }



        /// <summary>
        /// Сортирует список работников по зарплате в порядке убывания.
        /// </summary>
        /// <param name="workers">Список работников</param>
        /// <returns>Отсортированный список работников</returns>
        public static List<Workers> SortBySalaryDescending(List<Workers> workers)
        {
            try
            {
                ValidateWorkersList(workers);

                workers = workers.OrderByDescending(worker => worker.Salary).ToList();
            }

            catch 
            {
             throw new Exception("Ошибка при сортировке по заработной плате.");
            } 
            
                return workers;
        }

        /// <summary>
        /// Сортирует список работников по возрасту в порядке убывания.
        /// </summary>
        /// <param name="workers">Список работников</param>
        /// <returns>Отсортированный список работников</returns>
        public static List<Workers> SortByAgeDescending(List<Workers> workers)
        {
            try
            {
                ValidateWorkersList(workers);
                workers = workers.OrderByDescending(worker => worker.Age).ToList();
            }
            catch
            {
                throw new Exception("Ошибка при сортировке возраста по убыванию.");
            }
            return workers;
        }

        /// <summary>
        /// Сортирует список работников по фамилии в алфавитном порядке.
        /// </summary>
        /// <param name="workers"></param>
        /// <returns></returns>
        public static List<Workers> SortBySurname (List<Workers> workers)
        {
            try 
            {
                ValidateWorkersList(workers);

                // Метод Sort используется для сортировки списка workers "на месте".
                // Лямбда-выражение задает способ сравнения двух объектов Workers.
                // Здесь мы сравниваем поле Surname у двух работников.
                // Используем string.Compare для строгого (Ordinal) побайтового сравнения строк.
                // StringComparison.Ordinal выполняет сравнение на основе кодов символов Unicode без учета культуры, то здесь сравнивает по алфавиту, там А самое наим. по знач.
                workers.Sort((worker1, worker2) => string.Compare(worker1.Surname, worker2.Surname, StringComparison.Ordinal));
            }
            catch
            {
                throw new Exception("Ошибка при сортировке по фамилии в алфавитном порядке.");
            }

            return workers;
        }
    }
}
