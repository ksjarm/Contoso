using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace Contoso.Aids;
public static class GetMember {
    public static string Name<T, TResult>(Expression<Func<T, TResult>> ex)
        => Safe.Run(() => name(ex?.Body), null);
    public static string Label<T, TResult>(Expression<Func<T, TResult>> ex)
        => Safe.Run(() => {
            var name = Name(ex);
            return displayName(name, typeof(T));
        }, null);
    private static string displayName(string name, Type t) {
        var p = t?.GetProperty(name);
        var a = p?.GetCustomAttribute<DisplayNameAttribute>(true);
        return a?.DisplayName ?? name;
    }
    private static string name(Expression ex) {
        if (ex is MemberExpression member) return name(member);
        if (ex is MethodCallExpression method) return name(method);
        if (ex is UnaryExpression operand) return name(operand);
        return string.Empty;
    }
    private static string name(MemberExpression ex) => ex?.Member.Name ?? string.Empty;
    private static string name(MethodCallExpression ex) => ex?.Method.Name ?? string.Empty;
    private static string name(UnaryExpression ex) {
        if (ex?.Operand is MemberExpression member) return name(member);
        if (ex?.Operand is MethodCallExpression method) return name(method);
        return string.Empty;
    }
}