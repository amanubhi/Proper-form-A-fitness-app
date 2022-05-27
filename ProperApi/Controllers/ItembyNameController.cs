using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace ProperApi.Controllers
{
    [Route("api/ItemByName")]
    [ApiController]

    public class ItemByNameController : ControllerBase
    {
        private readonly UserAccountsContext _context;
        public ItemByNameController(UserAccountsContext context)
        {
            _context = context;
        }

        // GET: api/SearchNut
        [HttpGet("{itemName}")]
        public async Task<ActionResult<NutEntries>> GetNutEntries(string itemName)
        {
            var Entry = await _context.NutEntries.Where(data => data.ItemName == itemName).FirstOrDefaultAsync();


            return Entry;
        }

    }
       


}