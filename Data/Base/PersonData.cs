namespace Contoso.Data.Base;
public abstract class PersonData : NamedData {
    public string FirstName { get; set; }
    public IsoGender Gender { get; set; }
    public string Photo { get; set; }
}