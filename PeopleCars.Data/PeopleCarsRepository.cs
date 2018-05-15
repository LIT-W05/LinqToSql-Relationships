using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleCars.Data
{
    public class PeopleCarsRepository
    {
        private string _connectionString;

        public PeopleCarsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Person> GetPeople()
        {
            using (var context = new PeopleCarsDataContext(_connectionString))
            {
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Person>(p => p.Cars);
                context.LoadOptions = loadOptions;
                return context.Persons.ToList();
            }
        }

        public Person GetPerson(int id)
        {
            using (var context = new PeopleCarsDataContext(_connectionString))
            {
                return context.Persons.FirstOrDefault(p => p.Id == id);
            }
        }

        public void AddCar(Car car)
        {
            using (var context = new PeopleCarsDataContext(_connectionString))
            {
                context.Cars.InsertOnSubmit(car);
                context.SubmitChanges();
            }
        }
    }
}
