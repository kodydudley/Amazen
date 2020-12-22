<template>
  <div class="post container-fluid">
    <div class="row">
      <div class="col-8 offset-2 text-center">
        <h1>Post a new Product</h1>
      </div>
    </div>
    <div class="row">
      <div class="col-8 offset-2">
        <form action="HomePage.vue" class="form-group" @submit.prevent="post(state.newPost)">
          <div class="form-group">
            <label for="title">Title</label>
            <input type="text" id="title" class="form-control" placeholder="Enter Title" v-model="state.newPost.title">
          </div>
          <div class="form-group">
            <label for="description">Description</label>
            <input type="text-area" id="description" class="form-control" placeholder="Enter Description" v-model="state.newPost.description">
          </div>
          <div class="form-group">
            <label for="picture">Picture</label>
            <input type="text" id="picture" class="form-control" placeholder="Enter Picture Url" v-model="state.newPost.picture">
          </div>
          <div class="form-group">
            <label for="price">Price</label>
            <input type="text" id="price" class="form-control" placeholder="Enter Price" v-model="state.newPost.price">
          </div>
          <div class="text-center">
            <button class="btn btn-dark text-white" type="submit">
              Post
            </button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive, computed } from 'vue'
import { AppState } from '../AppState'
import { productsService } from '../services/ProductsService'
export default {
  name: 'PostPage',
  setup() {
    const state = reactive({
      newPost: {
        title: '',
        description: '',
        picture: '',
        price: ''
      }
    })
    return {
      state,
      post(newPost) {
        // state.newBlog either or
        productsService.post(newPost)
      },
      profile: computed(() => AppState.profile),
      blogs: computed(() => AppState.blogs)
    }
  }
}

</script>
