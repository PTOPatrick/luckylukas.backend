using API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SteamAccountController : ControllerBase
    {
        public SteamAccountController()
        {
            // tbd
        }

        [HttpGet]
        public ActionResult<IEnumerable<SteamAccountDto>> GetSteamAccounts() {
            var accounts = new List<SteamAccountDto>();
            accounts.Add(new SteamAccountDto {
                Name = "Name1",
                CsRank = "Silver 1",
                Owner = "LuckyLukas 1",
                Created = DateTime.UtcNow,
                Changed = DateTime.UtcNow,
                IsBanned = false
            });
            return Ok(JsonConvert.SerializeObject(accounts));
        }
    }
}