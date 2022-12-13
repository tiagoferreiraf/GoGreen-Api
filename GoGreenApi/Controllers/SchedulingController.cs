using GoGreenApi.Models;
using GoGreenApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GoGreenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulingController : ControllerBase
    {
        private readonly ISchedulingRepository _schedulingRepo;
        private readonly IUserRepository _userRepo;
        public SchedulingController(ISchedulingRepository schedulingRepo, IUserRepository userRepo)
        {
            _schedulingRepo = schedulingRepo;
            _userRepo = userRepo;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<SchedulingModel>>> GetAllUsers()
        {
            try
            {
                List<SchedulingModel> schedulings = await _schedulingRepo.GetAllSchedulings();
                if(schedulings != null) return Ok(schedulings);

                return NotFound();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }


        [HttpGet("search/{id}")]
        public async Task<ActionResult<SchedulingModel>> GetById(int id)
        {
            try
            {
                SchedulingModel scheduling = await _schedulingRepo.SearchById(id);
                var user = await _userRepo.SearchById(scheduling.IdUsuario);

                return Ok(new
                {
                    Agendamento = new SchedulingUserModel
                    {
                        Product = scheduling.Product,
                        StatusScheduling = scheduling.StatusScheduling,
                        Category = scheduling.Category,
                        DescriptionProduct = scheduling.DescriptionProduct ,
                        Name = user.Name,
                        Email = user.Email,
                        City = user.City,
                        State = user.City,
                        Cep = user.Cep,
                        Address = user.Address,
                    }
             });
               
            }
            catch (Exception ex)
            {

                throw;
            }
           

        }
        [HttpPost("register")]
        public async Task<ActionResult<SchedulingModel>> RegisterUser([FromBody] SchedulingModel newScheduling)
        {
            try
            {
                SchedulingModel scheduling = await _schedulingRepo.AddScheduling(newScheduling);

                return Ok(scheduling);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<SchedulingModel>> UpdateScheduling([FromBody] SchedulingModel scheduling, int id)
        {
            try
            {
                scheduling.Id = id;
                SchedulingModel lScheduling = await _schedulingRepo.UpdateScheduling(scheduling, id);
                return Ok(lScheduling);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<SchedulingModel>> DeleteScheduling(int id)
        {
            try
            {
                bool schedulingDeleted = await _schedulingRepo.DeleteScheduling(id);
                return Ok(schedulingDeleted);
            }
            catch (Exception ex)
            {

                throw;
            }
         

        }

    }
}
