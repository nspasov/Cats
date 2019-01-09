using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dogs.Entities
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }
    }
}