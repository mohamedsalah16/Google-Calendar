using google_calendar1.Helper;
using google_calendar1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace google_calendar1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateGoogleCalendar([FromBody] GoogleCalendar request)
        {
            return Ok(await GoogleCalendarHelper.CreateGoogleCalendar(request));
        }
    }
}
