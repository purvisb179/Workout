namespace App.Enum;

public static class EnumExtensions
{ 
    private static TReturn? Get<TAttribute, TReturn>(this System.Enum enumeration) where TAttribute : BaseAttribute
    {
        var type = enumeration.GetType();
        var memInfo = type.GetMember(enumeration.ToString());
        if (memInfo.Length <= 0) return default;
        var attrs = memInfo[0].GetCustomAttributes(typeof(TAttribute), false);
        return attrs.Length > 0 ? (TReturn?)((TAttribute)attrs[0]).Content : default;
    }
    
    public static string GetDisplayName(this System.Enum enumeration)
    {
        return Get<DisplayName, string>(enumeration) ?? string.Empty;
    }
    
    public static MuscleGroup GetMuscleGroup(this System.Enum enumeration)
    {
        return Get<MuscleGroupAttribute, MuscleGroup>(enumeration);
    }
    
    public static IEnumerable<TEnum> GetEnumerable<TEnum>()
        where TEnum : struct
    {
        if (!typeof(TEnum).IsEnum) throw new InvalidOperationException();
        return System.Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
    }
}