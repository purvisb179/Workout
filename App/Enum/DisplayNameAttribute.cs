namespace App.Enum;

public class DisplayName : Attribute
{
    public readonly string Text;

    public DisplayName(string text)
    {
        Text = text;
    }
}