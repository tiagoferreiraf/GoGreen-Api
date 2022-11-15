using GoGreenApi.Models;

namespace GoGreenApi.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        Task<List<CompanyModel>> GetAllCompanys();
        Task<CompanyModel> SearchById(int id);
        Task<CompanyModel> AddCompany(CompanyModel company);
        Task<CompanyModel> UpdateCompany(CompanyModel company, int id);
        Task<bool> DeleteCompany(int id);
    }
}
