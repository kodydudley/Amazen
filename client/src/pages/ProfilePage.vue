<template>
  <div class="profile container fluid">
    <div class="row">
      <div class="col-6">
        <h1>
          My Wishlists
        </h1>
      </div>
    </div>
    <div class="row">
      <div class="col-6">
        <h1>My Products</h1>
      </div>
    </div>
    <div class="row">
      <myProductsComponent v-for="product in products" :product-prop="product" :key="product.id" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
// import { productsService } from '../services/ProductsService'
export default {
  name: 'Profile',
  setup() {
    onMounted(() => {
      // productsService.getMyProducts()
    })
    return {
      profile: computed(() => AppState.profile),
      products: computed(() => AppState.myProducts)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
