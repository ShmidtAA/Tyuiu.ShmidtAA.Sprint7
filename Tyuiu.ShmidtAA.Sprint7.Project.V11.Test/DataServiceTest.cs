using Newtonsoft.Json.Bson;
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

            //������ ����� ���������� ������ ����������, � ������� �� ��������� �����.
            Assert.AreEqual(null, workers[0].HomeAdress.City); 
            Assert.AreEqual(null, workers[0].HomeAdress.Street);
            Assert.AreEqual(0, workers[0].HomeAdress.NumberHouse);
            Assert.AreEqual(0, workers[0].HomeAdress.NumberApartment);


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

        [TestMethod]
        
        public void SortBySurname_ShouldAlphabeticallySortedBySurname()
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
            workers = DataService.SortBySurname(workers);

            //Assert
            Assert.AreEqual("��������", workers[0].Surname);
            Assert.AreEqual("�������", workers[0].FirstName);
            Assert.AreEqual("����������", workers[0].Patronymic);
            Assert.AreEqual(new DateTime(2004, 10, 2), workers[0].DateOfBirth);
            Assert.AreEqual("��������", workers[1].Surname);
            Assert.AreEqual("������", workers[2].Surname);
            Assert.AreEqual("������", workers[3].Surname);
            Assert.AreEqual("�������", workers[4].Surname);


        }

        [TestMethod]

        public void SaveToCsv_ShouldCreateScvFile()
        {
            //Arrange
            DataService ds = new DataService();
            List<Workers> workers = DataService.CreateListWorkers();

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
            string city = "������";
            string street = "����������";
            int numberHouse = 34;
            int numberApartment = 72;



            workers = ds.AddWorker(workers, firstName, surname, patronymic, phoneNumber, post, education, email, dateOfBirth, dateOfEnrollment, workExp, salary);
            Workers worker = ds.FindWorker(workers, firstName, surname, patronymic); // ������� ������ ��� ���������
            int index = workers.FindIndex(w => w.Equals(worker)); // ������� ������ ��� ������ ����� ����������

            worker = ds.AddHomeAdressWorker(worker, city, street, numberHouse, numberApartment);
            workers[index] = worker; //����� ������ ������� �� �������� � �������.



            string path = @"D:\��������\OutPutDataFileSprint7TEST1.csv";
            
            //Act
            DataService.SaveToCsv(workers,path);


            //Assert
            Assert.IsTrue(File.Exists(path), "CSV ���� �� ��� ������.");

        }

        [TestMethod]
        public void SaveToCsv_ShouldCreateCsvFileWithMultipleWorkers()
        {
            // Arrange
            DataService ds = new DataService();
            List<Workers> workers = DataService.CreateListWorkers();

            // ������ ������� ���������
            string firstName1 = "����";
            string surname1 = "������";
            string patronymic1 = "��������";
            string phoneNumber1 = "89001234567";
            string post1 = "�����������";
            string education1 = "���";
            string email1 = "ivanov@mail.ru";
            DateTime dateOfBirth1 = new DateTime(1990, 1, 1);
            DateTime dateOfEnrollment1 = new DateTime(2020, 5, 10);
            int workExp1 = 10;
            double salary1 = 10000.60;
            string city1 = "������";
            string street1 = "������";
            int numberHouse1 = 10;
            int numberApartment1 = 5;

            workers = ds.AddWorker(workers, firstName1, surname1, patronymic1, phoneNumber1, post1, education1, email1, dateOfBirth1, dateOfEnrollment1, workExp1, salary1);
            Workers worker1 = ds.FindWorker(workers, firstName1, surname1, patronymic1);
            int index1 = workers.FindIndex(w => w.Equals(worker1));
            worker1 = ds.AddHomeAdressWorker(worker1, city1, street1, numberHouse1, numberApartment1);
            workers[index1] = worker1;

            // ������ ������� ���������
            string firstName2 = "����";
            string surname2 = "������";
            string patronymic2 = "��������";
            string phoneNumber2 = "89009876543";
            string post2 = "��������";
            string education2 = "�����";
            string email2 = "petrov@mail.ru";
            DateTime dateOfBirth2 = new DateTime(1985, 3, 15);
            DateTime dateOfEnrollment2 = new DateTime(2015, 8, 20);
            int workExp2 = 15;
            double salary2 = 150056.560;
            string city2 = "�����-���������";
            string street2 = "������� ��������";
            int numberHouse2 = 20;
            int numberApartment2 = 10;

            workers = ds.AddWorker(workers, firstName2, surname2, patronymic2, phoneNumber2, post2, education2, email2, dateOfBirth2, dateOfEnrollment2, workExp2, salary2);
            Workers worker2 = ds.FindWorker(workers, firstName2, surname2, patronymic2);
            int index2 = workers.FindIndex(w => w.Equals(worker2));
            worker2 = ds.AddHomeAdressWorker(worker2, city2, street2, numberHouse2, numberApartment2);
            workers[index2] = worker2;

            // ������ �������� ���������
            string firstName3 = "�����";
            string surname3 = "��������";
            string patronymic3 = "����������";
            string phoneNumber3 = "89007654321";
            string post3 = "��������";
            string education3 = "����";
            string email3 = "sidorova@mail.ru";
            DateTime dateOfBirth3 = new DateTime(1995, 7, 25);
            DateTime dateOfEnrollment3 = new DateTime(2018, 11, 1);
            int workExp3 = 5;
            double salary3 = 100005.555;
            string city3 = "������������";
            string street3 = "��������";
            int numberHouse3 = 5;
            int numberApartment3 = 25;

            workers = ds.AddWorker(workers, firstName3, surname3, patronymic3, phoneNumber3, post3, education3, email3, dateOfBirth3, dateOfEnrollment3, workExp3, salary3);
            Workers worker3 = ds.FindWorker(workers, firstName3, surname3, patronymic3);
            int index3 = workers.FindIndex(w => w.Equals(worker3));
            worker3 = ds.AddHomeAdressWorker(worker3, city3, street3, numberHouse3, numberApartment3);
            workers[index3] = worker3;

            // ������ ���������� ���������
            string firstName4 = "����";
            string surname4 = "���������";
            string patronymic4 = "���������";
            string phoneNumber4 = "89006543210";
            string post4 = "���������";
            string education4 = "���";
            string email4 = "kuznetsova@mail.ru";
            DateTime dateOfBirth4 = new DateTime(1992, 12, 12);
            DateTime dateOfEnrollment4 = new DateTime(2019, 9, 15);
            int workExp4 = 4;
            double salary4 = 9000900.00;
            string city4 = "�����������";
            string street4 = "������� ��������";
            int numberHouse4 = 15;
            int numberApartment4 = 50;

            workers = ds.AddWorker(workers, firstName4, surname4, patronymic4, phoneNumber4, post4, education4, email4, dateOfBirth4, dateOfEnrollment4, workExp4, salary4);
            Workers worker4 = ds.FindWorker(workers, firstName4, surname4, patronymic4);
            int index4 = workers.FindIndex(w => w.Equals(worker4));
            worker4 = ds.AddHomeAdressWorker(worker4, city4, street4, numberHouse4, numberApartment4);
            workers[index4] = worker4;

            string path = @"D:\��������\OutPutDataFileSprint7TEST2.csv";

            // Act
            //DataService.SortBySalaryDescending(workers);// no work
            //DataService.SortByAgeDescending(workers);// no work
            DataService.SortBySurname(workers);
            DataService.SaveToCsv(workers, path);

            // Assert
            Assert.IsTrue(File.Exists(path), "CSV ���� �� ��� ������.");
            string csvContent = File.ReadAllText(path);
            //Assert.IsTrue(csvContent.Contains("����;������;��������"), "������ ������� ��������� ����������� � CSV �����.");
            //Assert.IsTrue(csvContent.Contains("����;���������;���������"), "������ ���������� ��������� ����������� � CSV �����.");
        }

    }
}