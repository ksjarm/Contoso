using Contoso.Data.Base;

namespace Contoso.Domain.Base;
public abstract class Person<TData> : NamedEntity<TData> where TData : PersonData, new() {
    protected Person(TData d) : base(d) { }
    public string FirstName => getValue(data.FirstName);
    public string FullName => Name + ", " + FirstName;
}