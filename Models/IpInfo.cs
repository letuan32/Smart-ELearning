namespace Smart_ELearning.Models
{
    public class IpInfo
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public bool IsBlock { get; set; }
        public int StudentId { get; set; }
        public int LimitAccount { get; set; }
    }
}