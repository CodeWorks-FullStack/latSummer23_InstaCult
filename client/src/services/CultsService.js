import { AppState } from "../AppState.js"
import { Cult } from "../models/Cult.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"



class CultsService{

async getCults(){
  const res = await api.get('api/cults')
  logger.log('👥 got cults', res.data)
  AppState.cults = res.data.map(c => new Cult(c))
}

async getCultById(cultId){
  const res = await api.get(`api/cults/${cultId}`)
  logger.log('one cult', res.data)
  AppState.activeCult = new Cult(res.data)
}

async createCult(cultData){
  const res = await api.post('api/cults', cultData)
  logger.log('Created cult', res.data)
  AppState.cults.push(new Cult(res.data))
}

}

export const cultsService = new CultsService
