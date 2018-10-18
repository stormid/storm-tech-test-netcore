using System.Collections.Generic;
using System.Linq;
using Todo.Data.Entities;
using Todo.Models.TodoLists;

namespace Todo.EntityModelMappers.TodoLists
{
    public static class TodoListIndexViewmodelFactory
    {
        public static TodoListIndexViewmodel Create(IEnumerable<TodoList> todoLists)
        {
            var lists = todoLists.Select(TodoListSummaryViewmodelFactory.Create).ToList();
            return new TodoListIndexViewmodel(lists);
        }
    }
}