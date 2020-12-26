import { AppState } from '../AppState'
import router from '../router'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'
class WishListsService {
  async getWishLists() {
    try {
      const res = await api.get('api/wishlists')
      logger.log('WishListService', AppState.profile.id)
      AppState.wishlists = res.data
    } catch (err) {
      logger.error(err)
    }
  }

  async post(newWishList) {
    try {
      await api.post('api/wishlists', newWishList)
      router.push({ name: 'Home' })
    } catch (error) {
      logger.log(error)
    }
  }
}

export const wishlistsService = new WishListsService()
