using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using OneBan_TMS.Interfaces;
using OneBan_TMS.Interfaces.Repositories;
using OneBan_TMS.Models;
using OneBan_TMS.Models.DTOs;
using OneBan_TMS.Models.DTOs.Company;

namespace OneBan_TMS.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly OneManDbContext _context;
        public CompanyRepository(OneManDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Company>> GetCompanies()
        {
            return await _context.Companies.ToListAsync();
        }
        public async Task<Company> GetCompanyById(int companyId)
        {
            var company = await _context
                .Companies
                .Where(x => x.CmpId == companyId)
                .FirstOrDefaultAsync();
            return company;
        }
        public async Task<Company> AddNewCompany(CompanyDto newCompany)
        {
            Company company = newCompany.GetCompany();
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return company;
        }
        public async Task UpdateCompany(CompanyDto updatedCompanyDto, int companyId)
        {
            var companyToUpdate = await _context
                    .Companies
                    .Where(x => x.CmpId == companyId)
                    .SingleOrDefaultAsync();
            if (companyToUpdate is null)
                throw new ArgumentException("Company does not exist");
            companyToUpdate = updatedCompanyDto.GetCompanyToUpdate(companyToUpdate);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCompany(int companyId)
        {
            var company = await _context
                .Companies
                .Where(x =>
                    x.CmpId == companyId)
                .SingleOrDefaultAsync();
            if (company is null)
                throw new ArgumentException("Company does not exist");
            await DeleteAllAddressesForCompany(companyId);
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> IsCompanyExists(int companyId)
        {
            var result = await _context
                .Companies
                .Where(x =>
                    x.CmpId == companyId)
                .AnyAsync();
            return result;
        }

        private async Task DeleteAllAddressesForCompany(int companyId)
        {
            var addresses = await _context.Addresses
                .Where(x =>
                    x.AdrIdCompany == companyId)
                .ToListAsync();
            _context.Addresses.RemoveRange(addresses);
            await _context.SaveChangesAsync();
        }
    }
}