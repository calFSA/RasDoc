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
    public class ModuloController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IModuloRepository _moduloRepository;

        public ModuloController(INotifier notifier,
                                IMapper mapper,
                                IModuloRepository moduloRepository) : base(notifier)
        {
            _mapper = mapper;
            _moduloRepository = moduloRepository;
        }

        [ClaimsAuthorize("Modulo", "Get")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var modulo = _mapper.Map<IEnumerable<ModuloDTO>>(await _moduloRepository.CustomSearchAsync());

            if (! modulo.Any())
            {
                return NotFound();
            }

            return CustomResponse(modulo);
        }

        [ClaimsAuthorize("Modulo", "GetAll")]
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var modulo = _mapper.Map<IEnumerable<ModuloDTO>>(await _moduloRepository.CustomSearchAsync(m => m.Id == id));

            if (! modulo.Any())
            {
                return NotFound();
            }

            return CustomResponse(modulo);
        }

        [ClaimsAuthorize("Modulo", "Post")]
        [HttpPost]
        public async Task<IActionResult> Post(ModuloDTO moduloDTO)
        {
            if (! ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            moduloDTO.Id = Guid.NewGuid();
            await _moduloRepository.AddAsync(_mapper.Map<Modulo>(moduloDTO));

            return CustomResponse(moduloDTO);
        }

        [ClaimsAuthorize("Modulo", "Put")]
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Put(Guid id, ModuloDTO moduloDTO)
        {
            if (! ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            if (id.ToString().ToUpper() != moduloDTO.Id.ToString().ToUpper())
            {
                NotifyError("O id do objeto é diferente do id solicitado.");
                return CustomResponse();
            }

            if (! _moduloRepository.CustomSearchAsync(m => m.Id == id).Result.Any())
            {
                return NotFound();
            }

            await _moduloRepository.UpdateAsync(_mapper.Map<Modulo>(moduloDTO));

            return CustomResponse(moduloDTO);
        }

        [ClaimsAuthorize("Modulo", "Delete")]
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (! _moduloRepository.CustomSearchAsync(m => m.Id == id).Result.Any())
            {
                return NotFound();
            }

            await _moduloRepository.RemoveAsync(id);

            return CustomResponse();
        }
    }
}
