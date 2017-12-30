using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CloudProject.Models
{
    public class ImageFile
    {
        public string _id { get; set; }    // file name
        public string _rev { get; set; }
        public string filetype { get; set; }    // .jpg .png .gif etc...
        public string data { get; set; }    // file as Base64

        public ImageFile(Helpers.ImageDoc doc) {
            _id = doc.Id;
            _rev = doc.Rev;
            filetype = doc.Filetype;
            data = doc.Data;
        }
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