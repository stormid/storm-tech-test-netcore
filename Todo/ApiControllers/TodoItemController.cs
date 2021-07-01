using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Data;
using Todo.Services;

namespace Todo.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public TodoItemController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> SetRank(int rank, int todoItemId)
        {
            var todoItem = dbContext.SingleTodoItem(todoItemId);

            if (todoItem != null)
            {
                todoItem.Rank = rank;
                dbContext.Update(todoItem);
                await dbContext.SaveChangesAsync();
            }               
            else
                return BadRequest();

            return Ok();
        }
    }
}
