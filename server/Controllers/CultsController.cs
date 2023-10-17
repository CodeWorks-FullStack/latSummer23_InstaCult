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
public class CultsController : ControllerBase
{
    private readonly CultsService _cultService;
    private readonly CultMembersService _cultMembersService;
    private readonly Auth0Provider _auth;

    public CultsController(CultsService cultService, Auth0Provider auth, CultMembersService cultMembersService)
    {
        _cultService = cultService;
        _auth = auth;
        _cultMembersService = cultMembersService;
    }

    [HttpGet]
    // NOTE DONT need auth to TRY and get userinfo, only when you want to LOCK a route to only logged in people
    public async Task<ActionResult<List<Cult>>> GetCults(){
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        // NOTE when accessing userInfo in a request that is not authorized, make sure to ? out any properties you try to access or you might get 'Object reference not set to an instance of an object'
        List<Cult> cults = _cultService.GetCults(userInfo?.Id);
        return Ok(cults);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{cultId}")]
    public ActionResult<Cult> GetCultById( int cultId){
      try
      {
        Cult cult =_cultService.GetCultById(cultId);
        return Ok(cult);
      }
     catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{cultId}/cultMembers")]
    public ActionResult<List<Cultist>> GetCultistsByCultId(int cultId){
      try
      {
        List<Cultist> cultists = _cultMembersService.GetCultistsByCultId(cultId);
        return cultists;
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Cult>> CreateCult([FromBody]Cult cultData){
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        cultData.LeaderId = userInfo.Id;
        Cult cult = _cultService.CreateCult(cultData);
        return Ok(cult);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
}
