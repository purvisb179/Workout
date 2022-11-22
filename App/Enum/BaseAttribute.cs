namespace App.Enum;

public class BaseAttribute : Attribute
{
    public readonly string Text;

    protected BaseAttribute(string text)
    {
        Text = text;
    }
}