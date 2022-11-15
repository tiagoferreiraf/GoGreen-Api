using GoGreenApi.Models;
using GoGreenApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoGreenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepo;
        public CompanyController(ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<CompanyModel>>> GetAllCompanys()
        {
            List<CompanyModel> company = await _companyRepo.GetAllCompanys();

            return Ok();
        }


        [HttpGet("search/{id}")]
        public async Task<ActionResult<CompanyModel>> GetById(int id)
        {
            CompanyModel company = await _companyRepo.SearchById(id);

            return Ok(company);

        }
        [HttpPost("register")]
        public async Task<ActionResult<CompanyModel>> RegisterCompany([FromBody] CompanyModel newCompany)
        {
            CompanyModel company = await _companyRepo.AddCompany(newCompany);

            return Ok(company);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<CompanyModel>> UpdateCompany([FromBody] CompanyModel company, int id)
        {
            company.Id = id;
            CompanyModel lCompany = await _companyRepo.UpdateCompany(company, id);
            return Ok(lCompany);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<CompanyModel>> DeleteCompany(int id)
        {
            bool companyDeleted = await _companyRepo.DeleteCompany(id);
            return Ok(companyDeleted);

        }

    }
}
