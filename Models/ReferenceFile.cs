namespace CarteAPI.Models
{
    public class ReferenceFile
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; } // Path to the file on the server
        public byte[] FileData { get; set; } // File data stored in the database
    }
}
