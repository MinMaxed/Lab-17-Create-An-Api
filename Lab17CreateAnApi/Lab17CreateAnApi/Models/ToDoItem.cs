using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab17CreateAnApi.Models
{
    public class ToDoItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
        public int ListID { get; set; }
    }
}
