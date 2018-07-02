﻿using Lab17CreateAnApi.Data;
using Lab17CreateAnApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab17CreateAnApi.Controllers
{
    [Route("Api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoDBContext _context;

        public ToDoController(ToDoDBContext context)
        {
            _context = context;

            if (_context.ToDoItems.Count() == 0)
            {
                _context.ToDoItems.Add(new ToDoItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<ToDoItem>> GetAll()
        {
            return _context.ToDoItems.ToList();
        }

        [HttpGet("{id}", Name = "GetToDo")]
        public ActionResult<ToDoItem> GetById(long id)
        {
            var item = _context.ToDoItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(ToDoItem item)
        {
            _context.ToDoItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetToDo", new { id = item.ID }, item);
        }
    }
}
