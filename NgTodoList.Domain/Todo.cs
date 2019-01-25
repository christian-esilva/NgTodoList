using System;

namespace NgTodoList.Domain
{
    public class Todo
    {
        protected Todo() { }

        public Todo(string title)
            : this(title, 0)
        { }

        public Todo(string title, int userId)
        {
            if (title.Length < 3)
                throw new Exception("O título da tarefa deve conter mais que 3 caracteres");

            Id = 0;
            Title = title;
            Done = false;
            UserId = userId;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public bool Done { get; set; }
        public int UserId { get; set; }

        public void MarkAsDone()
        {
            Done = true;
        }

        public void MarkAsUndone()
        {
            Done = false;
        }
    }
}
