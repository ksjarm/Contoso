using Contoso.Data.Base;
using Contoso.Domain.Base;
using Contoso.Aids;

namespace Contoso.Facade.Base; 
public abstract class PersonViewFactory<TData, TObject, TView> : BaseViewFactory<TData, TObject, TView>
    where TData : PersonData, new() where TObject : Person<TData> where TView : PersonView, new() {
    protected internal override void copy(TView v, TData d) {
        base.copy(v, d);
        d.PhotoFile = v?.PhotoUpload?.FileName;
        d.PhotoFileType = Path.GetExtension(d.PhotoFile)?.Trim('.');
		if (v?.PhotoUpload is null) {
			d.Photo = PhotoHelper.GetDefaultPhotoBytes();
		} else {
			var stream = new MemoryStream();
			v.PhotoUpload.CopyTo(stream);
			if (stream.Length < 2097152) d.Photo = stream.ToArray();
		}
	}
    protected internal override void copy(TData d, TView v) {
        base.copy(d, v);
        if (d.Photo is null) {
            v.PhotoView = "/photos/defaultPhoto.jpg";
        } else {
            string s = Convert.ToBase64String(d.Photo, 0, d.Photo.Length);
            v.PhotoView = "data:image/jpg;base64," + s;
        }
    }
}