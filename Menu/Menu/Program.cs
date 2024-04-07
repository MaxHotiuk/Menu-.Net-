// Потрібно зробити GetFunction(), яка буде викликати меню
namespace Menu
{
    public static class Program
    {
        public static void TryFunction()
        {
            Console.WriteLine("This is a test function");
        }
        public static void TryFunction2()
        {
            Console.WriteLine("This is another test function");
        }
        public static void RunMenu(Menu menu)
        {
            string func;
            do
            {
                func = menu.GetFunction();
                if (func != "Exit" && func != null)
                {
                    var methodInfo = typeof(Program).GetMethod(func);
                    if (methodInfo != null)
                    {
                        methodInfo.Invoke(null, null);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                    }
                }
            } while (func != "Exit");
        }
        public static void Main()
        {
            Menu menu = new Menu();
            menu.Add("Option 1", "TryFunction", 1);
            menu.Add("Option 2", "TryFunction2", 1);
            RunMenu(menu);
        }
    }
}
