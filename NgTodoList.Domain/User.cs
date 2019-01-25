using NgTodoList.Utils.Security;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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

            if (newPassowrd.Length < 6)
                throw new Exception("A nova senha é inválida");

            var pass = EncryptHelper.Encrypt(newPassowrd);
            Password = pass;
        }

        public string ResetPassword(string email)
        {
            if (!Regex.IsMatch(email, @"[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}"))
                throw new Exception("E-mail inválido");

            var password = Guid.NewGuid().ToString().Substring(0, 8);
            Password = EncryptHelper.Encrypt(password);

            return password;
        }

        public void Authenticate(string email, string password)
        {
            if(!IsActive)
                throw new Exception("Usuário inativo");

            if (!Regex.IsMatch(email, @"[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}"))
                throw new Exception("E-mail inválido");

            var pass = EncryptHelper.Encrypt(password);
            if(!(Email.ToLower() == email.ToLower()) && !(Password == pass))
                throw new Exception("Usuário ou senha inválidos");
        }

        public void UpdateInfo(string name, string email)
        {
            if (name.Length < 3)
                throw new Exception("Nome inválido");

            name = Name;
        }

        public void ClearTodos()
        {
            _todos = new List<Todo>();
        }

        public void Inactivate()
        {
            IsActive = false;
        }

        public void Activate()
        {
            IsActive = true;
        }
    }
}
