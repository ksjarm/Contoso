using Contoso.Data;
using Contoso.Data.Base;

namespace Contoso.Domain.Base;
public abstract class Person<TData> : NamedEntity<TData> where TData : PersonData, new() {
    protected Person(TData d) : base(d) { }
    public string FirstName => getValue(data.FirstName);
    public string FullName => Name + ", " + FirstName;
    public IsoGender Gender => getValue(data.Gender);
    public byte[] Photo => getValue(data.Photo);
    public string PhotoFile => getValue(data.PhotoFile);
    public string PhotoFileType => getValue(data.PhotoFileType);
}