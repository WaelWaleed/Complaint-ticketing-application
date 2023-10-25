using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ComplaintController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            var EntityComplaint = _unitOfWork.Complaint.GetAll();
            var DTOComplaint = _mapper.Map<List<DTO.Complaint>>(EntityComplaint);
            return Ok(DTOComplaint);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int ID)
        {
            var EntityComplaint = _unitOfWork.Complaint.GetByID(ID);
            var DTOComplaint = _mapper.Map<DTO.Complaint>(EntityComplaint);
            return Ok(DTOComplaint);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Create(DTO.Complaint Complaint)
        {
            var EntityComplaint = _mapper.Map<Entity.Complaint>(Complaint);
            _unitOfWork.Complaint.Create(EntityComplaint);
            _unitOfWork.Complete();
            Complaint.ID = EntityComplaint.ID;

            return Ok(Complaint);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.Complaint Complaint)
        {
            var EntityComplaint = _mapper.Map<Entity.Complaint>(Complaint);
            _unitOfWork.Complaint.Update(EntityComplaint);
            _unitOfWork.Complete();
            return Ok(Complaint);
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.Complaint Complaint)
        {
            var EntityComplaint = _mapper.Map<Entity.Complaint>(Complaint);
            _unitOfWork.Complaint.Update(EntityComplaint);
            _unitOfWork.Complete();
            return Ok(Complaint);
        }


    }
}
