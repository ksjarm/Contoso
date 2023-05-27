namespace Contoso.Data.Base;
public abstract class PersonData : NamedData {
    public string FirstName { get; set; }
    public IsoGender Gender { get; set; }
    public byte[] Photo { get; set; }
    public string PhotoFile { get; set; }
    public string PhotoFileType { get; set; }
}