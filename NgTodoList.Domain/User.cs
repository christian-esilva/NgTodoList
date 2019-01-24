using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgTodoList.Domain
{
    public class User
    {
        private IList<Todo> _todos;

        protected User() { }

        public User(string name, string email, string password)
        {
            if (name.Length < 3)
                throw new Exception("Nome inválido");
        }

        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public bool IsActive { get; protected set; }
        public virtual ICollection<Todo> Todos
        {
            get { return _todos; }
            protected set { _todos = new List<Todo>(value); }
        }
    }
}
