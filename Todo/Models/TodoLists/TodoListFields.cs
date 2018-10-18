using System.ComponentModel.DataAnnotations;

namespace Todo.Models.TodoLists
{
    public class TodoListFields
    {
        [Required]
        public string Title { get; set; }
    }
}