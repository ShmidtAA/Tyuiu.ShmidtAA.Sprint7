namespace Tyuiu.ShmidtAA.Sprint7.Project.V11.Lib
{
    public class DataService
    {
        public List <Workers> CreateListWorkers()
        {
            return new List <Workers> ();
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
        

        public List<Workers> AddHomeAdressWorker 
            (
            List<Workers> listWorkers,
            string workerName,
            string workerSurname,
            string workerPatronymic,
            string city,
            string street,
            int numberHouse,
            int numberApartment
            )
        {
           try 
            {
                //Addres homeAddres = new Addres();
                //homeAddres.City = city;
                //homeAddres.Street = street;
                //homeAddres.NumberHouse = numberHouse;
                //homeAddres.NumberApartment = numberApartment;

                Addres homeAddres = new Addres(city, street, numberHouse, numberApartment);
                
                Workers worker = listWorkers.Find(w=> w.FirstName == workerName && w.Surname == workerSurname && w.Patronymic == workerPatronymic);// поиск сотрудника.
                
              
                worker.HomeAdress = homeAddres;
                
            }
            catch
            {
                throw new ArgumentException("Ошибка при добавлении адреса к работнику");
            }
            return listWorkers;
        }



    }
}
