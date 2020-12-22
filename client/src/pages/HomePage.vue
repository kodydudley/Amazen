<template>
  <div class="home bg-secondary">
  </div>
  <!-- <div class="col-4"> -->
  <div class="row">
    <productComponent v-for="product in products" :product-prop="product" :key="product.id" />
  </div>
  <!-- </div> -->
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { productsService } from '../services/ProductsService'

export default {
  name: 'Home',
  setup() {
    onMounted(() => {
      productsService.getPublicProducts()
    })
    return {
      products: computed(() => AppState.products)
    }
  }
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}
</style>
