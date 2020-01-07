﻿using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
            
        }
        
        //GET api/values
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetValues(){

            var values = await _context.Values.ToListAsync();

            return Ok(values);
        }
        [AllowAnonymous]
         //GET api/values
        [HttpGet("{id}")]
        public async Task<IActionResult> GeValue(int id){

            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value);
        }

    }
}