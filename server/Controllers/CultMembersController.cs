using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CultMembersController : ControllerBase
{
    private readonly CultMembersService _cultMembersService;
    private readonly Auth0Provider _auth;

    public CultMembersController(CultMembersService cultMembersService, Auth0Provider auth)
    {
        _cultMembersService = cultMembersService;
        _auth = auth;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Cultist>> CreateCultMember([FromBody] CultMember cultData){
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        cultData.AccountId = userInfo.Id;
        Cultist newCultist = _cultMembersService.CreateCultMember(cultData);
        return Ok(newCultist);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{cultMemberId}")]
    [Authorize]
    public async Task<ActionResult<string>> LeaveCult(int cultMemberId){
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        string message = _cultMembersService.LeaveCult(cultMemberId, userInfo.Id);
        return Ok(message);
      }
        catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

}
