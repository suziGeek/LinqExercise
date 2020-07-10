﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers

            Console.WriteLine(numbers.Sum());
            Console.WriteLine(numbers.Average());

            //Order numbers in ascending order and decsending order. Print each to console.
           
            var ordered = numbers.OrderBy(x => x);
            foreach(var x in ordered)
            {
                Console.WriteLine(x);
            }

            var goingDown = numbers.OrderByDescending(x => x);
            foreach (var x in goingDown)
            {
                Console.WriteLine(x);
            }



            //Print to the console only the numbers greater than 6

            var greaterThan = numbers.Where(r => r > 6);
            foreach (var x in greaterThan)
            {
                Console.WriteLine(x);
            }



            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            
            var down = numbers.OrderByDescending(x => x);
            var myFour = down.Take(4);

            foreach (var x in myFour)
            {
                Console.WriteLine(x);
            }


            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 120;

            var ageDown = numbers.OrderByDescending(x => x);

            foreach (var x in ageDown)
            {
                Console.WriteLine(x);
            }


            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.

            var empName = employees.Where(x => x.FirstName.StartsWith('C') || x.FirstName.StartsWith('S')).OrderBy(x=>x.FirstName);
            
            foreach (var x in empName)
            {               
                Console.WriteLine(x.FirstName);
            }

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.

            var empAge = employees.Where(x => x.Age > 26 ).OrderBy(x => x.Age).ThenBy(s =>s.FirstName) ;

            foreach (var x in empAge)
            {
                Console.WriteLine($"Age: {x.Age}, Name: {x.FirstName}");
            }

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var empExp = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);

            var sumEmp = empExp.Sum(x => x.YearsOfExperience);
            var avgEmp = empExp.Average(x => x.YearsOfExperience);



                Console.WriteLine($"Sum YOE: {sumEmp}, Average YOE: {avgEmp}");


            //Add an employee to the end of the list without using employees.Add()

            employees = employees.Append(new Employee("Suzanne ", "Allen", 38, 40)).ToList();

            foreach (var x in employees)
            {
                Console.WriteLine($"Age: {x.Age}, Name: {x.FirstName}");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
