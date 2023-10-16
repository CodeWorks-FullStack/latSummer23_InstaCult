import { reactive } from 'vue'
import { Cult } from './models/Cult.js'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},

  /** @type {Cult[]} */
  cults: [],

  /**@type {Cult} */
  activeCult: null
})
