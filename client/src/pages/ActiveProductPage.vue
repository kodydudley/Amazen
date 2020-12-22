<template>
  <div class="activeProduct">
    <div class="col-10 offset-1 pt-5 bg-white">
      <active-product-component />
    </div>
  </div>
</template>

<script>
import ActiveProductComponent from '../components/ActiveProductComponent.vue'
export default {
  name: 'ActiveProductPage',
  setup(props) {
    return {
    }
  },
  components: { ActiveProductComponent }
}
</script>

<style lang="scss" scoped>

</style>
