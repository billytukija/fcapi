using Microsoft.AspNetCore.Mvc;
using found_church_api.Services;
using found_church_api.DataObjectTransfert;

namespace found_church_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChurchesController : ControllerBase
    {
        private readonly ChurchesService _churchesService;

        public ChurchesController(ChurchesService churchesService) =>
            _churchesService = churchesService;

        [HttpGet]
        public async Task<List<ChurchDto>> Get() =>
             await _churchesService.GetAsync();

        [HttpGet("findBy/{search}")]
        public async Task<List<ChurchDto>> Get([FromRoute] String search) =>
             await _churchesService.GetBySearch(search);
    }
}
