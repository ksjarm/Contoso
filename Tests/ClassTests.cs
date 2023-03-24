namespace Tests
{
    public abstract class ClassTests<TClass, TBaseClass> : BaseTests<TClass, TBaseClass> where TClass : new()
    {
        protected override TClass createObj() => new();
    }
}
