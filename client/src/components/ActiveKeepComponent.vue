<template>
  <div class="ActiveKeepComponent container-fluid">
    <div class="row justify-content-center align-items-center w-100">
      <div class="col-12 col-md-6">
        <img :src="activeKeep.img" alt="keepImg" class="img-fluid">
      </div>
      <div class="col-12 col-md-6">
        <div class="row justify-content-end">
          <i type="button" class="fas fa-minus text-danger mr-4 p-3" data-bs-dismiss="modal" aria-label="Close"></i>
        </div>
        <div class="row justify-content-center mb-1">
          <i class="far fa-eye"></i>
          <i class="fab fa-kaggle mx-4"></i>
          <i class="fas fa-share-alt"></i>
        </div>
        <div class="row justify-content-center mb-3">
          <p>{{ activeKeep.views }}</p>
          <p class="mx-4">{{ activeKeep.keeps }}</p>
          <p>{{ activeKeep.shares }}</p>
        </div>
        <div class="row mb-3">
          <div class="col-12">
            <h3 class="mb-3">{{ activeKeep.name }}</h3>
            <p>{{ activeKeep.description }}</p>
          </div>
        </div>
        <hr class="w-75">
        <div class="row mb-3">
          <div class="col-12">
            <p>keep tags</p>
          </div>
        </div>
        <div class="row justify-content-around align-items-center">
          <div class="col-6">
            <button class="btn btn-outline-primary">Add To Vault</button>
          </div>
          <div class="col-6 d-flex align-items-center">
            <!-- <img :src="creator.picture" alt="Profile Image" class="icon rounded-circle p-0 m-0 mr-2">
            <p class="mb-0">{{ creator.name }}</p> -->
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'ActiveKeepComponent',
  setup() {
    return {
      activeKeep: computed(() => AppState.activeKeep)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.ActiveKeepComponent {
  width: 100%;
  height: 100%;
}
.keep {
  min-width: 150px;
  min-height: 150px;
  background-image: url("");
}
.icon {
  max-width: 20px;
  max-height: 20px;
}
</style>
