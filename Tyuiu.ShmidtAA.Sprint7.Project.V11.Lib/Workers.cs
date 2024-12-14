﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tyuiu.ShmidtAA.Sprint7.Project.V11.Lib
{
    public struct Family
    {
        /// <summary>
        /// Имя матери
        /// </summary>
        public string MotherName;

        /// <summary>
        /// Фамилия матери
        /// </summary>
        public string MotherSurname;

        /// <summary>
        /// Отчество матери
        /// </summary>
        public string MotherPatronymic;

        /// <summary>
        /// Номер телефона матери
        /// </summary>
        public string MotherPhoneNumber;

        /// <summary>
        /// Дата рождения матери
        /// </summary>
        public DateTime MotherDateOfBirth;

        /// <summary>
        /// Имя отца
        /// </summary>
        public string FatherName;

        /// <summary>
        /// Фамилия отца
        /// </summary>
        public string FatherSurname;

        /// <summary>
        /// Отчество отца
        /// </summary>
        public string FatherPatronymic;

        /// <summary>
        /// Номер телефона отца
        /// </summary>
        public string FatherPhoneNumber;

        /// <summary>
        /// Дата рождения отца
        /// </summary>
        public DateTime FatherDateOfBirth;

        /// <summary>
        /// Наличие детей(да/нет)
        /// </summary>
        public bool HavingKids;

    }

    struct Workers
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Firstname;

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname;

        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic;

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age;

        /// <summary>
        /// Домашний адрес
        /// </summary>
        public Addres HomeAdress;

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string MobilePhone;

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth;

        /// <summary>
        /// Дата зачисления
        /// </summary>
        public DateTime DateOfEnrollment;

        /// <summary>
        /// Должность
        /// </summary>
        public string Post;

        /// <summary>
        /// Опыт работы
        /// </summary>
        public int WorkExp;

        /// <summary>
        /// Образование
        /// </summary>
        public string Education;

        /// <summary>
        /// Оклад
        /// </summary>
        public double Salary;

       

    }
}