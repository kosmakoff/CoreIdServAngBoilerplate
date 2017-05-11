using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiServer.Controllers
{
    [Authorize]
    [Route("/api/[controller]")]
    public class IdentityController : Controller
    {
        public IActionResult Index()
        {
            return new JsonResult(User.Claims.Select(c => new {c.Type, c.Value}));
        }
    }
}
