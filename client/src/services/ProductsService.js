import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class ProductsService {
  async getPublicProducts() {
    try {
      const res = await api.get('api/products')
      AppState.products = res.data
    } catch (err) {
      logger.error(err)
    }
  }
}

export const productsService = new ProductsService()
