using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll() 
        {
            var EntityUser = _unitOfWork.User.GetAll();
            var DTOUser = _mapper.Map<List<DTO.User>>(EntityUser);
            return Ok(DTOUser);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult GetByID(int id) 
        {
            var EntityUser = _unitOfWork.User.GetByID(id);
            var DTOUser = _mapper.Map<DTO.User>(EntityUser);
            return Ok(DTOUser);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Create(DTO.User User)
        {
            var EntityUser = _mapper.Map<Entity.User>(User);
            _unitOfWork.User.Create(EntityUser);
            _unitOfWork.Complete();
            User.ID = EntityUser.ID;

            return Ok(User);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.User User)
        {
            var EntityUser = _mapper.Map<Entity.User>(User);
            _unitOfWork.User.Update(EntityUser);
            _unitOfWork.Complete();
            return Ok(User);
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.User User)
        {
            var EntityUser = _mapper.Map<Entity.User>(User);
            _unitOfWork.User.Delete(EntityUser);
            _unitOfWork.Complete();
            return Ok(User);
        }
    }
}
