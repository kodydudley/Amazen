<template>
  <div class="productComponent col-3">
    <div class="card p-2 m-2 shadow-lg">
      <h1>{{ product.title }}</h1>
      <img class="img-fluid" :src="product.picture" alt="">
      <p>{{ product.description }}</p>
      <h6>${{ product.price }}</h6>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
export default {
  name: 'ProductComponent',
  props: ['productProp'],
  setup(props) {
    return {
      product: computed(() => props.productProp)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
