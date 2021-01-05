import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class VaultsService {
  async getVaults(profileId) {
    try {
      const res = await api.get('api/profiles/' + profileId + '/vaults')
      AppState.vaults = res.data
    } catch (err) {
      logger.error('Get Vaults - HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }
}

export const vaultsService = new VaultsService()
