namespace API.DTOs
{
    public class SteamAccountDto
    {
        public string AccountName { get; set; }
        public string Name { get; set; }
        public string CsRank { get; set; }
        public string Owner { get; set; }
        public DateTime Created { get; set; }
        public DateTime Changed { get; set; }
        public bool IsBanned { get; set; }
    }
}