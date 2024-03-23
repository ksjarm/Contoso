using System.ComponentModel;
using System.Reflection;

namespace Contoso.Aids;
public static class EnumHelper {
    public static string GetDescription<T>(T enumValue) where T : Enum {
        var memberInfo = typeof(T).GetMember(enumValue.ToString()).FirstOrDefault();
        var descriptionAttribute = memberInfo?.GetCustomAttribute<DescriptionAttribute>();
        return descriptionAttribute?.Description ?? enumValue.ToString();
    }
}