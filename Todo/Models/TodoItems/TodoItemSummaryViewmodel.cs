using Todo.Data.Entities;

namespace Todo.Models.TodoItems
{
    public class TodoItemSummaryViewmodel
    {
        public int TodoItemId { get; }
        public string Title { get; }
        public int Rank { get; }
        public UserSummaryViewmodel ResponsibleParty { get; }
        public bool IsDone { get; }
        public Importance Importance { get; }

        public TodoItemSummaryViewmodel(int todoItemId, string title, bool isDone, UserSummaryViewmodel responsibleParty, Importance importance, int rank)
        {
            TodoItemId = todoItemId;
            Title = title;
            IsDone = isDone;
            ResponsibleParty = responsibleParty;
            Importance = importance;
            Rank = rank;
        }
    }
}