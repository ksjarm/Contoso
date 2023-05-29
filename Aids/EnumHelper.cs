using System.ComponentModel;
using System.Reflection;

namespace Contoso.Aids;
public static class EnumHelper {
    private static readonly Random random = new Random();
    public static string GetDescription<T>(T enumValue) where T : Enum {
        var memberInfo = typeof(T).GetMember(enumValue.ToString()).FirstOrDefault();
        var descriptionAttribute = memberInfo?.GetCustomAttribute<DescriptionAttribute>();
        return descriptionAttribute?.Description ?? enumValue.ToString();
    }
    public static T GetRandomValue<T>() where T : Enum {
        var values = Enum.GetValues(typeof(T));
        return (T)values.GetValue(random.Next(values.Length));
    }
}