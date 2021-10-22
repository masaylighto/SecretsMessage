namespace SecretMessging.Models
{
    public class message
    {
        public int id { get; set; }
        public string content { get; set; }
        public string Url { get; set; }
        public bool IsEncrypted { get; set; }
    }
}
