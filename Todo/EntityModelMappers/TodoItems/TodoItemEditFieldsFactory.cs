using Todo.Data.Entities;
using Todo.Models.TodoItems;

namespace Todo.EntityModelMappers.TodoItems
{
    public class TodoItemEditFieldsFactory
    {
        public static TodoItemEditFields Create(TodoItem todoItem)
        {
            var todoList = todoItem.TodoList;
            return new TodoItemEditFields(todoList.TodoListId, todoList.Title, todoItem.TodoItemId, todoItem.Title,
                todoItem.IsDone, todoItem.ResponsiblePartyId, todoItem.Importance);
        }

        public static void Update(TodoItemEditFields src, TodoItem dest)
        {
            dest.Title = src.Title;
            dest.IsDone = src.IsDone;
            dest.ResponsiblePartyId = src.ResponsiblePartyId;
            dest.Importance = src.Importance;
        }
    }
}