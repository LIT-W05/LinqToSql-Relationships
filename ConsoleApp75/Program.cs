using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp75
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new PeopleCarsDataContext())
            {
                //context.Log = Console.Out;
                //var loadOptions = new DataLoadOptions();
                //loadOptions.LoadWith<Person>(p => p.Cars);
                //context.LoadOptions = loadOptions;

                //foreach (Person person in context.Persons)
                //{
                //    Console.WriteLine(person.FirstName + " " + person.LastName);
                //    Console.WriteLine("Cars:");
                //    foreach (Car car in person.Cars)
                //    {
                //        Console.WriteLine("\t" + car.Make + " " + car.Model);
                //    }
                //}

                //Car car = context.Cars.FirstOrDefault(c => c.Id == 4);
                //foreach (var c in car.Person.Cars)
                //{
                //    Console.WriteLine(c.Make + " " + c.Model);
                //}
                //Console.WriteLine(car.Person.FirstName + " " + car.Person.LastName);
                //Person person = context.Persons.FirstOrDefault(p => p.Id == 1029);
                //Car car = new Car
                //{
                //    Make = "Ford",
                //    Model = "F150",
                //    Year = 2017,
                //};
                //person.Cars.Add(car);
                //context.SubmitChanges();
                Car car = new Car
                {
                    Make = "Ford",
                    Model = "F150",
                    Year = 2017,
                    PersonId = 1028
                };
                context.Cars.InsertOnSubmit(car);
                context.SubmitChanges();
            }

            Console.ReadKey(true);
        }
    }
}
