import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class KeepsService {
  async getAllKeeps() {
    try {
      const res = await api.get('api/keeps')
      AppState.keeps = res.data
    } catch (err) {
      logger.error('Get Keeps - HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getActiveKeep(keepId) {
    try {
      const res = await api.get('api/keeps/' + keepId)
      AppState.activeKeep = res.data
      this.getAllKeeps()
      // const active = AppState.keeps.findIndex(k => k.id === keepId)
      // AppState.activeKeep = AppState.keeps[active]
    } catch (err) {
      logger.error('Get Keeps - HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getProfileKeeps(profileId) {
    try {
      const res = await api.get('api/profiles/' + profileId + '/keeps')
      AppState.profileKeeps = res.data
    } catch (err) {
      logger.error('Get Vaults - HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async createKeep(newKeep, profileId) {
    try {
      await api.post('api/keeps', newKeep)
      this.getProfileKeeps(profileId)
    } catch (err) {
      logger.error(err)
    }
  }

  async deleteKeep(keepId, profileId) {
    try {
      const conf = confirm('Are you sure?')
      if (conf === true) {
        await api.delete('api/keeps/' + keepId)
        this.getProfileKeeps(profileId)
      }
    } catch (err) {
      logger.error(err)
    }
  }
}

export const keepsService = new KeepsService()
