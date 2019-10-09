using InciCafe.DAL.UnitOfWork;
using InciOneSoft.BLL.Helpers;
using Microsoft.Extensions.Logging;

namespace InciCafe.BLL.Service
{
    public class ServiceBase : IServiceBase
    { 
        protected readonly IUnitOfWork _uow;
        protected readonly IAutoMapperService _mapper;
        protected readonly ILogger<ServiceBase> _logger;

        public ServiceBase(IUnitOfWork uow, IAutoMapperService mapper, ILogger<ServiceBase> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

    }
}

