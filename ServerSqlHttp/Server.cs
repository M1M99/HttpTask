using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ServerSqlHttp
{
    public class Server
    {
        DbContext1 Context = new DbContext1();
        public void AllUser()
        {
            Console.WriteLine("All User : ");
            Context.users.ToList().ForEach(a => Console.WriteLine(a.ToString()));
        }
        public void Add_User(User user)
        {
            Context.users.Add(user);
            Context.SaveChanges();
            Console.WriteLine("Added.");
        }
        public void Delete_User(int id)
        {
            var idUser = Context.users.FirstOrDefault(u => u.Id == id);
            if (idUser != null)
            {
                Context.users.Remove(idUser);
                Console.WriteLine("Deleted");
                Context.SaveChanges();
            }
            else {Console.Clear(); Console.WriteLine("You Wrote False Id. Try Again");PrintCommand(); }
        }

        public void PrintCommand()
        {
            Console.WriteLine("Go Local Host And Write(WithOut Character) : \n" +
                "For Add New User : 'add'\nFor Delete With Id : 'delete'\n" +
                "For Look All User : 'all'.");
        }

        public void Menu()
        {
            PrintCommand();
            new WebHost(27001).Run();
            #region MenuStayComment
            //Console.Write($"1. All User\n2. Add User\n3. Delete User\nMake Choise : ");
            //var cK = Console.ReadKey();
            //switch (cK.Key)
            //{
            //    case ConsoleKey.D1:
            //        AllUser();
            //        break;
            //    case ConsoleKey.D2:
            //        Console.Clear();//////////////////////////////////Menu .... 
            //        go1:
            //        Console.Write("Enter Name : ");
            //        var name = Console.ReadLine();
            //        Console.Write("Enter SurName : ");
            //        var lastName = Console.ReadLine();
            //        if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(lastName) && !string.IsNullOrWhiteSpace(name)&& !string.IsNullOrWhiteSpace(lastName))
            //        {
            //            User user = new User { Name = name, LastName = lastName };
            //            Add_User(user);
            //        }
            //        else { Console.Clear(); Console.WriteLine("You Entered False Parametre"); goto go1; }
            //        break;
            //    case ConsoleKey.D3:
            //        Console.Write("Enter Id :");
            //        int id = int.Parse(Console.ReadLine());
            //        Delete_User(id);
            //        break;
            #endregion // dont open from comment
        }
    }
}

