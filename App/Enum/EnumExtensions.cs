using System.ComponentModel;
using System.Reflection;

namespace App.Enum;

public static class EnumExtensions
{ 
    public static string GetDisplayName(this System.Enum enumeration)
    {
        var type = enumeration.GetType();
        var memInfo = type.GetMember(enumeration.ToString());
        
        if (memInfo.Length <= 0) return enumeration.ToString();
        var attrs = memInfo[0].GetCustomAttributes(typeof(DisplayName), false);
        return attrs.Length > 0 ? ((DisplayName)attrs[0]).Text : enumeration.ToString();
    }
    
    public static string GetMuscleGroup(this System.Enum enumeration)
    {
        var type = enumeration.GetType();
        var memInfo = type.GetMember(enumeration.ToString());
        
        if (memInfo.Length <= 0) return enumeration.ToString();
        var attrs = memInfo[0].GetCustomAttributes(typeof(DisplayName), false);
        return attrs.Length > 0 ? ((DisplayName)attrs[0]).Text : enumeration.ToString();
    }
    
    
}