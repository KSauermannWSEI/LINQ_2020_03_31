using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_2020_03_31.Models
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
