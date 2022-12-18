using API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Authorize]
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
            accounts.Add(new SteamAccountDto {
                Name = "Name2",
                CsRank = "Silver 2",
                Owner = "LuckyLukas 3",
                Created = DateTime.UtcNow,
                Changed = DateTime.UtcNow,
                IsBanned = false
            });
            accounts.Add(new SteamAccountDto {
                Name = "Name3",
                CsRank = "Silver 3",
                Owner = "LuckyLukas 3",
                Created = DateTime.UtcNow,
                Changed = DateTime.UtcNow,
                IsBanned = false
            });
            accounts.Add(new SteamAccountDto {
                Name = "Name4",
                CsRank = "Silver 4",
                Owner = "LuckyLukas 4",
                Created = DateTime.UtcNow,
                Changed = DateTime.UtcNow,
                IsBanned = false
            });
            accounts.Add(new SteamAccountDto {
                Name = "Name5",
                CsRank = "Silver 5",
                Owner = "LuckyLukas 5",
                Created = DateTime.UtcNow,
                Changed = DateTime.UtcNow,
                IsBanned = false
            });
            return Ok(JsonConvert.SerializeObject(accounts));
        }
    }
}