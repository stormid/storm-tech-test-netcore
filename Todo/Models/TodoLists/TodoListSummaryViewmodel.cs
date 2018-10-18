using Todo.Models.TodoItems;

namespace Todo.Models.TodoLists
{
    public class TodoListSummaryViewmodel
    {
        public int TodoListId { get; }
        public string Title { get; }
        public int NumberOfNotDoneItems { get; }
        public UserSummaryViewmodel Owner { get; }

        public TodoListSummaryViewmodel(int todoListId, string title, int numberOfNotDoneItems, UserSummaryViewmodel owner)
        {
            TodoListId = todoListId;
            Title = title;
            NumberOfNotDoneItems = numberOfNotDoneItems;
            Owner = owner;
        }
    }
}