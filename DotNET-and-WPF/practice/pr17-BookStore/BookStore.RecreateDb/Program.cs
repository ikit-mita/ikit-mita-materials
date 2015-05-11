using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using BookStore.DataAccess;
using BookStore.DataAccess.Model;
using Newtonsoft.Json;

namespace BookStore.RecreateDb
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();

            Console.WriteLine("Check DB exists...");
            if (Database.Exists("BookStoreDb"))
            {
                Console.WriteLine("DB exists. Deleting...");
                Database.Delete("BookStoreDb");
            }
            else
            {
                Console.WriteLine("DB does not exist. Skip deleting.");
            }

            using (var db = new Db())
            {
                Console.WriteLine("Creating DB..");
                object tmp = db.Users.ToArray();

                Console.WriteLine("Branches..");
                var br1 = new Branch()
                {
                    Address = "Mira prospect, 11 - 21",
                    Name = "Booko na Mira"
                };

                var br2 = new Branch()
                {
                    Address = "Ulica Vzletnaya, 22",
                    Name = "Booko na Vzletke"
                };

                db.Branches.Add(br1);
                db.Branches.Add(br2);
                db.SaveChanges();

                Console.WriteLine("Creating employees and users..");
                var admin = new Employee
                {
                    Branch = br1,
                    FirstName = "Admin",
                    MiddleName = "Admin",
                    LastName = "Admin",
                    User = new User()
                    {
                        LastLoginTime = DateTime.Now,
                        Login = "admin",
                        Password = PasswordManager.CreateHash("admin"),
                        Role = Role.Admin
                    }
                };

                var ivanov = new Employee
                {
                    Branch = br1,
                    FirstName = "Ivan",
                    MiddleName = "Ivanovich",
                    LastName = "Ivanov",
                    User = new User()
                    {
                        LastLoginTime = DateTime.Now,
                        Login = "iii",
                        Password = PasswordManager.CreateHash("iii"),
                        Role = Role.User
                    }
                };

                var petrov = new Employee
                {
                    Branch = br2,
                    FirstName = "Petr",
                    MiddleName = "Petrovich",
                    LastName = "Petrov",
                    User = new User()
                    {
                        LastLoginTime = DateTime.Now,
                        Login = "ppp",
                        Password = PasswordManager.CreateHash("ppp"),
                        Role = Role.User
                    }
                };

                var sidorov = new Employee
                {
                    Branch = br2,
                    FirstName = "Sidor",
                    MiddleName = "Sidorovich",
                    LastName = "Sidorov",
                    User = null
                };

                db.Employees.Add(admin);
                db.Employees.Add(ivanov);
                db.Employees.Add(petrov);
                db.Employees.Add(sidorov);
                db.SaveChanges();

                Console.WriteLine("Customers..");

                var customers = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText("Customers.json"));
                customers.ForEach(c => db.Customers.Add(c));
                db.SaveChanges();

                Console.WriteLine("Book categories..");
                var fantasy = new BookCategory { Name = "Fantasy" };
                var detective = new BookCategory { Name = "Detective" };
                var scienceFiction = new BookCategory { Name = "Science Fiction" };
                var novel = new BookCategory { Name = "Novel" };

                db.BookCategories.Add(fantasy);
                db.BookCategories.Add(detective);
                db.BookCategories.Add(scienceFiction);
                db.BookCategories.Add(novel);
                db.SaveChanges();

                Console.WriteLine("Writers..");
                var writers = JsonConvert.DeserializeObject<List<Writer>>(File.ReadAllText("Writers.json"));
                writers.ForEach(w => db.Writers.Add(w));
                db.SaveChanges();

                Console.WriteLine("Books..");
                int k = 0;
                foreach (BookCategory bookCategory in db.BookCategories)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        var book = new Book
                        {
                            Category = bookCategory,
                            ISBN = (100 + k) + "-1477827" + (100 + k),
                            Price = rand.Next(10000, 100000) / 100.0M,
                            PublishYear = rand.Next(1990, 2015),
                            Title = Titles.List[k],
                            Writers = Enumerable.Range(1, k%3+1)
                                .Select(@int => writers[k+@int])
                                .ToList(),
                            Amounts = new List<BookAmount>
                                {
                                    new BookAmount
                                    {
                                        Branch = br1,
                                        Amount = 10,
                                    },
                                    new BookAmount
                                    {
                                        Branch = br2,
                                        Amount = 10,
                                    }
                                }
                        };
                        db.Books.Add(book);
                        k++;
                    }
                }

                db.SaveChanges();
                Console.WriteLine("Done");
            }
        }
    }
}
