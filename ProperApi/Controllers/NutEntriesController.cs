using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace ProperApi.Controllers
{
  [Route("api/NutEntries")]
  [ApiController]

  public class NutEntriesController : ControllerBase
  {
    private readonly UserAccountsContext _context;

    public NutEntriesController(UserAccountsContext context)
    {
      _context = context;
    }


    // GET: api/NutEntries
    [HttpGet("{ID}")]
    public async Task<ActionResult<IEnumerable<UserNutFull>>> GetNutEntries(int ID)
    {
      //var Entries = await _context.NutEntries.Where(data => data.UserID == ID).OrderBy(data => data.ItemName).ToListAsync();

      var Entries = await _context.UserNut.Join(_context.NutEntries, usernut => usernut.FoodID, nutentry => nutentry.ID, (usernut, nutentry) =>
          new UserNutFull
          {
            ItemName = nutentry.ItemName,
            Calories = nutentry.Calories,
            Fat = nutentry.Fat,
            Sugar = nutentry.Sugar,
            Carbs = nutentry.Carbs,
            Protein = nutentry.Protein,
            UserID = usernut.UserID,
            FoodID = usernut.FoodID
          }).Where(ent => ent.UserID == ID).OrderBy(data => data.ItemName).ToListAsync();

      return Entries;
    }

        [HttpPost]
    public async Task<ActionResult<UserNut>> PostUserNut(UserNut userNut)
    {
      _context.UserNut.Add(userNut);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetUserInfo", new { id = userNut.ID }, userNut);
    }

  }
}
