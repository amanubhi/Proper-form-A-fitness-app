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
  [Route("api/UserName")]
  [ApiController]
  public class UsernameController : ControllerBase
  {
    private readonly UserAccountsContext _context;

    public UsernameController(UserAccountsContext context)
    {
      _context = context;
    }


    // Get: api/UserInfo/tempusername1
    [HttpGet("{UserName}")]
    public async Task<ActionResult<ValueExists>> GetUserInfo(string UserName)
    {
      var userInfo = await _context.UserInfo.FirstOrDefaultAsync(data => data.Username == UserName);
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
