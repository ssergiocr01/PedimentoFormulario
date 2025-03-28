using AutoMapper;
using PedimentoPersonal.BLL.Services.Interfaces;
using PedimentoPersonal.Data.UnitOfWork.Interfaces;
using PedimentoPersonal.Models.DTOs;
using PedimentoPersonal.Utilities.Exceptions;
using System.Linq;

namespace PedimentoPersonal.BLL.Services
{
    public class JornadaService : IJornadaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JornadaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<JornadaDto>> GetJornadasAsync()
        {
            var jornadas = await _unitOfWork.Jornadas.GetJornadasActivasAsync();
            
            // Filtrar la jornada con código 10 ("Todos")
            var jornadasFiltradas = jornadas.Where(j => j.CodJornada != 10);

            if (!jornadasFiltradas.Any())
            {
                throw new NotFoundException("No se encontraron jornadas activas válidas.");
            }

            return _mapper.Map<IEnumerable<JornadaDto>>(jornadasFiltradas);
        }
    }
}

