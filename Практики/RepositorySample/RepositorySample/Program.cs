using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySample
{
    class Program
    {
        static IRepository<User> repository = new MemoryRepository<User>();

        static void Main(string[] args)
        {
            repository.Add(new User { Email = "u1@mail.ru", Name = "user1" });
            repository.Add(new User { Email = "u2@mail.ru", Name = "user2" });

            Console.WriteLine("Name:");
            string userName = Console.ReadLine();

            User user = repository.GetAll()
                .FirstOrDefault(u => u.Name == userName);

            if (user != null)
            {
                Console.WriteLine("Welcome, {0}.", user.Email);
            }
            else
            {
                Console.WriteLine("Email:");
                string userEmail = Console.ReadLine();
                user = new User
                    {
                        Email = userEmail,
                        Name = userName,
                        RegDate = DateTime.Now
                    };

                repository.Add(user);

                Console.WriteLine("New user, id = {0}.", user.Id);
            }

            user = repository.Find(user.Id);
            repository.Remove(user);

            foreach (User u1 in repository.GetAll())
            {
                Console.WriteLine("{0} - {1} [2].", u1.Name, u1.Email, u1.Id);
            }

            Console.ReadLine();
        }
    }
}
