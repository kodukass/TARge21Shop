using Microsoft.AspNetCore.Mvc;
using TARge21Shop.Data;
using TARge21Shop1.Models.Spaceship;

namespace TARge21Shop.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly TARge21ShopContext _context;

        public SpaceshipsController
            (
                TARge21ShopContext context
            )
        {
        _context = context;
        //int rownumber = SpaceshipIndexViewModel();
        }

        public IActionResult Index()
        {
            var result = _context.Spaceships
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new SpaceshipIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    Passangers = x.Passangers,
                    EnginePower = x.EnginePower
                });
            return View();
        }
    }
}
