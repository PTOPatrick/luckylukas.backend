using API.DTOs;
using API.Entities;
using API.Interfaces;
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
        private readonly ISteamRepository _repository;
        public SteamAccountController(ISteamRepository repository)
        {
            _repository = repository;
        }
        
        [HttpPost]
        public async Task<ActionResult<string>> CreateSteamAccount(SteamAccountDto steamAccountDto) {
            await _repository.CreateSteamAccountEntry(steamAccountDto);
            return Ok("entry has been created");
        }

        [HttpGet]
        public ActionResult<IEnumerable<SteamAccountDto>> GetSteamAccounts() {
            return Ok(JsonConvert.SerializeObject(_repository.GetSteamAccounts()));
        }

        [HttpGet("{accountName}")]
        public ActionResult<IEnumerable<SteamAccountDto>> GetSteamAccount(string accountName) {
            return Ok(JsonConvert.SerializeObject(_repository.GetSteamAccount(accountName)));
        }

        [HttpPut("{steamAccountDto}")]
        public ActionResult<IEnumerable<SteamAccountDto>> UpdateSteamAccount(SteamAccountDto steamAccountDto) {
            var account = _repository.GetSteamAccount(steamAccountDto.AccountName);
            if (account == null) Ok($"account with name {steamAccountDto.AccountName} not found");
            return Ok(JsonConvert.SerializeObject(account));
        }

        [HttpDelete("{accountName}")]
        public ActionResult<IEnumerable<SteamAccountDto>> DeleteSteamAccount(string accountName) {
            var account = _repository.GetSteamAccount(accountName);
            if (account == null) return Ok($"account with name {accountName} not found");
            return Ok(JsonConvert.SerializeObject(account));
        }
    }
}