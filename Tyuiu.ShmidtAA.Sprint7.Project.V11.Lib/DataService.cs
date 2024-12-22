namespace Tyuiu.ShmidtAA.Sprint7.Project.V11.Lib
{
    public class DataService
    {
        public List<Workers> CreateListWorkers()
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
                throw new ArgumentException("Ошибка при добавлении адреса к работнику");
            }
            return worker;
        }
        public Workers FindWorker(List<Workers> workersList, string workerName, string workerSurname, string workerPatronymic)
        {
            Workers worker = workersList.Find(w => w.FirstName == workerName && w.Surname == workerSurname && w.Patronymic == workerPatronymic);// поиск сотрудника по ФИО.
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
                throw new ArgumentException("Ошибка при добавлении семьи к работнику");
            }
            return worker;
        }

    }
}
