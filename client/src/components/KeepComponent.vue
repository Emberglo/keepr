<template>
  <div class="KeepComponent col-6 col-sm-3 p-2">
    <div class="keep container-fluid p-2 h-100 d-flex flex-column justify-content-end shadow-sm" style="background-img: url('{{ keepProp.img }}');">
      <div class="row align-items-end">
        <div class="col-8 text-left">
          <p class="mb-0 font-weight-bold" data-bs-toggle="modal" data-bs-target="#keepModal">{{ keepProp.name }}</p>
        </div>
        <div class="col-4 text-right">
          <img :src="keepProp.creator.picture" alt="Profile Image" class="icon rounded-circle p-0 m-0" @click="ViewProfile">
        </div>
      </div>
    </div>
    <div class="modal fade" id="keepModal" tabindex="-1" aria-labelledby="keepModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <active-keep-component />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
export default {
  name: 'KeepComponent',
  props: {
    keepProp: Object
  },
  setup(props) {
    return {
      keep: computed(() => props.keepProp)
    }
  }
}
</script>

<style lang="scss" scoped>
.keep {
  min-width: 150px;
  min-height: 150px;
  border-radius: 10px;
}
.icon {
  max-width: 20px;
  max-height: 20px;
}

</style>
