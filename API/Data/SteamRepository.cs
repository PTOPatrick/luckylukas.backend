using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class SteamRepository : ISteamRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public SteamRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task CreateSteamAccountEntry(SteamAccountDto steamAccountDto)
        {
            var steamAccount = _mapper.Map<SteamAccount>(steamAccountDto);
            var blub = await _context.SteamAccounts.AddAsync(steamAccount);
        }

        public async Task<SteamAccountDto> GetSteamAccount(string accountName)
        {
            var steamAccount = await _context.SteamAccounts.Where(x => x.AccountName == accountName).FirstOrDefaultAsync<SteamAccount>();
            var steamAccountDto = _mapper.Map<SteamAccountDto>(steamAccount);
            return steamAccountDto;
        }

        public async Task<IEnumerable<SteamAccountDto>> GetSteamAccounts()
        {
            var steamAccounts = await _context.SteamAccounts.ToListAsync<SteamAccount>();
            var steamAccountDtos = _mapper.Map<List<SteamAccountDto>>(steamAccounts);
            return steamAccountDtos;
        }

        public async Task UpdateSteamAccount(SteamAccountDto steamAccountDto)
        {
            var steamAccount = await _context.SteamAccounts.Where<SteamAccount>(x => x.AccountName == steamAccountDto.AccountName).FirstAsync<SteamAccount>();
            _context.Entry(steamAccount).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task<bool> DeleteSteamAccount(int id)
        {
            var account = await _context.SteamAccounts.Where(x => x.Id == id).FirstOrDefaultAsync<SteamAccount>();
            if (account == null) return false;
            _context.SteamAccounts.Remove(account);
            return true;
        }
    }
}