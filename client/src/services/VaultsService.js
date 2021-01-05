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

  async getActiveVault(vaultId) {
    const res = await api.get('api/vaults/' + vaultId)
    AppState.activeVault = res.data
  }

  async createVault(newVault, profileId) {
    try {
      await api.post('api/vaults', newVault)
      this.getVaults(profileId)
    } catch (err) {
      logger.error(err)
    }
  }

  async deleteVault(vaultId, profileId) {
    try {
      await api.delete('api/vaults/' + vaultId)
      this.getVaults(profileId)
    } catch (err) {
      logger.error(err)
    }
  }
}

export const vaultsService = new VaultsService()
