namespace App.Enum;

public class BaseAttribute : Attribute
{
    public readonly object Content;

    protected BaseAttribute(object content)
    {
        Content = content;
    }
}