using AutoMapper;
using Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanController : Controller
    {
        private readonly IMapper _mapper;

        public PlanController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        public IActionResult CreatePlan(Dtos.PlanTypeDto dto)
        {
            var result = AutoMapperHelper<Entities.Plan, Dtos.PlanTypeDto>.ConvertToEntity(dto, _mapper);

            List<Entities.PlanTag> planTags = new List<Entities.PlanTag>();
            foreach (var tag in dto.Tags)
            {
                planTags.Add(new Entities.PlanTag
                {
                    Tag = new Entities.Tag
                    {
                        Name = tag.Text,
                    },
                    Plan = new Entities.Plan
                    {
                        Name = dto.PlanName
                    }
                });
                
            }
            result.PlanTags = planTags;

            return Ok(result);
        }
    }
}
