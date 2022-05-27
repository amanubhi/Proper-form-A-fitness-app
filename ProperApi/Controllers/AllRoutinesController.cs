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
  [Route("api/UserRoutines/All")]
  [ApiController]
  public class AllRoutinesController : ControllerBase
  {
    private readonly UserAccountsContext _context;

    public AllRoutinesController(UserAccountsContext context)
    {
      _context = context;
    }

    // Get: api/Email/fake@gmail.com
    [HttpGet("{UserId}")]
    public async Task<ActionResult<List<UserRoutines>>> GetStrings(int userID)
    {
      var RtUserInfo = await _context.UserRoutines.Where(data => data.UserID == userID).ToListAsync();/*.FirstOrDefaultAsync(data => data.Email == Email);*/


      return RtUserInfo;


    }

  }
}
