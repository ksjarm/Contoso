namespace Contoso.Aids; 
public static class PhotoHelper {
	public static byte[] GetDefaultPhotoBytes() {
		byte[] defaultPhotoBytes;
		using (FileStream fileStream = new FileStream("wwwroot/photos/defaultPhoto.jpg", FileMode.Open, FileAccess.Read)) {
			using MemoryStream memoryStream = new MemoryStream();
			fileStream.CopyTo(memoryStream);
			defaultPhotoBytes = memoryStream.ToArray();
		}
		return defaultPhotoBytes;
	}
}