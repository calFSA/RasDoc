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
    public class ClasseController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IClasseRepository _classeRepository;

        public ClasseController(INotifier notifier,
                                IMapper mapper,
                                IClasseRepository classeRepository) : base(notifier)
        {
            _mapper = mapper;
            _classeRepository = classeRepository;
        }

        [ClaimsAuthorize("Classe", "Get")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var classe = _mapper.Map<IEnumerable<ClasseDTO>>(await _classeRepository.CustomSearchAsync());

            if (! classe.Any())
            {
                return NotFound();
            }

            return CustomResponse(classe);
        }

        [ClaimsAuthorize("Classe", "GetAll")]
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var classe = _mapper.Map<IEnumerable<ClasseDTO>>(await _classeRepository.CustomSearchAsync(c => c.Id == id));

            if (! classe.Any())
            {
                return NotFound();
            }

            return CustomResponse(classe);
        }

        [ClaimsAuthorize("Classe", "Post")]
        [HttpPost]
        public async Task<IActionResult> Post(ClasseDTO classeDTO)
        {
            if (! ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            classeDTO.Id = Guid.NewGuid();
            await _classeRepository.AddAsync(_mapper.Map<Classe>(classeDTO));

            return CustomResponse(classeDTO);
        }

        [ClaimsAuthorize("Classe", "Put")]
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Put(Guid id, ClasseDTO classeDTO)
        {
            if (! ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            if (id.ToString().ToUpper() != classeDTO.Id.ToString().ToUpper())
            {
                NotifyError("O id do objeto é diferente do id solicitado.");
                return CustomResponse();
            }

            if (! _classeRepository.CustomSearchAsync(c => c.Id == id).Result.Any())
            {
                return NotFound();
            }

            await _classeRepository.UpdateAsync(_mapper.Map<Classe>(classeDTO));

            return CustomResponse(classeDTO);
        }

        [ClaimsAuthorize("Classe", "Delete")]
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (! _classeRepository.CustomSearchAsync(c => c.Id == id).Result.Any())
            {
                return NotFound();
            }

            await _classeRepository.RemoveAsync(id);

            return CustomResponse();
        }
    }
}
