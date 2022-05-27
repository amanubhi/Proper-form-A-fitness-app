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
  [Route("api/AllNuts")]
  [ApiController]

  public class AllNutsController : ControllerBase
  {
    private readonly UserAccountsContext _context;
    public AllNutsController(UserAccountsContext context)
    {
      _context = context;
    }

    // GET: api/SearchNut
    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<NutEntries>>> GetNutEntries()
    {
       var Entries = await _context.NutEntries.OrderBy(data => data.ItemName).ToListAsync();

      return Entries;
    }


    [HttpPost]
    public async Task<ActionResult<object>> PostNutEntries(NutEntries nutEntries)
    {
      _context.NutEntries.Add(nutEntries);
      await _context.SaveChangesAsync();

            return new { id = nutEntries.ID };//CreatedAtAction("GetUserInfo", new { id = nutEntries.ID }, nutEntries);
    }

  }


}
