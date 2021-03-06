import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class ProfileService {
  async getProfile() {
    try {
      const res = await api.get('api/profiles')
      AppState.profile = res.data
    } catch (err) {
      logger.error('Get Profile - HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getOtherProfile(profileId) {
    try {
      const res = await api.get('api/profiles/' + profileId)
      AppState.otherProfile = res.data
    } catch (err) {
      logger.error('Get Profile - HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }
}

export const profileService = new ProfileService()
