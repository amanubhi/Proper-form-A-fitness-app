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
  [Route("api/Login")]
  [ApiController]
  public class LoginController : ControllerBase
  {
    private readonly UserAccountsContext _context;

    public LoginController(UserAccountsContext context)
    {
      _context = context;
    }

    // Get: api/Login
    [HttpGet("{Username}/{Password}")]
    public async Task<ActionResult<LoginCheck>> GetStrings(string username, string password)
    {
      var usernameInfo = await _context.UserInfo.FirstOrDefaultAsync(data => data.Username == username);
      var passwordInfo = await _context.UserInfo.FirstOrDefaultAsync(data => data.Password == password);


      var truth = new LoginCheck();
        if ((passwordInfo != null && usernameInfo != null)&&(passwordInfo.UserID == usernameInfo.UserID))
        {
          truth.Equal = true;//value doesn't exist
          truth.Token = usernameInfo.Token;

        }
      else
        {
          truth.Equal = false;
          truth.UserID = usernameInfo.UserID;
      }


      return truth;
    }

  }
}
