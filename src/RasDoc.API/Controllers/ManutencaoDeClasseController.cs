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
    public class ManutencaoDeClasseController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IManutencaoDeClasseRepository _manutencaoDeClasseRepository;

        public ManutencaoDeClasseController(INotifier notifier,
                                IMapper mapper,
                                IManutencaoDeClasseRepository manutencaoDeClasseRepository) : base(notifier)
        {
            _mapper = mapper;
            _manutencaoDeClasseRepository = manutencaoDeClasseRepository;
        }

        [ClaimsAuthorize("ManutencaoDeClasse", "Get")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var manutencaoDeClasse = _mapper.Map<IEnumerable<ManutencaoDeClasseDTO>>(await _manutencaoDeClasseRepository.CustomSearchAsync());

            if (! manutencaoDeClasse.Any())
            {
                return NotFound();
            }

            return CustomResponse(manutencaoDeClasse);
        }

        [ClaimsAuthorize("ManutencaoDeClasse", "GetAll")]
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var manutencaoDeClasse = _mapper.Map<IEnumerable<ManutencaoDeClasseDTO>>(await _manutencaoDeClasseRepository.CustomSearchAsync(m => m.Id == id));

            if (! manutencaoDeClasse.Any())
            {
                return NotFound();
            }

            return CustomResponse(manutencaoDeClasse);
        }

        [ClaimsAuthorize("ManutencaoDeClasse", "Post")]
        [HttpPost]
        public async Task<IActionResult> Post(ManutencaoDeClasseDTO manutencaoDeClasseDTO)
        {
            if (! ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            manutencaoDeClasseDTO.Id = Guid.NewGuid();
            await _manutencaoDeClasseRepository.AddAsync(_mapper.Map<ManutencaoDeClasse>(manutencaoDeClasseDTO));

            return CustomResponse(manutencaoDeClasseDTO);
        }

        [ClaimsAuthorize("ManutencaoDeClasse", "Put")]
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Put(Guid id, ManutencaoDeClasseDTO manutencaoDeClasseDTO)
        {
            if (! ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            if (id.ToString().ToUpper() != manutencaoDeClasseDTO.Id.ToString().ToUpper())
            {
                NotifyError("O id do objeto é diferente do id solicitado.");
                return CustomResponse();
            }

            if (! _manutencaoDeClasseRepository.CustomSearchAsync(m => m.Id == id).Result.Any())
            {
                return NotFound();
            }

            await _manutencaoDeClasseRepository.UpdateAsync(_mapper.Map<ManutencaoDeClasse>(manutencaoDeClasseDTO));

            return CustomResponse(manutencaoDeClasseDTO);
        }

        [ClaimsAuthorize("ManutencaoDeClasse", "Delete")]
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (! _manutencaoDeClasseRepository.CustomSearchAsync(m => m.Id == id).Result.Any())
            {
                return NotFound();
            }

            await _manutencaoDeClasseRepository.RemoveAsync(id);

            return CustomResponse();
        }
    }
}
