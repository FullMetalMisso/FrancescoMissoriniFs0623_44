namespace EsercizioPomeridiano
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ScriviMenu();
        }

        public static void ScriviMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("==============OPERAZIONI===============");
            Console.WriteLine("Scegli l'operazione da effettuare:");
            Console.WriteLine("1.: Login");
            Console.WriteLine("2.: Logout");
            Console.WriteLine("3.: Verifica ora e data di login");
            Console.WriteLine("4.: Lista degli accessi");
            Console.WriteLine("5.: Esci");

            var scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    User.Login();
                    break;
                case "2":
                    User.Logout();
                    break;
                case "3":
                    User.StampaDataEOraLogin();
                    break;
                case "4":
                    User.MostraAccessi();
                    break;
                case "5":
                    return;
            }
            ScriviMenu();
        }
    }

    public static class User
    {
        public static string username;
        private static string password;
        public static bool IsLogged;
        public static List<DateTime> accessi = new List<DateTime>();

        public static void Login()
        {
            Console.WriteLine("Inserisci username:");
            username = Console.ReadLine();

            Console.WriteLine("Inserisci password:");
            password = Console.ReadLine();

            Console.WriteLine("Conferma la password inserita:");
            string conferma = Console.ReadLine();

            if (password == conferma && !string.IsNullOrWhiteSpace(username))
            {
                IsLogged = true;
                accessi.Add(DateTime.Now);
                Console.WriteLine($"Utente correttamente loggato alle ore {DateTime.Now}");
            }
            else
            {
                Console.WriteLine("Non è possibile effettuare il login");
            }
        }

        public static void Logout()
        {
            if (IsLogged)
            {
                username = "";
                password = "";
                IsLogged = false;
                Console.WriteLine("Nessun utente loggato al sistema");
            }
            else
            {
                Console.WriteLine("Non sei loggato!");
            }
        }

        public static void StampaDataEOraLogin()
        {
            if (IsLogged)
            {
                Console.WriteLine($"L'utente {username} ha effettuato l'accesso il {accessi[accessi.Count - 1]}");
            }
            else
            {
                Console.WriteLine("Non risultano utenti loggati a sistema");
            }
        }

        public static void MostraAccessi()
        {
            if (IsLogged)
            {
                foreach (var data in accessi)
                {
                    Console.WriteLine(data);
                }
            }
            else
            {
                Console.WriteLine("Non sei loggato");
            }
        }
    }
}