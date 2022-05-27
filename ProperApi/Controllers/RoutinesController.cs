using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace ProperApi.Controllers
{
  [Route("api/UserRoutines")]
  [ApiController]
  public class RoutinesController : ControllerBase
  {
    private readonly UserAccountsContext _context;

    public RoutinesController(UserAccountsContext context)
    {
      _context = context;
    }

    // Get: api/Email/fake@gmail.com
    [HttpGet("{UserId}/{RtName}")]
    public async Task<ActionResult<List<UserRoutines>>> GetStrings(int userID, string rtName)
    {
      var RtUserInfo = await _context.UserRoutines.Where(data => data.UserID == userID && data.RtName == rtName).ToListAsync();/*.FirstOrDefaultAsync(data => data.Email == Email);*/
      

      return RtUserInfo;
    

    }

    [HttpPost]
    public async Task<ActionResult<UserRoutines>> PostUserRoutines(UserRoutines userRoutines)
    {
      _context.UserRoutines.Add(userRoutines);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetUserRoutines", new { id = userRoutines.ID }, userRoutines);
    }

  }
}
