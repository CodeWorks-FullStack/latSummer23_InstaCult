import { AppState } from "../AppState.js"
import { Cultist } from "../models/Account.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"




class CultMemberService{
async joinCult(cultMemberData){
  const res = await api.post('api/cultMembers', cultMemberData)
  logger.log('joined a cult', res.data)
  AppState.cultists.push(new Cultist(res.data))
  AppState.activeCult.memberCount++
}

async removeCultMember(cultMemberId){
  // NOTE this is a dirty trick write it normally
  const res = await api.delete(['api', 'cultMembers', cultMemberId].join('/'))
  logger.log('Removed member', res.data)
  const index = AppState.cultists.findIndex(c => c.cultMemberId == cultMemberId)
  AppState.cultists.splice(index, 1)
  AppState.activeCult.memberCount--
}

}

export const cultMembersService = new CultMemberService()
