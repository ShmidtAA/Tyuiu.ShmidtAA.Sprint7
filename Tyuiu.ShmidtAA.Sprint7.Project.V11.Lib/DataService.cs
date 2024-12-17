namespace Tyuiu.ShmidtAA.Sprint7.Project.V11.Lib
{
    public class DataService
    {
        public List <Workers> CreateListWorkers()
        {
            return new List <Workers> ();
        }

        public List<Workers> AddWorker
            (
            List<Workers> listWorkers,
            string firstName,
            string surname,
            string patronymic,
            string phoneNumber,
            string post,
            string education,
            string email,
            DateTime dateOfBirth,
            DateTime dateOfEnrollment,
            int workExp,
            double salary
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
            int workerId,
            string city,
            string street,
            int numberHouse,
            int numberApartment
            )
        {
            Addres homeAddres = new Addres();
            homeAddres.City = city;
            homeAddres.Street = street;
            homeAddres.NumberHouse = numberHouse;
            homeAddres.NumberApartment = numberApartment;
             
            Workers worker = listWorkers.Find(w=> w.Id == workerId);
            worker.HomeAdress = homeAddres;
            return listWorkers;
        }

    }
}
