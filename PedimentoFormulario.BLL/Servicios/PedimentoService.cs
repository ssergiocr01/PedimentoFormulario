using AutoMapper;
using PedimentoFormulario.BLL.Servicios.Interfaces;
using PedimentoFormulario.Data.UnidadDeTrabajo.Interfaces;
using PedimentoFormulario.Modelos.DTOs;

namespace PedimentoFormulario.BLL.Servicios
{
    public class PedimentoService : IPedimentoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PedimentoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<SolicitudPedimentoPersonalDto>> GetPedimentosAsync(int tipoConsulta, bool mini, string? pedimento = null, int codInstitucion = 0)
        {
            var pedimentos = await _unitOfWork.PedimentoRepository.GetPedimentosAsync(tipoConsulta, mini, pedimento, codInstitucion);
            return _mapper.Map<IEnumerable<SolicitudPedimentoPersonalDto>>(pedimentos);
        }
    }
}