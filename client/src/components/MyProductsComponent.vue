<template>
  <div class="myProductsComponent col-3 my-3 p-0 justify-content-between">
    <div class="col-10 offset-1">
      <router-link :to="{name: 'ActiveProduct', params: {productId: product.id}}">
        <div class="card border0 box-shadow">
          <img class="fixed-height img" :src="product.picture" alt="">
        </div>
      </router-link>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
export default {
  name: 'MyProductsComponent',
  props: ['productProp'],
  setup(props, product) {
    return {
      product: computed(() => props.productProp)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

.fixed-height{
  height: 200px;
  width: 200px;
}

.box-shadow{
  box-shadow: 0px 10px 5px rgba(0, 0, 0, 0.406);
}

.border0{
  border: 0;
}

.img{
width: 100%;
height: 200px;
}

</style>
