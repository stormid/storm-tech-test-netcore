using System.Collections.Generic;

namespace Todo.Models.TodoLists
{
    public class TodoListIndexViewmodel
    {
        public ICollection<TodoListSummaryViewmodel> Lists { get; }

        public TodoListIndexViewmodel(ICollection<TodoListSummaryViewmodel> lists)
        {
            Lists = lists;
        }
    }
}