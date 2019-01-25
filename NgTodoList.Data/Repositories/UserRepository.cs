using NgTodoList.Data.Context;
using NgTodoList.Domain;
using NgTodoList.Domain.Repositories;
using System.Data.Entity;
using System.Linq;

namespace NgTodoList.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            _context.Users.Remove(_context.Users.Find(id));
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public User Get(string email)
        {
            return _context.Users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }

        public void SaveOrUpdate(User user)
        {
            if (user.Id == 0)
                _context.Users.Add(user);
            else
                _context.Entry(user).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
