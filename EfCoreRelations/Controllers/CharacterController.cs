using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreRelations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly DataContext _context;

        public CharacterController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Character>>> Get(int userId)
        {
            var charcters= await _context.Characters.Where(c=> c.UserId== userId).ToListAsync();
            return charcters;
        }
        [HttpPost]
        public async Task<ActionResult<List<Character>>> Post(CreateCharacterDto request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
                return BadRequest("User is not Found!");
            var newCharacter = new Character
            {
                name = request.name,
                RgpClass = request.RgpClass,
                UserId = request.UserId
        };
            _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();

            return await Get(newCharacter.UserId);
        }
    }
}
