namespace Contoso.Aids;
public static class Safe {
    public static T Run<T> (Func<T> f, T def = default) {
        try {
            return f();
        } catch (Exception e) {
            return def;
        }
    }
    public static void Run<T>(Action a) {
        try {
            a();
        } catch (Exception e) { }
    }
    public async static Task<T> RunAsync<T> (Func<Task<T>> f, T def = default) {
        try {
            return await f();
        } catch (Exception e) {
            return def;
        }
    }
    public async static Task RunAsync<T>(Func<Task> a) {
        try {
            await a();
        } catch (Exception e) { }
    }
}
