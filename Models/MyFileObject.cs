namespace CloudProject.Models
{
    public class MyFileObject
    {
        public int ID { get; set; } //file ID
        public string TypeFile { get; set; } //.doc .pdf .jpg .png etc...
        public string NameFile { get; set; } //Name of file
        public byte[] ByteFile { get; set; } //Bytes of file

        public MyFileObject()
        {

        }
    }
}