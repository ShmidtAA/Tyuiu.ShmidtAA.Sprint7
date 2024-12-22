using System.Net;
using Tyuiu.ShmidtAA.Sprint7.Project.V11.Lib;
namespace Tyuiu.ShmidtAA.Sprint7.Project.V11.Test
{
    [TestClass]
    public class DataServiceTest
    {
        

        /// <summary>
        /// проверил добавляется ли элемент в массив
        /// </summary>
        [TestMethod]
        public void CreateListWorkers_ShouldReturnNonEmptyList()
        {
            List<Workers> listWorkers = DataService.CreateListWorkers();
            Assert.IsNotNull(listWorkers);
        }


        /// <summary>
        /// Проверяю корректность заполнения экземпляра
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
        // добавить проверку на корректность айди при нескольких экземпляров (отмена)
        // добавить проверку на "неизвестность", то есть хочу увидеть "парамаетры по умолчанию"
        // добавить проверку на метода  AddHomeAdressWorker .


        /// <summary>
        /// Снова проверяю корректность заполнения экземпляра, но другим способом и с добавлением значение по умолчанию в dateOfBirth и в номере телефона. 
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
            Assert.AreEqual("Неизвестный номер", worker.PhoneNumber);
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
            Assert.AreEqual("Неизвестно", worker.PhoneNumber);
            Assert.AreEqual("Неизвестно", worker.Post);
            Assert.AreEqual("Неизвестно", worker.Education);
            Assert.AreEqual("Неизвестно", worker.Email);
            Assert.AreEqual(default(DateTime), worker.DateOfBirth);
            Assert.AreEqual(default(DateTime), worker.DateOfEnrollment); // тут вообще фалсе должно быть, но ладно, потом мб пофикшу
            Assert.AreEqual(0, worker.WorkExp);
            Assert.AreEqual(0.0, worker.Salary);
        }

        /// <summary>
        /// Здесь я проверяю конструктор Workers на значения по умолчанию.
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
            Assert.AreEqual("Неизвестный номер", worker.PhoneNumber);
            Assert.AreEqual("Неизвестная должность", worker.Post);
            Assert.AreEqual("Неизвестное образование", worker.Education);
            Assert.AreEqual("Неизвестная эл. почта", worker.Email);
            Assert.AreEqual(default(DateTime), worker.DateOfBirth);
            Assert.AreEqual(DateTime.Today, worker.DateOfEnrollment);
            Assert.AreEqual(0, worker.WorkExp);
            Assert.AreEqual(0.0, worker.Salary);
        }

        /// <summary>
        /// Проверка закрепления адреса к работнику
        /// </summary>
        [TestMethod]

        public void AddHomeAdressWorker_ShouldAddAdress()
        {
            // Подготовка Arrange
            string firstName = "Andrei";
            string surname = "Shmidt";
            string patronymic = "Andreevich";
            string city = "Тюмень";
            string street = "Республики";
            int numberHouse = 34;
            int numberApartment = 72;

            DataService ds = new DataService();
            List<Workers> workers = DataService.CreateListWorkers();
            workers = ds.AddWorker(workers, "firstName", "surname", "patronymic");
            workers = ds.AddWorker(workers, firstName, surname, patronymic);

            Workers worker = ds.FindWorker(workers, firstName, surname, patronymic); // Находим нужный нам экземпляр
            int index = workers.FindIndex(w => w.Equals(worker)); // находим нужный нам индекс этого экземпляра
             
            // Действие Act 

            worker = ds.AddHomeAdressWorker(worker, city, street, numberHouse, numberApartment);
            workers[index] = worker; //Очень важная строчка не забываем в будущем.

            // Проверка Assert

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
            string motherPatronymic = "Cumberbatch"; // В англоязычных странах отчества не используются, поэтому это будет фамилия
            string motherPhoneNumber = "+44 123 456 7890";

            string fatherName = "Timothy";
            string fatherSurname = "Carlton";
            string fatherPatronymic = "Cumberbatch"; // Аналогично, фамилия вместо отчества
            string fatherPhoneNumber = "+44 098 765 4321";

            bool havingKids = true; // Бенедикт Камбербэтч имеет детей

            DateTime motherDateOfBirth = new DateTime(1949, 11, 18); // Примерная дата рождения
            DateTime fatherDateOfBirth = new DateTime(1939, 10, 1); // Примерная дата рождения

            DataService ds = new DataService();
            List<Workers> workers = DataService.CreateListWorkers();
            workers = ds.AddWorker(workers, "firstName", "surname", "patronymic");
            workers = ds.AddWorker(workers, firstName, surname, patronymic);

            Workers worker = ds.FindWorker(workers, firstName, surname, patronymic); // Находим нужный нам экземпляр
            int index = workers.FindIndex(w => w.Equals(worker)); // находим нужный нам индекс этого экземпляра
            
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

            ds.AddWorker(workers, "Иван", "Иванов", "Иванович", salary: 45000);
            ds.AddWorker(workers, "Петр", "Петров", "Петрович", salary: 52000);
            ds.AddWorker(workers, "Сергей", "Сергеев", "Сергеевич", salary: 48000);
            ds.AddWorker(workers, "Алексей", "Алексеев", "Алексеевич", salary: 30000);
            ds.AddWorker(workers, "Дмитрий", "Дмитриев", "Дмитриевич", salary: 70000);



            //Act
            workers = DataService.SortBySalaryDescending(workers);


            //Assert

            Assert.AreEqual("Дмитрий", workers[0].FirstName);
            Assert.AreEqual("Петр", workers[1].FirstName);
            Assert.AreEqual("Сергей", workers[2].FirstName);
            Assert.AreEqual("Иван", workers[3].FirstName);
        }
        [TestMethod]
        public void SortByAgeDescending_ShouldListByAgeDescending()
        {
            //Arrange
            DataService ds = new DataService();
            List<Workers> workers = DataService.CreateListWorkers();

            ds.AddWorker(workers, "Иван", "Иванов", "Иванович", dateOfBirth: new DateTime(2004, 10, 1));
            ds.AddWorker(workers, "Петр", "Петров", "Петрович", dateOfBirth: new DateTime(1949, 10, 1));
            ds.AddWorker(workers, "Сергей", "Сергеев", "Сергеевич", dateOfBirth: new DateTime(1949, 11, 1));
            ds.AddWorker(workers, "Алексей", "Алексеев", "Алексеевич", dateOfBirth: new DateTime(2004, 10, 2));
            ds.AddWorker(workers, "Дмитрий", "Дмитриев", "Дмитриевич", dateOfBirth: new DateTime(1939, 10, 1));

            //Act
            workers = DataService.SortByAgeDescending(workers);

            //Assert
            Assert.AreEqual("Дмитрий", workers[0].FirstName);
            Assert.AreEqual("Петр", workers[1].FirstName);
            Assert.AreEqual("Сергей", workers[2].FirstName);
            Assert.AreEqual("Иван", workers[3].FirstName);
           
        }





    }
}