using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ISteamRepository
    {
        Task CreateSteamAccountEntry(SteamAccountDto steamAccount);
        Task<IEnumerable<SteamAccountDto>> GetSteamAccounts();
        Task<SteamAccountDto> GetSteamAccount(string accountName);
        Task UpdateSteamAccount(SteamAccountDto steamAccount);
        Task<bool> DeleteSteamAccount(int id);
    }
}