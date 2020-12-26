<template>
  <div class="wishListsComponent col-12 my-3 p-0 justify-content-between">
    <div class="col-10 offset-1">
      <h3 class="text-center bg-info rounded">
        {{ wishlist.name }}
      </h3>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
export default {
  name: 'WishListsComponent',
  props: ['wishlistProp'],
  setup(props) {
    return {
      wishlist: computed(() => props.wishlistProp)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

.rounded{
  border-radius: 30px;
}

</style>
