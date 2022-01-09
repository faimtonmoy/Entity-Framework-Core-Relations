namespace EfCoreRelations
{
    public class Character
    {
        public int id { get; set; }
        public string name { get; set; }= String.Empty;
        public string RgpClass { get; set; } = "Knight";
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
