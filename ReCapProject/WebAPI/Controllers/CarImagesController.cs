﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById([FromForm(Name = ("Id"))] int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallimagebycarid")]
        public IActionResult GetAllImageByCarId([FromForm(Name =("CarId"))] int id)
        {
            var result = _carImageService.GetAllImageByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        [Authorize(Roles="Cars.Add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        [Authorize("Cars.Delete")]
        public IActionResult Delete([FromForm(Name = ("Id"))] int Id)
        {
            var carImage = _carImageService.GetById(Id).Data;
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        [Authorize("Cars.Update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("Id"))] int id)
        {
            var carImage = _carImageService.GetById(id).Data;
            var result = _carImageService.Update(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
