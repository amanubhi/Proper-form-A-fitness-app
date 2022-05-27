using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace ProperApi.Controllers
{
    [Route("api/WeightHistory")]
    [ApiController]

    public class WeightHistoryController : ControllerBase
    {
        private readonly UserAccountsContext _context;
        public WeightHistoryController(UserAccountsContext context)
        {
            _context = context;
        }

        // GET: api/WeightHistory
        [HttpGet("{ID}")]
        public async Task<ActionResult<IEnumerable<WeightHistory>>> GetWeightHistory(int ID)
        {
            var Entries = await _context.WeightHistory.Where(Info => Info.UserId ==ID).OrderBy(data => data.Date).ToListAsync();


            return Entries;
        }


        [HttpPost]
        public async Task<ActionResult<WeightHistory>> PostWeightHistory(WeightHistory weightHistory)
        {
            _context.WeightHistory.Add(weightHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInfo", new { id = weightHistory.ID }, weightHistory);
        }

    }


}
