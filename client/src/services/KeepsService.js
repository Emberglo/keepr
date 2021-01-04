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
}

export const keepsService = new KeepsService()
