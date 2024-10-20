using System.Net;

//code yoxlamq ucun mutleq pathleri deyisin add migration edin

namespace ServerSqlHttp
{
    class WebHost
    {
        private int _port;
        private HttpListener _listener;
        public WebHost(int port)
        {
            _port = port;
        }

        public void Run()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add($"http://localhost:{_port}/");

            _listener.Start();

            while (true)
            {
                var context = _listener.GetContext();

                _ = Task.Run(() => { RequestHandle(context); });
            }
        }

        private void RequestHandle(HttpListenerContext context)
        {
            var str = context.Request.RawUrl;
            var response = context.Response;
            Server server = new Server();

            var path = string.Empty;
            var stm = response.OutputStream;

            if (!string.IsNullOrWhiteSpace(str) && str.EndsWith("add", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
            go1:
                path = @"C:\Users\ASUS\Downloads\ServerSqlHttp\ServerSqlHttp\HtmlMessages\AddSimplePage.html"; //if you want my code change all path
                var bb = File.ReadAllBytes(path);
                stm.Write(bb);
                try
                {
                    Console.Write("Enter Name : ");
                    var name = Console.ReadLine();
                    Console.Write("Enter SurName : ");
                    var lastName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(lastName) && !string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(lastName))
                    {
                        User user = new User { Name = name, LastName = lastName };
                        server.Add_User(user);
                    }
                    else { Console.Clear(); Console.WriteLine("You Entered False Parametre"); goto go1; }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("False!");
                    server.PrintCommand();
                }
            }
            if (!string.IsNullOrWhiteSpace(str) && str.EndsWith("delete", StringComparison.OrdinalIgnoreCase))
            {
                path = @"C:\Users\ASUS\Downloads\ServerSqlHttp\ServerSqlHttp\HtmlMessages\DeleteUser.html"; // bunlar frontend dir path leri deyisib yoxlayin html messagedeki
                                                                                                            // elemetlerin pathlerini buraya copy edin! Bu menim htmlin pathi dir deyismelisiz
                var bb = File.ReadAllBytes(path);
                stm.Write(bb);
                Console.Write("Enter Id :");
                int id = int.Parse(Console.ReadLine()!);
                server.Delete_User(id);
            }
            if (!string.IsNullOrWhiteSpace(str) && str.EndsWith("all", StringComparison.OrdinalIgnoreCase))
            {
                server.AllUser();
                path = @"C:\Users\ASUS\Downloads\ServerSqlHttp\ServerSqlHttp\HtmlMessages\AllUser.html";
                var htm = File.ReadAllBytes(path);
                stm.Write(htm);
            }

            var stream = response.OutputStream;

            try
            {
                response.ContentType = Path.GetExtension(path) == ".png" ? "image/jpg" : "text/html";
                var src = File.ReadAllBytes(path);
                stream.Write(src);
            }
            catch
            {
                var src = File.ReadAllBytes(@$"C:\Users\ASUS\Downloads\ServerSqlHttp\ServerSqlHttp\HtmlMessages\404.html");
                stream.Write(src);
            }
            finally
            {
                stream.Close();
            }
        }
    }
}
