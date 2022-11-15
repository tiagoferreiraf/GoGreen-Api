using GoGreenApi.Data;
using GoGreenApi.Models;
using GoGreenApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GoGreenApi.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly GoGreenDbContext _dbContext;

        public CompanyRepository(GoGreenDbContext goGreenCompanyContext)
        {
            _dbContext = goGreenCompanyContext;
        }

        public async Task<CompanyModel> AddCompany(CompanyModel company)
        {
            await _dbContext.Companys.AddAsync(company);
            await _dbContext.SaveChangesAsync();

            return company;
        }

        public async Task<List<CompanyModel>> GetAllCompanys()
        {
            return await _dbContext.Companys.ToListAsync();
        }

        public async Task<CompanyModel> SearchById(int id)
        {
            return await _dbContext.Companys.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CompanyModel> UpdateCompany(CompanyModel company, int id)
        {
            CompanyModel companyForId = await SearchById(id);
            
            if(companyForId == null)
            {
                throw new Exception($"Usúario para o ID:{id} não foi encontrado no banco de dados");
            }

            companyForId.Name = company.Name;

            _dbContext.Companys.Update(companyForId);
            await _dbContext.SaveChangesAsync();

            return companyForId;
        }

        public async Task<bool> DeleteCompany(int id)
        {
            CompanyModel company = await SearchById(id);

            if (company == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Companys.Remove(company);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}

