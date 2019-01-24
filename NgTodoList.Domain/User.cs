using NgTodoList.Utils.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NgTodoList.Domain
{
    public class User
    {
        protected User() { }

        public User(string name, string email, string password)
        {
            if (name.Length < 3)
                throw new Exception("Nome inválido");

            if(!Regex.IsMatch(email, @"[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}"))
                throw new Exception("E-mail inválido");

            if (password.Length < 6)
                throw new Exception("Senha inválida");

            Id = 0;
            Name = name;
            Email = email;
            Password = password;
            IsActive = true;
            _todos = new List<Todo>();
            Todos = new List<Todo>();
        }

        private IList<Todo> _todos;
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

        public void ChangePassword(string email, string password, string newPassowrd, string confirmNewPassword)
        {
            if (!Regex.IsMatch(email, @"[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}"))
                throw new Exception("E-mail inválido");

            if (password.Length < 6)
                throw new Exception("Senha inválida");

            if(!(Email.ToLower() == email) && !(Password == password))
            {
                throw new Exception("Usuário ou senha inválidos!");
            }

            if(newPassowrd != confirmNewPassword)
                throw new Exception("As senhas digitadas não conferem");

            var pass = EncryptHelper.Encrypt(newPassowrd);
            Password = pass;
        }
    }
}
