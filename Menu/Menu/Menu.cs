namespace Menu;
public class Menu
{
    public List<MenuLine> _menuLines { get; set; }
    private int _option = 1;
    private bool isSelected = false;
    private readonly string _selected = "> \u001b[32m";
    public Menu(List<MenuLine> menuLines)
    {
        _menuLines = menuLines;
    }
    public Menu()
    {
        _menuLines = new List<MenuLine>();
    }
    public void Print()
    {
        for (int i = 0; i < _menuLines.Count; i++)
        {
            Console.WriteLine($"{(_option == i + 1 ? _selected : "  ")}{_menuLines[i]}\u001b[0m");
        }
        Console.WriteLine($"{(_option == _menuLines.Count + 1 ? _selected : "  ")}{_menuLines.Count + 1}. Exit\u001b[0m");
    }
    public void Add(MenuLine menuLine)
    {
        _menuLines.Add(menuLine);
    }
    public void Add(string text, string command, int indentation)
    {
        _menuLines.Add(new MenuLine(text, command, indentation));
    }
    private int ReadOption()
    {
        while (!isSelected)
        {
            Console.Clear();
            Print();
            Console.SetCursorPosition(0, 0);
            ConsoleKeyInfo _key = Console.ReadKey();
            switch (_key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (_option > 1)
                    {
                        _option--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (_option < _menuLines.Count + 1)
                    {
                        _option++;
                    }
                    break;
                case ConsoleKey.Enter:
                    isSelected = true;
                    break;
            }
        }
        isSelected = false;
        return _option;
    }
    public string GetFunction()
    {
        _option = ReadOption();
        if (_option == _menuLines.Count + 1)
        {
            return "Exit";
        }
        MenuLine selectedLine = _menuLines[_option - 1];
        Console.Clear();
        if (selectedLine.GetCommand() != null)
        {
            return selectedLine.GetCommand();
        }
        else
        {
            return string.Empty;
        }
    }
}