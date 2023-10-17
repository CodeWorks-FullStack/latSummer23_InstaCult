using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;
using server.Repositories;

namespace server.Services;

public class CultMembersService
{
    private readonly CultMembersRepository _repo;
    private readonly CultsService _cultsService;

    public CultMembersService(CultMembersRepository repo, CultsService cultsService)
    {
        _repo = repo;
        _cultsService = cultsService;
    }

    internal Cultist CreateCultMember(CultMember cultData)
    {
      Cultist newCultist = _repo.CreateCultMember(cultData);
      // call to the cultService to update the cult
      Cult cult = _cultsService.GetCultById(cultData.CultId);
      cult.MemberCount++;
      _cultsService.UpdateCultMemberCount(cult);
      return newCultist;
    }

    internal List<Cultist> GetCultistsByCultId(int cultId)
    {
      // Check if cult exists
      _cultsService.GetCultById(cultId); // if this errors, then we will exit and return an error early.

      List<Cultist> cultists = _repo.GetCultistsByCultId(cultId);
      return cultists;
    }

    internal CultMember GetCultMemberById(int cultMemberId){
      CultMember cultMember = _repo.GetCultMemberById(cultMemberId);
      if(cultMember == null) throw new Exception($"no cult member at id: ${cultMemberId}");
      return cultMember;
    }

    internal string LeaveCult(int cultMemberId, string userId)
    {
      CultMember cultMember = this.GetCultMemberById(cultMemberId);
      Cult cult = _cultsService.GetCultById(cultMember.CultId);
      if(cult.LeaderId != userId) throw new Exception("Stick around a little longer");

      _repo.LeaveCult(cultMemberId);

      cult.MemberCount--;
      _cultsService.UpdateCultMemberCount(cult);
      
      return $"they gone";
    }
}
