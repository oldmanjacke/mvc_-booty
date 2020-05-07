using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_med_booty.models.Repository
{
    public class MockPeopleRepo : IPeopleRepo
    {
        private static List<People> peoples = new List<People>();
        private static int idCounter = 0;

        public List<People> All()
        {
            return peoples;
        }

        public People Create(People people)
        {
            people.Id = ++idCounter;
            peoples.Add(people);
            return people;
        }

        public bool Delete(int id)
        {
            People people = FindById(id);
            if (people == null)
            {
                return false;
            }
            else
            {
                return peoples.Remove(people);
            }
        }

        public People FindById(int id)
        {
            People people = peoples.SingleOrDefault(d => d.Id == id);

            return people;
        }

        public bool Update(People people)
        {
            People original = FindById(people.Id);
            if (people == null)
            {
                return false;
            }
            else
            {
                original.Name = people.Name;
                original.Age = people.Age;
                original.Adress = people.Adress;
                original.City = people.City;

                return true;
            }
        }
    }
}
