using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_med_booty.models.Services
{
    public class PersonService : IPeopleService
    {
        private readonly IDrinksRepo _personsRepo;

        public DrinksService(IDrinksRepo personsRepo)
        {
            _personsRepo = personsRepo;
        }

        public People Create(PersonViewModel person)
        {
            return _personsRepo.Create(VM_ToDrink(person));
        }

        public People FindById(int id)
        {
            return _personsRepo.FindById(id);
        }

        public List<People> GetDrinks()
        {
            return _personsRepo.All();
        }

        public bool Remove(int id)
        {
            return _personsRepo.Delete(id);
        }

        public bool Update(int id, PersonViewModel personViewModel)
        {
            People people = VM_ToDrink(personViewModel);
            people.Id = id;
            return _personsRepo.Update(people);
        }

        private People VM_ToDrink(PersonViewModel personViewModel)
        {
            return new People() { Name = personViewModel.Name, Age = personViewModel.Age, Adress = personViewModel.Adress, City = personViewModel.City };
        }
    }
}
