using System.Text;

namespace Contoso.Aids; 
public static class GetRandom {
    private static readonly Random r = new();
    public static int Int32(int min = int.MinValue, int max = int.MaxValue) {
        if (min.CompareTo(max) == 0) return min;
        if (min.CompareTo(max) > 0) return r.Next(max, min);
        return r.Next(min, max);
    }
    public static char Char(char min = char.MinValue, char max = char.MaxValue) 
        => (char)Int32(min, max);
    public static string String(byte minLenght = 5, byte maxLenght = 10) {
        var b = new StringBuilder();
        var size = Int32(minLenght, maxLenght);
        for (var i = 0; i < size; i++) b.Append(Char('a', 'z'));
        return b.ToString();
    }
    public static double Double(double min = double.MinValue, double max = double.MaxValue)
        => min + (r.NextDouble() * (max - min));
    public static decimal Decimal(decimal min = decimal.MinValue, decimal max = decimal.MaxValue) {
        if (min == max) return min;
        return Safe.Run(() => Convert.ToDecimal(Double(Convert.ToDouble(min), Convert.ToDouble(max))), min);
    }
    public static long Int64(long min = long.MinValue, long max = long.MaxValue) 
        => min + (long) (r.NextDouble() * (max - min));
    public static DateTime DateTime(DateTime? min = null, DateTime? max = null) {
        var end = max ?? System.DateTime.MaxValue;
        var start = min ?? System.DateTime.MinValue;
        return new DateTime(Int64(start.Ticks, end.Ticks));
    }
    public static T Enum<T>() where T : Enum => (T) Enum(typeof(T));  
    public static dynamic Enum(Type t) {
        var values = System.Enum.GetValues(t);
        return values.GetValue(r.Next(values.Length));
    }
    public static T Value<T>() => Value(typeof(T))?? default(T);
    public static dynamic Value(Type t) {
        if (t.IsEnum) return Enum(t);
        if (t == typeof(string)) return String();
        if (t == typeof(char) || t == typeof(char?)) return Char();
        if (t == typeof(int) || t == typeof(int?)) return Int32();
        if (t == typeof(long) || t == typeof(long?)) return Int64();
        if (t == typeof(double) || t == typeof(double?)) return Double();
        if (t == typeof(DateTime) || t == typeof(DateTime?)) return DateTime();
        if (t == typeof(decimal) || t == typeof(decimal?)) return Decimal();
        return null;
    }
}
