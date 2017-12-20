namespace CloudProject.Models
{
    public class ImageFile
    {
        public string _id { get; set; }    // file name
        public string _rev { get; set; }
        public string filetype { get; set; }    // .jpg .png .gif etc...
        public string data { get; set; }    // file as Base64
    }

    public class ImageFileNoRev
    {
        public string _id { get; set; }    // file name
        public string filetype { get; set; }    // .doc .pdf .jpg .png etc...
        public string data { get; set; }    // file as Base64

        public ImageFileNoRev(ImageFile file) {
            this._id = "id:" + file._id;
            this.filetype = file.filetype;
            this.data = file.data;
        }
    }
}