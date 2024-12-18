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
        // добавить проверку на "неизвестность", то есть хочу увидеть "парамаетры по умолчанию"
        // добавить проверку на метода  AddHomeAdressWorker .

        [TestMethod]

        public void AddWorker_CorrectId()
        {
            DataService ds  = new DataService();
            List<Workers> workers = ds.CreateListWorkers();
            workers = ds.AddWorker(workers, "Andrei", "Shmidt", "Andreevich");
            workers = ds.AddWorker(workers, "Denis", "Burko", "Sergeevich");
            int waitCorrectIdWorker1 = 1;
            int waitCorrectIdWorker2 = 2;
            Workers worker1 = workers[0];
            Workers worker2 = workers[1];
            int resultIdWorker1 = worker1.Id;
            int resultIdWorker2 = worker2.Id;
            
            Assert.AreEqual( waitCorrectIdWorker1, resultIdWorker1);
            //Assert.AreEqual ( waitCorrectIdWorker2, resultIdWorker2);
                    
            
        }

    }
}