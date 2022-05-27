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
  [Route("api/Email")]
  [ApiController]
  public class EmailController : ControllerBase
  {
    private readonly UserAccountsContext _context;

    public EmailController(UserAccountsContext context)
    {
      _context = context;
    }

    // Get: api/Email/fake@gmail.com
    [HttpGet("{Email}")]
    public async Task<ActionResult<ValueExists>> GetStrings(string Email)
    {
      var userInfo = await _context.UserInfo.FirstOrDefaultAsync(data => data.Email == Email);
      var truth = new ValueExists();
      if (userInfo == null)
      {
        truth.exists = true;//value doesn't exist
      }
      else
      {
        truth.exists = false;
      }

      return truth;
    }

  }
}
