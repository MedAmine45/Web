using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAtrioEmployeManagement.Data;

namespace WebAtrioEmployeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnesController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public PersonnesController(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));


        }
    }
}
