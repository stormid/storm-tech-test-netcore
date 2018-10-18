using System.Linq;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoItems;
using Todo.Models.TodoLists;

namespace Todo.EntityModelMappers.TodoLists
{
    public static class TodoListSummaryViewmodelFactory
    {
        public static TodoListSummaryViewmodel Create(TodoList todoList)
        {
            var numberOfNotDoneItems = todoList.Items.Count(ti => !ti.IsDone);
            return new TodoListSummaryViewmodel(todoList.TodoListId, todoList.Title, numberOfNotDoneItems, UserSummaryViewmodelFactory.Create(todoList.Owner));
        }
    }
}