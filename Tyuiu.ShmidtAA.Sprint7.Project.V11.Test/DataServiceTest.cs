using System.Net;
using Tyuiu.ShmidtAA.Sprint7.Project.V11.Lib;
namespace Tyuiu.ShmidtAA.Sprint7.Project.V11.Test
{
    [TestClass]
    public class DataServiceTest
    {
        

        /// <summary>
        /// �������� ����������� �� ������� � ������
        /// </summary>
        [TestMethod]
        public void CreateListWorkers_ShouldReturnNonEmptyList()
        {
            List<Workers> listWorkers = DataService.CreateListWorkers();
            Assert.IsNotNull(listWorkers);
        }


        /// <summary>
        /// �������� ������������ ���������� ����������
        /// </summary>
        [TestMethod]
        public void AddWorker_ShouldAddWorker()
        {
            DataService ds = new DataService();
            List<Workers> ResultListWorkers = DataService.CreateListWorkers();

            string firstName = "Andrei";
            string surname = "Shmidt";
            string patronymic = "Andreevich";
            string phoneNumber = "8999999999";
            string post = "Developer";
            string education = "TYUIU";
            string email = "eprst@mail.ru";
            DateTime dateOfBirth = new DateTime(2004, 04, 04);
            DateTime dateOfEnrollment = new DateTime(2024, 12, 17);
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
            List<Workers> ResultListWorkers = DataService.CreateListWorkers();
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


            // Act
            DataService ds = new DataService();
            List<Workers> ResultListWorkers = DataService.CreateListWorkers();
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

        /// <summary>
        /// �������� ����������� ������ � ���������
        /// </summary>
        [TestMethod]

        public void AddHomeAdressWorker_ShouldAddAdress()
        {
            // ���������� Arrange
            string firstName = "Andrei";
            string surname = "Shmidt";
            string patronymic = "Andreevich";
            string city = "������";
            string street = "����������";
            int numberHouse = 34;
            int numberApartment = 72;

            DataService ds = new DataService();
            List<Workers> workers = DataService.CreateListWorkers();
            workers = ds.AddWorker(workers, "firstName", "surname", "patronymic");
            workers = ds.AddWorker(workers, firstName, surname, patronymic);

            Workers worker = ds.FindWorker(workers, firstName, surname, patronymic); // ������� ������ ��� ���������
            int index = workers.FindIndex(w => w.Equals(worker)); // ������� ������ ��� ������ ����� ����������
             
            // �������� Act 

            worker = ds.AddHomeAdressWorker(worker, city, street, numberHouse, numberApartment);
            workers[index] = worker; //����� ������ ������� �� �������� � �������.

            // �������� Assert

            Assert.AreEqual(city, worker.HomeAdress.City);
            Assert.AreEqual(street, worker.HomeAdress.Street);
            Assert.AreEqual(numberHouse, worker.HomeAdress.NumberHouse);
            Assert.AreEqual(numberApartment, worker.HomeAdress.NumberApartment);

            Assert.AreEqual(city, workers[index].HomeAdress.City);
            Assert.AreEqual(street, workers[index].HomeAdress.Street);
            Assert.AreEqual(numberHouse, workers[index].HomeAdress.NumberHouse);
            Assert.AreEqual(numberApartment, workers[index].HomeAdress.NumberApartment);
        }

        [TestMethod]
        public void AddFamilyWorker_ShouldAddFamily()
        {
            //Arrange

            string firstName = "Andrei";
            string surname = "Shmidt";
            string patronymic = "Andreevich";

            string motherName = "Wanda";
            string motherSurname = "Ventham";
            string motherPatronymic = "Cumberbatch"; // � ������������ ������� �������� �� ������������, ������� ��� ����� �������
            string motherPhoneNumber = "+44 123 456 7890";

            string fatherName = "Timothy";
            string fatherSurname = "Carlton";
            string fatherPatronymic = "Cumberbatch"; // ����������, ������� ������ ��������
            string fatherPhoneNumber = "+44 098 765 4321";

            bool havingKids = true; // �������� ���������� ����� �����

            DateTime motherDateOfBirth = new DateTime(1949, 11, 18); // ��������� ���� ��������
            DateTime fatherDateOfBirth = new DateTime(1939, 10, 1); // ��������� ���� ��������

            DataService ds = new DataService();
            List<Workers> workers = DataService.CreateListWorkers();
            workers = ds.AddWorker(workers, "firstName", "surname", "patronymic");
            workers = ds.AddWorker(workers, firstName, surname, patronymic);

            Workers worker = ds.FindWorker(workers, firstName, surname, patronymic); // ������� ������ ��� ���������
            int index = workers.FindIndex(w => w.Equals(worker)); // ������� ������ ��� ������ ����� ����������
            
            //Act

            worker = ds.AddFamilyWorker(worker, motherName, motherSurname, motherPatronymic, motherPhoneNumber,fatherName, 
                fatherSurname, fatherPatronymic, fatherPhoneNumber,havingKids,motherDateOfBirth, fatherDateOfBirth);

            workers[index] = worker;

            //Assert

            Assert.AreEqual(motherName, workers[index].Family.MotherName);
            Assert.AreEqual(motherSurname, workers[index].Family.MotherSurname);
            Assert.AreEqual(motherPatronymic, workers[index].Family.MotherPatronymic);
            Assert.AreEqual(motherPhoneNumber, workers[index].Family.MotherPhoneNumber);
            Assert.AreEqual(fatherName, workers[index].Family.FatherName);
            Assert.AreEqual(fatherSurname, workers[index].Family.FatherSurname);
            Assert.AreEqual(fatherPatronymic, workers[index].Family.FatherPatronymic);
            Assert.AreEqual(fatherPhoneNumber, workers[index].Family.FatherPhoneNumber);
            Assert.AreEqual(havingKids, workers[index].Family.HavingKids);
            Assert.AreEqual(motherDateOfBirth, workers[index].Family.MotherDateOfBirth);
            Assert.AreEqual(fatherDateOfBirth, workers[index].Family.FatherDateOfBirth);

        }

        [TestMethod]
        public void SortBySalaryDescending_ShouldListBySalaryDescending()
        {
            //Arrange
            DataService ds = new DataService();
            List<Workers> workers = DataService.CreateListWorkers();

            ds.AddWorker(workers, "����", "������", "��������", salary: 45000);
            ds.AddWorker(workers, "����", "������", "��������", salary: 52000);
            ds.AddWorker(workers, "������", "�������", "���������", salary: 48000);
            ds.AddWorker(workers, "�������", "��������", "����������", salary: 30000);
            ds.AddWorker(workers, "�������", "��������", "����������", salary: 70000);



            //Act
            workers = DataService.SortBySalaryDescending(workers);


            //Assert

            Assert.AreEqual("�������", workers[0].FirstName);
            Assert.AreEqual("����", workers[1].FirstName);
            Assert.AreEqual("������", workers[2].FirstName);
            Assert.AreEqual("����", workers[3].FirstName);
        }
        [TestMethod]
        public void SortByAgeDescending_ShouldListByAgeDescending()
        {
            //Arrange
            DataService ds = new DataService();
            List<Workers> workers = DataService.CreateListWorkers();

            ds.AddWorker(workers, "����", "������", "��������", dateOfBirth: new DateTime(2004, 10, 1));
            ds.AddWorker(workers, "����", "������", "��������", dateOfBirth: new DateTime(1949, 10, 1));
            ds.AddWorker(workers, "������", "�������", "���������", dateOfBirth: new DateTime(1949, 11, 1));
            ds.AddWorker(workers, "�������", "��������", "����������", dateOfBirth: new DateTime(2004, 10, 2));
            ds.AddWorker(workers, "�������", "��������", "����������", dateOfBirth: new DateTime(1939, 10, 1));

            //Act
            workers = DataService.SortByAgeDescending(workers);

            //Assert
            Assert.AreEqual("�������", workers[0].FirstName);
            Assert.AreEqual("����", workers[1].FirstName);
            Assert.AreEqual("������", workers[2].FirstName);
            Assert.AreEqual("����", workers[3].FirstName);
           
        }





    }
}