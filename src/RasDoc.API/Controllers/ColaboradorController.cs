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
    public class ColaboradorController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IReturnUserIdColaboradorService _returnUserIdColaborador;

        public ColaboradorController(INotifier notifier,
                                     IMapper mapper,
                                     IColaboradorRepository colaboradorRepository,
                                     IReturnUserIdColaboradorService returnUserIdColaborador) : base(notifier)
        {
            _mapper = mapper;
            _colaboradorRepository = colaboradorRepository;
            _returnUserIdColaborador = returnUserIdColaborador;
        }

        [ClaimsAuthorize("Colaborador", "Get")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var colaborador = _mapper.Map<IEnumerable<ColaboradorDTO>>(await _colaboradorRepository.CustomSearchAsync());

            if (! colaborador.Any())
            {
                return NotFound();
            }

            return CustomResponse(colaborador);
        }

        [ClaimsAuthorize("Colaborador", "GetAll")]
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var colaborador = _mapper.Map<IEnumerable<ColaboradorDTO>>(await _colaboradorRepository.CustomSearchAsync(c => c.Id == id));

            if (! colaborador.Any())
            {
                return NotFound();
            }

            return CustomResponse(colaborador);
        }

        [ClaimsAuthorize("Colaborador", "Post")]
        [HttpPost]
        public async Task<IActionResult> Post(ColaboradorDTO colaboradorDTO)
        {
            if (! ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            if (! await _returnUserIdColaborador.HasUserColaborador(colaboradorDTO.Id))
            {
                NotifyError("Colaborador não possui login cadastrado.");
                return CustomResponse();
            }

            await _colaboradorRepository.AddAsync(_mapper.Map<Colaborador>(colaboradorDTO));

            return CustomResponse(colaboradorDTO);
        }

        [ClaimsAuthorize("Colaborador", "Put")]
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Put(Guid id, ColaboradorDTO colaboradorDTO)
        {
            if (! ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            if (id.ToString().ToUpper() != colaboradorDTO.Id.ToString().ToUpper())
            {
                NotifyError("O id do objeto é diferente do id solicitado.");
                return CustomResponse();
            }

            if (! _colaboradorRepository.CustomSearchAsync(c => c.Id == id).Result.Any())
            {
                return NotFound();
            }

            await _colaboradorRepository.UpdateAsync(_mapper.Map<Colaborador>(colaboradorDTO));

            return CustomResponse(colaboradorDTO);
        }

        [ClaimsAuthorize("Colaborador", "Delete")]
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (! _colaboradorRepository.CustomSearchAsync(c => c.Id == id).Result.Any())
            {
                return NotFound();
            }

            await _colaboradorRepository.RemoveAsync(id);

            return CustomResponse();
        }
    }
}
