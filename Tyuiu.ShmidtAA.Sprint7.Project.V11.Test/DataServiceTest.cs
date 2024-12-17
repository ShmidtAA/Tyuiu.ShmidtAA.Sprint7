using Tyuiu.ShmidtAA.Sprint7.Project.V11.Lib;
namespace Tyuiu.ShmidtAA.Sprint7.Project.V11.Test
{
    [TestClass]
    public class DataServiceTest
    {
        DataService ds = new DataService();

        
        [TestMethod]
        public void CreateListWorkers_ShouldReturnNonEmptyList()
        {
            List<Workers> listWorkers = ds.CreateListWorkers();
            Assert.IsNotNull(listWorkers);
        }

        [TestMethod]
        
        public void AddWorker_ShouldAddWorker()
        {
            DataService ds = new DataService();
            List<Workers> ResultListWorkers = ds.CreateListWorkers();

            string firstName = "Andrei";
            string surname = "Shmidt";
            string patronymic = "Andreevich";
            string phoneNumber = "89523488797";
            string post = "Developer";
            string education = "TYUIU";
            string email = "mrcony.shmidt@mail.ru";
            DateTime dateOfBirth = new DateTime(2004,04,04);
            DateTime dateOfEnrollment = new DateTime(2024,12,17);
            int workExp = 1;
            double salary = 200000.00;

            ResultListWorkers = ds.AddWorker(ResultListWorkers, firstName, surname, patronymic, phoneNumber, post, education, email, dateOfBirth, dateOfEnrollment, workExp, salary);

            List<Workers> WaitListWorkers = new List<Workers>();

            WaitListWorkers.Add(new Workers
            {
                FirstName = firstName,
                Surname = surname,
                Patronymic = patronymic,
                PhoneNumber = phoneNumber,
                Post = post,
                Education = education,
                Email = email,
                DateOfBirth = dateOfBirth,
                DateOfEnrollment = dateOfEnrollment,
                WorkExp = workExp,
                Salary = salary
            }
                );

            bool areEqual = ResultListWorkers.SequenceEqual(WaitListWorkers);
            Assert.IsTrue( areEqual );
            CollectionAssert.AreEqual(WaitListWorkers, ResultListWorkers);
        }
        //17.12.24
        // добавить проверку на корректность айди при нескольких экземпл€ров 
        // добавить проверку на метода  AddHomeAdressWorker .

    }
}