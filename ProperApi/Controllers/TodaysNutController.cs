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
  [Route("api/TodaysNut")]
  [ApiController]

  public class TodaysNutController : ControllerBase
  {
    private readonly UserAccountsContext _context;

    public TodaysNutController(UserAccountsContext context)
    {
      _context = context;
    }

    // GET: api/TodaysNut
    [HttpGet("{ID}")]
    public async Task<ActionResult<IEnumerable<UserNutFull>>> GetUserNutEntries(DateTime date, int ID)
    {
      var Entries = await _context.UserNut.Join(_context.NutEntries, usernut=>usernut.FoodID, nutentry=>nutentry.ID, (usernut,nutentry)=>
      new UserNutFull
      {
        ItemName = nutentry.ItemName,
        Calories = nutentry.Calories,
        Fat = nutentry.Fat,
        Sugar = nutentry.Sugar,
        Carbs = nutentry.Carbs,
        Protein = nutentry.Protein, 
        DateAdded=usernut.DateAdded,
        UserID=usernut.UserID,
        FoodID=usernut.FoodID
      }).Where(ent => ent.DateAdded == DateTime.Today && ent.UserID== ID).OrderBy(data => data.ItemName).ToListAsync();


      return Entries;
    }

    //var Entries = await _context.NutEntries.Where(data => data.DateAdded == DateTime.Today && data.UserID ==ID).OrderBy(data => data.ItemName).ToListAsync();


  }
}
