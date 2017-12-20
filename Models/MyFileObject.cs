namespace CloudProject.Models
{
    public class MyFile
    {
        public string _id { get; set; }    // file name
        public string _rev { get; set; }
        public string filetype { get; set; }    // .doc .pdf .jpg .png etc...
        public string data { get; set; }    // file as Base64
    }

    public class MyFileNoRev
    {
        public string _id { get; set; }    // file name
        public string filetype { get; set; }    // .doc .pdf .jpg .png etc...
        public string data { get; set; }    // file as Base64

        public MyFileNoRev(MyFile file) {
            this._id = "id:" + file._id;
            this.filetype = file.filetype;
            this.data = file.data;
        }
    }
}