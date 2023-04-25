namespace Contoso.Aids;
public static class Copy {
    public static void Members<TFrom, TTo>(TFrom from, TTo to) 
        where TFrom : class
        where TTo : class{
        
        if (from is null) return;
        if (to is null) return;
        foreach (var property in to.GetType().GetProperties()) {
            if (!property.CanWrite) continue;
            var name = property.Name;
            var p = from.GetType().GetProperty(name);
            if (p is null) continue;
            var v = p.GetValue(from);
            Safe.Run(() => property?.SetValue(to, v));
        }
    }
}

