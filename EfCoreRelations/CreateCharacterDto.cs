namespace EfCoreRelations
{
    public class CreateCharacterDto
    {
        public string name { get; set; } = "character";
        public string RgpClass { get; set; } = "Knight";
        public int UserId { get; set; } = 1;
    }
}
