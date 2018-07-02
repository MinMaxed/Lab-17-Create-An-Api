using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab17CreateAnApi.Models
{
    public class ToDoList
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<ToDoItem> Items { get; set; }
    }
}
