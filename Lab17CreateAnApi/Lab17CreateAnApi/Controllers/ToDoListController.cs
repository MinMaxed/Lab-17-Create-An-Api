using Lab17CreateAnApi.Data;
using Lab17CreateAnApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab17CreateAnApi.Controllers
{
    public class ToDoListController : ControllerBase
    {
        private readonly ToDoDBContext _context;

        public ToDoListController(ToDoDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDoList>>> GetAllAsync()
        {
            var lists = await _context.ToDoLists.ToListAsync();
            return lists;
        }

        [HttpGet("{id}", Name = "GetList")]
        public async Task<ActionResult<ToDoList>> GetByID(int id)
        {
            var list = await _context.ToDoLists.FindAsync(id);

            if (list == null)
            {
                return NotFound();
            }

            var items =  _context.ToDoItems.Where(l => l.ListID == id).ToList();
            list.Items = items;
            return list;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ToDoList list)
        {
            _context.ToDoLists.Add(list);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetList", new { id = list.ID }, list);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ToDoList list)
        {
            if(id != list.ID)
            {
                return BadRequest();
            }

            var updateList = await _context.ToDoLists.FindAsync(id);
            if (updateList == null)
            {
                return NotFound();
            }

            updateList.Name = list.Name;

            _context.ToDoLists.Update(updateList);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            var list = await _context.ToDoLists.FindAsync(id);

            if(list == null)
            {
                return NotFound();
            }

            _context.ToDoLists.Remove(list);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
