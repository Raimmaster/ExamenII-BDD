using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Examen2
{
    [Binding]
    public class ExamenSteps
    {
        List<Employee> employees = new List<Employee>();
        Employee[] employeesArray;

        [Given(@"I have the following employees")]
        public void GivenIHaveTheFollowingEmployees(Table table)
        {
            var empleados = table.CreateSet<Employee>();
            foreach(var emp in empleados)
            {
                employees.Add(emp);
            }
            employeesArray = employees.ToArray();

            employees.Clear();
        }
        
        [When(@"we QUICKSORT by name")]
        public void WhenWeQUICKSORTByName()
        {
            int right_size = employeesArray.Length - 1;
            SortEmployees.QuickSort_Recursive(employeesArray, 0, right_size);
        }
       
        [Then(@"the list should be like this")]
        public void ThenTheListShouldBeLikeThis(Table table)
        {
            var newSet = table.CreateSet<Employee>();

            foreach (var emp in newSet)
            {
                employees.Add(emp);
                Console.WriteLine("Test...");
            }

            Employee[] finalArr = employees.ToArray();

            for (int i = 0; i < finalArr.Length; ++i)
                Assert.AreEqual(finalArr[i].Code, employeesArray[i].Code);
        }
    }
}
