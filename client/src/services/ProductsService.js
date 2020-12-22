import { AppState } from '../AppState'
import router from '../router'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class ProductsService {
  async getPublicProducts() {
    try {
      const res = await api.get('api/products')
      logger.log(res.data)
      AppState.products = res.data
    } catch (err) {
      logger.error(err)
    }
  }

  async getActiveProduct(productId) {
    try {
      const res = await api.get('api/products/' + productId)
      AppState.activeProduct = res.data
    } catch (error) {
      logger.log(error)
    }
  }

  async post(newPost) {
    try {
      await api.post('api/products', newPost)
      router.push({ name: 'Home' })
    } catch (error) {
      logger.log(error)
    }
  }
}

export const productsService = new ProductsService()
