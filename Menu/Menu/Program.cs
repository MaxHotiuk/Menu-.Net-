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

        static async Task Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Add("Option 1", "TryFunction", 1);
            menu.Add("Option 2", "TryFunction2", 1);
            await menu.Run();
        }
    }
}
