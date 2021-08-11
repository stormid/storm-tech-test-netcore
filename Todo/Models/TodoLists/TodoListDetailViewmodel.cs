using System.Collections.Generic;
using System.Linq;
using Todo.Models.TodoItems;

namespace Todo.Models.TodoLists
{
    public class TodoListDetailViewmodel
    {
        public int TodoListId { get; }
        public string Title { get; }
        public ICollection<TodoItemSummaryViewmodel> Items { get; }

        public TodoListDetailViewmodel(int todoListId, string title, ICollection<TodoItemSummaryViewmodel> items)
        {
            // Rationale: If sorting is happening here, try to prevent exceptions interfering with user
            items      ??= new List<TodoItemSummaryViewmodel>();
            Items      =   items.OrderBy(todoItem => todoItem.Importance).ToList();
            TodoListId =   todoListId;
            Title      =   title;
        }
    }
}