<template>
  <div class="ActiveKeepComponent">
    <div class="row justify-content-end">
      <i type="button" class="fas fa-minus text-danger mr-4 p-3" data-bs-dismiss="modal" aria-label="Close"></i>
    </div>
    <div class="row">
      <div class="col-6">
        <img src="" alt="">
      </div>
      <div class="col-6">
        <div class="row justify-content-center">
          <i class="far fa-eye"></i>
          <i class="fab fa-kaggle"></i>
          <i class="fas fa-share-alt"></i>
        </div>
        <div class="row">
          <div class="col-12">
            <h1>Keep Title</h1>
            <p>Keep Description</p>
          </div>
        </div>
        <hr>
        <div class="row">
          <div class="col-12">
            <p>keep tags</p>
          </div>
        </div>
        <div class="row justify-content-around">
          <div class="col-3">
            <button class="btn btn-outline-primary">Add To Vault</button>
          </div>
          <div class="col-3">
            <img src="" alt="">
            <p>profile name</p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
export default {
  name: 'ActiveKeepComponent',
  props: {
    keepProp: Object
  },
  setup(props) {
    return {
      keep: computed(() => props.keepProp)
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
  background-image: url("${keepProp.img}");
}
.icon {
  max-width: 20px;
  max-height: 20px;
}

</style>
