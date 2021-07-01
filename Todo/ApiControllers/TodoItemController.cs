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
        public async Task<IActionResult> SetRank(RankSetModel model)
        {
            if (model.TodoItemId == 0)
                return BadRequest();

            var todoItem = dbContext.SingleTodoItem(model.TodoItemId);

            if (todoItem != null)
            {
                todoItem.Rank = model.Rank;
                dbContext.Update(todoItem);
                await dbContext.SaveChangesAsync();
            }               
            else
                return BadRequest();

            return Ok();
        }

        public class RankSetModel
        {
            public int Rank { get; set; }
            public int TodoItemId { get; set; }
        }
    }
}
