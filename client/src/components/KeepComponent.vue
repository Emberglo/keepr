<template>
  <div class="KeepComponent col-6 col-sm-3 p-2">
    <div class="keep container-fluid p-2 h-100 d-flex flex-column justify-content-end shadow-sm border border-primary" :style="{ backgroundImage: `url(${keepProp.img})` }">
      <div class="row align-items-end">
        <div class="col-8 text-left cursor-pointer">
          <p class="mb-0 font-weight-bold" data-bs-toggle="modal" data-bs-target="#keepModal" @click="getActiveKeep(keep.id)">{{ keepProp.name }}</p>
        </div>
        <div class="col-4 text-right cursor-pointer">
          <img :src="keepProp.creator.picture" alt="Profile Image" class="icon rounded-circle p-0 m-0" @click="getOtherProfile(keepProp.creatorId)">
        </div>
      </div>
    </div>
    <div class="modal fade" id="keepModal" tabindex="-1" aria-labelledby="keepModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-xl p-5">
        <div class="modal-content container-fluid p-5">
          <div class="row justify-content-center align-items-center w-100">
            <div class="col-12 col-md-6">
              <img :src="keep.img" alt="keepImg" class="img-fluid">
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
                <p>{{ keep.views }}</p>
                <p class="mx-4">{{ keep.keeps }}</p>
                <p>{{ keep.shares }}</p>
              </div>
              <div class="row mb-3">
                <div class="col-12">
                  <h3 class="mb-3">{{ keep.name }}</h3>
                  <p>{{ keep.description }}</p>
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
                  <button class="btn btn-outline-primary">
                    Add To Vault
                  </button>
                </div>
                <div class="col-6 d-flex align-items-center">
                  <img :src="keepProp.creator.picture" alt="Profile Image" class="icon rounded-circle p-0 m-0 mr-2">
                  <p class="mb-0">{{ keepProp.creator.name }}</p>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
import { useRouter } from 'vue-router'
export default {
  name: 'KeepComponent',
  props: {
    keepProp: Object
  },
  setup(props) {
    const router = useRouter()
    return {
      keep: computed(() => props.keepProp),
      profile: computed(() => AppState.profile),
      getActiveKeep(keepId) {
        const index = AppState.keeps.findIndex(k => k.id === keepId)
        AppState.activeKeep = AppState.keeps[index]
      },
      getOtherProfile(creatorId) {
        router.push({ name: 'OtherProfilePage', params: { profileId: creatorId } })
      }
    }
  }
}
</script>

<style lang="scss" scoped>
.keep {
  min-width: 150px;
  min-height: 150px;
  border-radius: 10px;
  background-size: cover;
}
.icon {
  max-width: 20px;
  max-height: 20px;
}

</style>
