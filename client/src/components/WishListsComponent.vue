<template>
  <div class="wishListsComponent col-3 my-3 p-0 justify-content-between">
    <div class="col-10 offset-1">
      <h1>{{ wishlist.name }}</h1>
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
