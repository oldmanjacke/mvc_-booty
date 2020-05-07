using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_med_booty.models.Services
{
    public interface IPeopleService
    {

        People Create(PersonViewModel person);
        People FindById(int id);
        bool Update(int id, PersonViewModel personViewModel);
        bool Remove(int id);
        List<People> GetPerson();
    }
}
