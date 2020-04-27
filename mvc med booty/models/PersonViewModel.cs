using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_med_booty.models
{
    public class PersonViewModel
    {
        [Required]
        [StringLength(60, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        public double Age { get; set; }

        public bool Adress { get; set; }

        public bool City { get; set; }

        public PersonViewModel() { }//zero constuctor (no input arguments)
        public PersonViewModel(People person)
        {
            Name = person.Name;
            Age = person.Age;
            Adress = person.Adress;
            City = person.City;
        }
    }
}
