using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rasdoc.API.Extensions;
using Rasdoc.DTO.Models;
using Rasdoc.Entities.Models;
using RasDoc.Domain.Interfaces;

namespace RasDoc.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class EquipeController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IEquipeRepository _equipeRepository;

        public EquipeController(INotifier notifier,
                                IMapper mapper,
                                IEquipeRepository equipeRepository) : base(notifier)
        {
            _mapper = mapper;
            _equipeRepository = equipeRepository;
        }

        [ClaimsAuthorize("Equipe", "Get")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var equipe = _mapper.Map<IEnumerable<EquipeDTO>>(await _equipeRepository.CustomSearchAsync());

            if (! equipe.Any())
            {
                return NotFound();
            }

            return CustomResponse(equipe);
        }

        [ClaimsAuthorize("Equipe", "GetAll")]
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var equipe = _mapper.Map<IEnumerable<EquipeDTO>>(await _equipeRepository.CustomSearchAsync(e => e.Id == id));

            if (! equipe.Any())
            {
                return NotFound();
            }

            return CustomResponse(equipe);
        }

        [ClaimsAuthorize("Equipe", "Post")]
        [HttpPost]
        public async Task<IActionResult> Post(EquipeDTO equipeDTO)
        {
            if (! ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            equipeDTO.Id = Guid.NewGuid();
            await _equipeRepository.AddAsync(_mapper.Map<Equipe>(equipeDTO));

            return CustomResponse(equipeDTO);
        }

        [ClaimsAuthorize("Equipe", "Put")]
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Put(Guid id, EquipeDTO equipeDTO)
        {
            if (! ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            if (id.ToString().ToUpper() != equipeDTO.Id.ToString().ToUpper())
            {
                NotifyError("O id do objeto é diferente do id solicitado.");
                return CustomResponse();
            }

            if (! _equipeRepository.CustomSearchAsync(e => e.Id == id).Result.Any())
            {
                return NotFound();
            }

            await _equipeRepository.UpdateAsync(_mapper.Map<Equipe>(equipeDTO));

            return CustomResponse(equipeDTO);
        }

        [ClaimsAuthorize("Equipe", "Delete")]
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (! _equipeRepository.CustomSearchAsync(e => e.Id == id).Result.Any())
            {
                return NotFound();
            }

            await _equipeRepository.RemoveAsync(id);

            return CustomResponse();
        }
    }
}
