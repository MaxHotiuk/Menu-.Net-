namespace Menu;

class MenuLine
{
    private readonly string _text;
    private readonly string _command;
    private readonly int _indentation;

    public MenuLine(string text, string command, int indentation)
    {
        _text = text;
        _command = command;
        _indentation = indentation;
    }
    public override string ToString()
    {
        return $"{_indentation}. {_text}";
    }
    public string GetCommand()
    {
        return _command;
    }
}