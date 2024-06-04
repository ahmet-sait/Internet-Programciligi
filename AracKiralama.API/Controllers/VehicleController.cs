using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AracKiralama.Dtos;
using AracKiralama.Models;
using Microsoft.AspNetCore.Authorization;

namespace AracKiralama.Controllers
{
    [Route("api/Vehicle")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();
        public VehicleController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<VehicleDto> GetList()
        {
            var vehicle = _context.Vehicle.ToList();
            var vehicleDtos = _mapper.Map<List<VehicleDto>>(vehicle);
            return vehicleDtos;
        }


        [HttpGet]
        [Route("{id}")]
        public VehicleDto Get(int id)
        {
            var vehicle = _context.Vehicle.Where(s => s.Id == id).SingleOrDefault();
            var vehicleDto = _mapper.Map<VehicleDto>(vehicle);
            return vehicleDto;
        }

        [HttpPost]
        public ResultDto Post(VehicleDto dto)
        {
            if (_context.Vehicle.Count(c => c.Name == dto.Name) > 0)
            {
                result.Status = false;
                result.Message = "The Vehicle Name Entered is Registered!";
                return result;
            }
            var vehicle = _mapper.Map<Vehicle>(dto);
            vehicle.Updated = DateTime.Now;
            vehicle.Created = DateTime.Now;
            _context.Vehicle.Add(vehicle);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Vehicle Added";
            return result;
        }


        [HttpPut]
        public ResultDto Put(VehicleDto dto)
        {
            var vehicle = _context.Vehicle.Where(s => s.Id == dto.Id).SingleOrDefault();
            if (vehicle == null)
            {
                result.Status = false;
                result.Message = "Vehicle Not Found";
                return result;
            }
            vehicle.Name = dto.Name;
            vehicle.IsActive = dto.IsActive;
            vehicle.Price = dto.Price;
            vehicle.Updated = DateTime.Now;
            vehicle.CategoryId = dto.CategoryId;
            _context.Vehicle.Update(vehicle);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Vehicle Information Edited";
            return result;
        }


        [HttpDelete]
        [Route("{id}")]
        public ResultDto Delete(int id)
        {
            var vehicle = _context.Vehicle.Where(s => s.Id == id).SingleOrDefault();
            if (vehicle == null)
            {
                result.Status = false;
                result.Message = "vehicle not found";
                return result;
            }
            _context.Vehicle.Remove(vehicle);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "vehicle deleted";
            return result;
        }
    }
}
