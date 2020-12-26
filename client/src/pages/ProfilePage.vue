<template>
  <div class="profile container fluid">
    <div class="row">
      <div class="col-8 offset-2">
        <form action="HomePage.vue" class="form-group" @submit.prevent="post(state.newWishList)">
          <div class="form-group">
            <label for="name">Wishlist Name</label>
            <input type="text" id="name" class="form-control" placeholder="Enter Wishlist Name" v-model="state.newWishList.name">
          </div>
          <div class="text-center">
            <button class="btn btn-dark text-white" type="submit">
              Create
            </button>
          </div>
        </form>
      </div>
    </div>
    <div class="row">
      <div class="col-6">
        <h1>
          My Wishlists
        </h1>
      </div>
      <div class="row">
        <wishListsComponent v-for="wishlist in wishlists" :wishlist-prop="wishlist" :key="wishlist.id" />
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
import { computed, reactive, onMounted } from 'vue'
import { AppState } from '../AppState'
import { wishlistsService } from '../services/WishListsService'
// import { productsService } from '../services/ProductsService'
export default {
  name: 'Profile',
  setup() {
    onMounted(() => {
      wishlistsService.getWishLists()
    })
    const state = reactive({
      newWishList: {
        name: ''
      }
    })
    return {
      state,
      post(newWishList) {
        wishlistsService.post(newWishList)
      },
      profile: computed(() => AppState.profile),
      products: computed(() => AppState.myProducts),
      wishlists: computed(() => AppState.wishlists)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
