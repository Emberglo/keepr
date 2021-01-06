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
      const conf = confirm('Are you sure?')
      if (conf === true) {
        await api.delete('api/vaults/' + vaultId)
        this.getVaults(profileId)
      }
    } catch (err) {
      logger.error(err)
    }
  }

  async addToVault(newVaultKeep) {
    await api.post('api/vaultkeeps', newVaultKeep)
  }

  async getVaultKeeps(vaultId) {
    const res = await api.get('/api/vaults/' + vaultId + '/keeps')
    AppState.vaultKeeps = res.data
  }

  async deleteVaultKeep(vaultKeepId, vaultId) {
    const conf = confirm('Are you sure ?')
    if (conf === true) {
      await api.delete('/api/vaultkeeps/' + vaultKeepId)
      this.getVaultKeeps(vaultId)
    }
  }
}

export const vaultsService = new VaultsService()
