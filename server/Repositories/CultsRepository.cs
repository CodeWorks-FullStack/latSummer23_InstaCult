using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace server.Repositories;

public class CultsRepository
{
    private readonly IDbConnection _db;

    public CultsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Cult CreateCult(Cult cultData)
    {
      string sql = @"
      INSERT INTO cults
      (name, description, coverImg, fee, leaderId, memberCount, invitationRequired)
      VALUES
      (@name, @description, @coverImg, @fee, @leaderId, @memberCount, @invitationRequired);

       SELECT
      accounts.*,
      cults.*
      FROM cults
      JOIN accounts ON accounts.id = cults.leaderId
      WHERE cults.id = LAST_INSERT_ID()
      ;";
      Cult cult = _db.Query<Profile, Cult, Cult>(sql, (leader, cult)=>{
        cult.Leader = leader;
        return cult;
      }, cultData).FirstOrDefault();
      return cult;
    }

    internal Cult GetCultById(int cultId)
    {
           string sql = @"
      SELECT
      accounts.*,
      cults.*
      FROM cults
      JOIN accounts ON accounts.id = cults.leaderId
      WHERE cults.id = @cultId
      ;";

      Cult cult = _db.Query<Profile, Cult, Cult>(sql, (leader, cult)=>{
        cult.Leader = leader;
        return cult;
      }, new {cultId}).FirstOrDefault();
      return cult;
    }

    internal List<Cult> GetCults()
    {
      string sql = @"
      SELECT
      accounts.*,
      cults.*
      FROM cults
      JOIN accounts ON accounts.id = cults.leaderId
      ;";

      List<Cult> cults = _db.Query<Profile, Cult, Cult>(sql, (leader, cult)=>{
        cult.Leader = leader;
        return cult;
      }).ToList();
      return cults;
    }
}
