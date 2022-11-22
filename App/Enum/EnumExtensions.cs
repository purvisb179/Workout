using System.ComponentModel;
using System.Reflection;

namespace App.Enum;

public static class EnumExtensions
{
    private static string Get<T>(this System.Enum enumeration) where T : BaseAttribute
    {
        var type = enumeration.GetType();
        var memInfo = type.GetMember(enumeration.ToString());
        
        if (memInfo.Length <= 0) return enumeration.ToString();
        var attrs = memInfo[0].GetCustomAttributes(typeof(T), false);
        return attrs.Length > 0 ? ((T)attrs[0]).Text : enumeration.ToString();
    }
    
    public static string GetDisplayName(this System.Enum enumeration)
    {
        return Get<DisplayName>(enumeration);
    }
    
    public static string GetCategory(this System.Enum enumeration)
    {
        return Get<Category>(enumeration);
    }
}