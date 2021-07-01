using Microsoft.AspNetCore.Identity;

namespace Todo.Data.Entities {
    public class TodoItem
    {
        public int TodoItemId { get; set; }
        public string Title { get; set; }
        public string ResponsiblePartyId { get; set; }
        public IdentityUser ResponsibleParty { get; set; }
        public bool IsDone { get; set; }
        public Importance Importance { get; set; }
        public int Rank { get; set; }
        public int TodoListId { get; set; }
        public TodoList TodoList { get; set; }

        protected TodoItem() { }

        public TodoItem(int todoListId, string responsiblePartyId, string title, Importance importance, int rank = 0)
        {
            TodoListId = todoListId;
            ResponsiblePartyId = responsiblePartyId;
            Title = title;
            Importance = importance;
            Rank = rank;
        }
    }
}