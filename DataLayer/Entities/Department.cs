using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public Department()
        {

        }
        public Department(int id, string name, Country country)
        {
            Id = id;
            Name = name;
            Country = country;
        }
    }
}
