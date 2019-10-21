using InciCafe.BLL.Dto;
using InciCafe.DAL.Entities;
using InciCafe.DAL.UnitOfWork;
using InciOneSoft.BLL.Helpers;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InciCafe.BLL.Service
{
    public class CoffeeService : ServiceBase,ICoffeeService
    {
        public CoffeeService(IUnitOfWork uow, IAutoMapperService mapper, ILogger<CoffeeService> logger) : base(uow, mapper, logger)
        {
        }

        public async Task<IEnumerable<CoffeeDto>> GetCoffeesAsync(CancellationToken ct)
        {
            IEnumerable<Coffee> coffeesEntity = await _uow.Coffees.GetCoffeesAsync(ct);
            IEnumerable<CoffeeDto> coffeesDto = _mapper.Mapper.Map<IEnumerable<CoffeeDto>>(coffeesEntity);
            return coffeesDto.ToList();
        }

        public async Task<CoffeeDto> GetCoffeeAsync(int id, CancellationToken ct)
        {
            Coffee coffeesEntity = await _uow.Coffees.GetCoffeeAsync(id, ct);
            CoffeeDto coffeesDto = _mapper.Mapper.Map<CoffeeDto>(coffeesEntity);
            return coffeesDto;
        }

        public async Task<int> CreateCoffeeAsync(CreateCoffeeDto createCoffeeDto, CancellationToken ct)
        {
            Coffee coffeesEntity = _mapper.Mapper.Map<Coffee>(createCoffeeDto);
            _uow.Coffees.CreateCoffee(coffeesEntity);

            if (await _uow.SaveChangesAsync(ct) > 0)
                return coffeesEntity.Id;
            else
                return 0;
        }

    

        

        public async Task<CoffeeDto> GetCoffeeAsync(string name, CancellationToken ct)
        {
            Coffee coffeesEntity = await _uow.Coffees.GetCoffeeAsync(name, ct);
            CoffeeDto coffeesDto = _mapper.Mapper.Map<CoffeeDto>(coffeesEntity);
            return coffeesDto;
        }
    }
}
