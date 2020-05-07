using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_med_booty.models.Repository
{
    public interface IPeopleRepo
    {
        People Create(People people);
        People FindById(int id);
        bool Update(People people);
        bool Delete(int id);
        List<People> All();
    }
}
