using Tyuiu.ShmidtAA.Sprint7.Project.V11.Lib;
namespace Tyuiu.ShmidtAA.Sprint7.Project.V11.Test
{
    [TestClass]
    public class DataServiceTest
    {
        DataService ds = new DataService();

        /// <summary>
        /// �������� ����������� �� ������� � ������
        /// </summary>
        [TestMethod]
        public void CreateListWorkers_ShouldReturnNonEmptyList()
        {
            List<Workers> listWorkers = ds.CreateListWorkers();
            Assert.IsNotNull(listWorkers);
        }


        /// <summary>
        /// �������� ������������ ���������� ����������
        /// </summary>
        [TestMethod]
        public void AddWorker_ShouldAddWorker()
        {
            DataService ds = new DataService();
            List<Workers> ResultListWorkers = ds.CreateListWorkers();

            string firstName = "Andrei";
            string surname = "Shmidt";
            string patronymic = "Andreevich";
            string phoneNumber = "8999999999";
            string post = "Developer";
            string education = "TYUIU";
            string email = "eprst@mail.ru";
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
            Assert.IsTrue(areEqual);
            CollectionAssert.AreEqual(WaitListWorkers, ResultListWorkers);
        }
        //17.12.24
        // �������� �������� �� ������������ ���� ��� ���������� ����������� (������)
        // �������� �������� �� "�������������", �� ���� ���� ������� "���������� �� ���������"
        // �������� �������� �� ������  AddHomeAdressWorker .

   
        /// <summary>
        /// ����� �������� ������������ ���������� ����������, �� ������ �������� � � ����������� �������� �� ��������� � dateOfBirth � � ������ ��������. 
        /// </summary>
        [TestMethod]
        public void AddWorker_ShouldAddWorker2()
        {
            // Arrange
            string firstName = "Andrei";
            string surname = "Shmidt";
            string patronymic = "Andreevich";
            string phoneNumber = null;
            string post = "Developer";
            string education = "TYUIU";
            string email = "eprst@mail.ru";
            DateTime dateOfBirth = default;
            DateTime dateOfEnrollment = new DateTime(2024, 12, 17);
            int workExp = 1;
            double salary = 200000.00;

            // Act
            DataService ds = new DataService();
            List<Workers> ResultListWorkers = ds.CreateListWorkers();
            ResultListWorkers = ds.AddWorker(ResultListWorkers, firstName, surname, patronymic, phoneNumber, post, education, email, dateOfBirth, dateOfEnrollment, workExp, salary);

            Workers worker = ResultListWorkers[0];

            // Assert
            Assert.AreEqual(firstName, worker.FirstName);
            Assert.AreEqual(surname, worker.Surname);
            Assert.AreEqual(patronymic, worker.Patronymic);
            Assert.AreEqual("����������� �����", worker.PhoneNumber);
            Assert.AreEqual(post, worker.Post);
            Assert.AreEqual(education, worker.Education);
            Assert.AreEqual(email, worker.Email);
            Assert.AreEqual(default(DateTime), worker.DateOfBirth);
            Assert.AreEqual(dateOfEnrollment, worker.DateOfEnrollment);
            Assert.AreEqual(workExp, worker.WorkExp);
            Assert.AreEqual(salary, worker.Salary);
        }

        [TestMethod]
        public void AddWorker_ShouldAddWorker3()
        {
            // Arrange
            string firstName = "Andrei";
            string surname = "Shmidt";
            string patronymic = "Andreevich";
            string phoneNumber = null;
            string post = "Developer";
            string education = "TYUIU";
            string email = "eprst@mail.ru";
            DateTime dateOfBirth = default;
            DateTime dateOfEnrollment = new DateTime(2024, 12, 17);
            int workExp = 1;
            double salary = 200000.00;

            // Act
            DataService ds = new DataService();
            List<Workers> ResultListWorkers = ds.CreateListWorkers();
            ResultListWorkers = ds.AddWorker(ResultListWorkers, firstName, surname, patronymic);

            Workers worker = ResultListWorkers[0];

            // Assert
            Assert.AreEqual(firstName, worker.FirstName);
            Assert.AreEqual(surname, worker.Surname);
            Assert.AreEqual(patronymic, worker.Patronymic);
            Assert.AreEqual("����������", worker.PhoneNumber);
            Assert.AreEqual("����������", worker.Post);
            Assert.AreEqual("����������", worker.Education);
            Assert.AreEqual("����������", worker.Email);
            Assert.AreEqual(default(DateTime), worker.DateOfBirth);
            Assert.AreEqual(default(DateTime), worker.DateOfEnrollment); // ��� ������ ����� ������ ����, �� �����, ����� �� �������
            Assert.AreEqual(0, worker.WorkExp);
            Assert.AreEqual(0.0, worker.Salary);
        }

        /// <summary>
        /// ����� � �������� ����������� Workers �� �������� �� ���������.
        /// </summary>
        [TestMethod]
        public void DefaultParametersOfTheConstructorWorkers_ShouldGiveForDefaultValues()
        {
            // Arrange
            string firstName = "Andrei";
            string surname = "Shmidt";
            string patronymic = "Andreevich";

            // Act
            Workers worker = new Workers(firstName, surname, patronymic);

            // Assert
            Assert.AreEqual(firstName, worker.FirstName);
            Assert.AreEqual(surname, worker.Surname);
            Assert.AreEqual(patronymic, worker.Patronymic);
            Assert.AreEqual("����������� �����", worker.PhoneNumber);
            Assert.AreEqual("����������� ���������", worker.Post);
            Assert.AreEqual("����������� �����������", worker.Education);
            Assert.AreEqual("����������� ��. �����", worker.Email);
            Assert.AreEqual(default(DateTime), worker.DateOfBirth);
            Assert.AreEqual(DateTime.Today, worker.DateOfEnrollment);
            Assert.AreEqual(0, worker.WorkExp);
            Assert.AreEqual(0.0, worker.Salary);
        }

        [TestMethod]

        public void AddHomeAdressWorker_ShouldAddAdress()
        {
            // �������� Arrange
            string firstName = "Andrei";
            string surname = "Shmidt";
            string patronymic = "Andreevich";
            string city = "������";
            string street = "����������";
            int numberHouse = 34;
            int numberApartment = 72;

            // �������� Act 
            DataService ds = new DataService();
            List <Workers> workers = ds.CreateListWorkers();
            workers = ds.AddWorker(workers, firstName, surname, patronymic);
            workers = ds.AddHomeAdressWorker(workers, firstName,surname,patronymic,city,street,numberHouse,numberApartment);

            Workers worker = workers[0];

            // �������� Assert

            Assert.AreEqual(city,worker.HomeAdress.City);
            Assert.AreEqual(street,worker.HomeAdress.Street);
            Assert.AreEqual(numberHouse,worker.HomeAdress.NumberHouse);
            Assert.AreEqual(numberApartment,worker.HomeAdress.NumberApartment);
            



    }


    }
}