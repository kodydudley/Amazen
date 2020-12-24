<template>
  <div class="activeProductComponent">
    <div class="row justify-content-around bg-white">
      <div class="col-7">
        <img class="img-fluid" :src="activeProduct.picture" alt="">
      </div>
      <div class="col-4 border border-info shadow-lg bg-white">
        <!-- <div class="col-10 offset-1"> -->
        <div class="row ml-2">
          <h1 class="text-left">
            {{ activeProduct.title }}
          </h1>
        </div>
        <div class="row ml-2">
          <h6>{{ activeProduct.description }}</h6>
        </div>
        <div class="row ml-2 d-flex align-text-bottom bottom">
          <h3>${{ activeProduct.price }}</h3>
        </div>
        <!-- </div> -->
      </div>
      <div class="col-11">
        <button class="btn btn-block mb-2 btn-success mt-2">
          Add to WishList
        </button>
      </div>
      <div class="col-11" v-if="profile.id === activeProduct.creatorId">
        <button @click="deleteProduct()" class="btn btn-block btn-danger">
          Delete
        </button>
        <button class="btn btn-block btn-warning">
          Edit
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { useRoute } from 'vue-router'
import { AppState } from '../AppState'
import { productsService } from '../services/ProductsService'
export default {
  name: 'ActiveProductComponent',
  props: ['productProp'],
  setup(props) {
    const route = useRoute()
    onMounted(() => {
      productsService.getActiveProduct(route.params.productId)
    })
    return {
      product: computed(() => props.productProp),
      activeProduct: computed(() => AppState.activeProduct),
      profile: computed(() => AppState.profile),
      deleteProduct() {
        productsService.deleteProduct(route.params.productId)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

.box-shadow{
  box-shadow: 0px 10px 5px rgba(0, 0, 0, 0.406);
}

.border0{
  border: 0;
}

.img{
background-size: inherit;
}

.bottom{
  position: absolute;
  bottom: 10px;
  // align-self: flex-end;
  }

</style>
