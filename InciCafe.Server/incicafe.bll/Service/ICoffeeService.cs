using InciCafe.BLL.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InciCafe.BLL.Service
{
    public interface ICoffeeService
    {
        Task<IEnumerable<CoffeeDto>> GetCoffeesAsync(CancellationToken ct);
        Task<CoffeeDto> GetCoffeeAsync(int id, CancellationToken ct);
        Task<int> CreateCoffeeAsync(CreateCoffeeDto createCoffeeDto, CancellationToken ct);

    }
}
