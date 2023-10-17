using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;
using server.Repositories;

namespace server.Services;

public class CultsService
{
    private readonly CultsRepository _repo;

    public CultsService(CultsRepository repo)
    {
        _repo = repo;
    }

    internal Cult CreateCult(Cult cultData)
    {
      Cult cult = _repo.CreateCult(cultData);
      return cult;
    }

    internal Cult GetCultById(int cultId)
    {
      Cult cult = _repo.GetCultById(cultId);
      if(cult == null) throw new Exception($"no cult at id: {cultId}");

      return cult;
    }

    internal List<Cult> GetCults(string userId)
    {
      List<Cult> cults = _repo.GetCults();
      List<Cult> filtered = cults.FindAll(cult => cult.InvitationRequired == false || cult.LeaderId == userId);
      return filtered;
    }

    internal void UpdateCultMemberCount(Cult cult)
    {
      // NOTE this is just for the count, it doesn't take in a user id, so would not be good to allow other edits to happen.
      _repo.UpdateCult(cult);
    }
}
