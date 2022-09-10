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
        private readonly IProjetoColaboradorRepository _projetoColaboradorRepository;

        public ProjetoController(INotifier notifier,
                                 IMapper mapper,
                                 IProjetoRepository projetoRepository,
                                 IProjetoColaboradorRepository projetoColaboradorRepository) : base(notifier)
        {
            _mapper = mapper;
            _projetoRepository = projetoRepository;
            _projetoColaboradorRepository = projetoColaboradorRepository;
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
            var projeto = _mapper.Map<IEnumerable<ProjetoDTO>>(await _projetoRepository.CustomSearchAsync(p => p.Id == id));

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

            if (! _projetoRepository.CustomSearchAsync(p => p.Id == id).Result.Any())
            {
                return NotFound();
            }

            await _projetoRepository.UpdateAsync(_mapper.Map<Projeto>(projetoDTO));

            return CustomResponse(projetoDTO);
        }

        [ClaimsAuthorize("Projeto", "Get")]
        [HttpGet("Colaboradores/{id:Guid}")]
        public async Task<IActionResult> GetColaborador(Guid id)
        {
            return CustomResponse(_mapper.Map<IEnumerable<ProjetoColaboradorDTO>>(await _projetoColaboradorRepository.CustomSearchAsync(pc => pc.Id == id)));
        }

        [ClaimsAuthorize("Projeto", "Post")]
        [HttpPost("Colaboradores")]
        public async Task<IActionResult> PostColaborador(ProjetoColaboradorDTO projetoColaboradorDTO)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            projetoColaboradorDTO.Id = Guid.NewGuid();
            await _projetoColaboradorRepository.AddAsync(_mapper.Map<ProjetoColaborador>(projetoColaboradorDTO));

            return CustomResponse(projetoColaboradorDTO);
        }

        [ClaimsAuthorize("Projeto", "Put")]
        [HttpPut("Colaboradores/{id:Guid}")]
        public async Task<IActionResult> PutColaborador(Guid id, ProjetoColaboradorDTO projetoColaboradorDTO)
        {
            if (! ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            if (id.ToString().ToUpper() != projetoColaboradorDTO.Id.ToString().ToUpper())
            {
                NotifyError("O id do objeto é diferente do id solicitado.");
                return CustomResponse();
            }

            if (! _projetoColaboradorRepository.CustomSearchAsync(pc => pc.Id.ToString().ToUpper() == id.ToString().ToUpper()).Result.Any())
            {
                return NotFound();
            }

            await _projetoColaboradorRepository.UpdateAsync(_mapper.Map<ProjetoColaborador>(projetoColaboradorDTO));

            return CustomResponse(projetoColaboradorDTO);
        }

        [ClaimsAuthorize("Projeto", "Delete")]
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (! _projetoRepository.CustomSearchAsync(p => p.Id == id).Result.Any())
            {
                return NotFound();
            }

            await _projetoRepository.RemoveAsync(id);

            return CustomResponse();
        }
    }
}
