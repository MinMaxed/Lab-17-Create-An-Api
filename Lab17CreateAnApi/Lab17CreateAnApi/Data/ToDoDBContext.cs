using Lab17CreateAnApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab17CreateAnApi.Data
{
    public class ToDoDBContext : DbContext
    {
        public ToDoDBContext(DbContextOptions<ToDoDBContext> options) : base(options)
        { }

        DbSet<ToDoItem> ToDoItems { get; set; }
        DbSet<ToDoList> ToDoLists { get; set; }
    }
}
