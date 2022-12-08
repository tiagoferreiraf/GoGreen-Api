using GoGreenApi.Models;
using GoGreenApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GoGreenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IUserRepository _userRepo;
        private readonly ICompanyRepository _companyRepo;
        public LoginController(IUserRepository userRepo, ICompanyRepository companyRepo)
        {
            _userRepo = userRepo;
            _companyRepo = companyRepo;

        }

        [HttpPost]
        public async Task<ActionResult<LoginModel>> RegisterCompany(LoginModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userRepo.SearchUserByEmail(login.Email);
                    
                    if (user != null)
                    {

                        return Ok(new
                        {
                            userType = "user",
                            user,
                        }) ;
                    }
                    var company = await _companyRepo.SearchCompanyByEmail(login.Email);
                    if(company != null)
                    {
                        return Ok(new 
                        {
                            userType = "Company",
                            user = new CompanyModel {
                            Name = company.Name,
                            ImageUrl = company.ImageUrl,
                            Email= company.Email,
                            Password = company.Password,
                            City = company.City,
                            State= company.State,
                            Cep= company.Cep,
                            Date= company.Date,
                            Category = company.Category,
                            Description = company.Description,
                        }
                        });
                      
                    }
              
                }

                return NotFound("usuario não encontrado.");

            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
