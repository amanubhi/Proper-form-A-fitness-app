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
  [Route("api/signup")]
  [ApiController]
  public class SignupController : ControllerBase
  {
    private readonly UserAccountsContext _context;

    public SignupController(UserAccountsContext context)
    {
      _context = context;
    }

    // Get: api/Login
    [HttpGet("{Email}/{Username}")]
    public async Task<ActionResult<SignupCheck>> GetStrings(string email, string username)
    {
      var emailInfo = await _context.UserInfo.FirstOrDefaultAsync(data => data.Email == email);
      var usernameInfo = await _context.UserInfo.FirstOrDefaultAsync(data => data.Username == username);

      var truth = new SignupCheck();
      if (emailInfo == null && usernameInfo == null)//values both don't exist
      {
        truth.emailExists = true;
        truth.usernameExists = true;
      }
      else if (emailInfo == null && usernameInfo != null)
      {
        truth.emailExists = true;
        truth.usernameExists = false;
      }
      else if (emailInfo != null && usernameInfo == null)
      {
        truth.emailExists = false;
        truth.usernameExists = true;
      }
      else
      {
        truth.emailExists = false;
        truth.usernameExists = false;
      }


      return truth;
    }

  }
}
