using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using WHS.Application.DTO.Warehouse;
using WHS.Domain.Entities.Code;
using WHS.Domain.Repositories;

namespace WHS.Application.Services
{
    internal class WarehouseService(IWarehouseRepository warehosueRepository, 
        ILogger<WarehouseService> logger,
        IMapper mapper) : IWarehouseService
    {
        //public async Task<Guid> Create(CreateWarehouseDto dto)
        //{
        //    logger.LogInformation("Creating a new warehouese");
        //    var warehosue = mapper.Map<Warehouse>(dto);
        //    Guid id=await warehosueRepository.Create(warehosue);
        //    return id;
        //}

        public async Task<IEnumerable<WarehouseDto>> GetAllWarehouses()
        {
            logger.LogInformation("Getting all warehoues");
            var warehouses = await warehosueRepository.GetAllAsync();
            //var warehosueDto = warehouses.Select(WarehouseDto.FromEntity);
            var restaurantsDtos = mapper.Map<IEnumerable<WarehouseDto>>(warehouses);
            return restaurantsDtos!;
        }

        public async Task<WarehouseDto?> GetById(Guid id)
        {
            logger.LogInformation($"Getting Warehouses{id}");
            var warehosue = await warehosueRepository.GetByIdAsync(id);
            //var warehouseDto = WarehouseDto.FromEntity(warehosue);
            var warehosueDto=mapper.Map<WarehouseDto?>(warehosue);
            return warehosueDto;
        }
    }
}
