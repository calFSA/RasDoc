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
    public class ProjetoController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IProjetoRepository _projetoRepository;

        public ProjetoController(INotifier notifier,
                                 IMapper mapper,
                                 IProjetoRepository projetoRepository) : base(notifier)
        {
            _mapper = mapper;
            _projetoRepository = projetoRepository;
        }

        [ClaimsAuthorize("Projeto", "Get")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projeto = _mapper.Map<IEnumerable<ProjetoDTO>>(await _projetoRepository.CustomSearchAsync());

            if (! projeto.Any())
            {
                return NotFound();
            }

            return CustomResponse(projeto);
        }

        [ClaimsAuthorize("Projeto", "GetAll")]
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var projeto = _mapper.Map<IEnumerable<ProjetoDTO>>(await _projetoRepository.CustomSearchAsync(e => e.Id == id));

            if (! projeto.Any())
            {
                return NotFound();
            }

            return CustomResponse(projeto);
        }

        [ClaimsAuthorize("Projeto", "Post")]
        [HttpPost]
        public async Task<IActionResult> Post(ProjetoDTO projetoDTO)
        {
            if (! ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            projetoDTO.Id = Guid.NewGuid();
            await _projetoRepository.AddAsync(_mapper.Map<Projeto>(projetoDTO));

            return CustomResponse(projetoDTO);
        }

        [ClaimsAuthorize("Projeto", "Put")]
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Put(Guid id, ProjetoDTO projetoDTO)
        {
            if (! ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            if (id.ToString().ToUpper() != projetoDTO.Id.ToString().ToUpper())
            {
                NotifyError("O id do objeto é diferente do id solicitado.");
                return CustomResponse();
            }

            if (! _projetoRepository.CustomSearchAsync(e => e.Id == id).Result.Any())
            {
                return NotFound();
            }

            await _projetoRepository.UpdateAsync(_mapper.Map<Projeto>(projetoDTO));

            return CustomResponse(projetoDTO);
        }

        [ClaimsAuthorize("Projeto", "Delete")]
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (! _projetoRepository.CustomSearchAsync(e => e.Id == id).Result.Any())
            {
                return NotFound();
            }

            await _projetoRepository.RemoveAsync(id);

            return CustomResponse();
        }
    }
}
