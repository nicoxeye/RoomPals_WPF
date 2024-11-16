﻿using RoomPals.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RoomPals.Classes
{
    public class Student:Location
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public DateTime BirthDate { get; private set; }
        public string Major { get; set; }
        public string Sex { get; set; }
        public string NightOrDay { get; set; }
        public string DogOrCat { get; set; }
        public string PartyOrBook { get; set; }
        public string ActiveOrPassive { get; set; }
        public string MainLanguage { get; set; }
        public string SecondLanguage { get; set; }

        // New properties for login
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Regex patterns
        string pattern_email = "@^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$";
        string pattern_password = "@^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d).{8,16}$";  //requirements: password must contain: min 1 uppercase letter, min 1 lowercase letter, min 1 digit 

        // Constructor to initialize the student object
        public Student(string name, string surname, int age, DateTime birthDate, string major, string sex,
                      string nightOrDay, string dogOrCat, string partyOrBook, string activeOrPassive,
                      string mainLanguage, string secondLanguage, string username, string email, string password, string Country, string City):base(Country, City)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Major = major;
            Sex = sex;
            NightOrDay = nightOrDay;
            DogOrCat = dogOrCat;
            PartyOrBook = partyOrBook;
            ActiveOrPassive = activeOrPassive;
            MainLanguage = mainLanguage;
            SecondLanguage = secondLanguage;
            Username = username;
            if (!Regex.IsMatch(email, pattern_email))
            {
                throw new ArgumentException("Incorrect email format");
            }
            Email = email;
            if (!Regex.IsMatch(password, pattern_password))
            {
                throw new Exception("Incorrect password format");
            }
            Password = password;
        }

        // Method to authenticate user
        public bool Authenticate(string username, string password)
        {
            return Username == username && Password == password;
        }

        public override string ToString()
        {
            return $"{Name} {Surname}, Age: {Age}, Major: {Major}, Sex: {Sex}, City: {city}, Preferences: {NightOrDay}, {DogOrCat}, {PartyOrBook}, Activity: {ActiveOrPassive}, Languages: {MainLanguage}, {SecondLanguage}";
        }
    }
}



