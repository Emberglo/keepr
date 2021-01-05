<template>
  <div class="ProfileKeepComponent col-6 col-sm-3 p-2">
    <div class="keep container-fluid p-2 h-100 d-flex flex-column justify-content-between shadow-sm border border-primary" :style="{ backgroundImage: `url(${profileKeepProp.img})` }">
      <div class="row align-self-start justify-content-end w-100">
        <i type="button" class="fas fa-minus text-danger cursor-pointer" v-if="profile.id == profileKeepProp.creatorId" @click="deleteKeep"></i>
      </div>
      <div class="row align-items-end">
        <div class="col-8 text-left cursor-pointer">
          <p class="mb-0 font-weight-bold" data-bs-toggle="modal" data-bs-target="#keepModal" @click="getActiveKeep(keep.id)">{{ profileKeepProp.name }}</p>
        </div>
        <div class="col-4 text-right cursor-pointer">
          <img :src="profileKeepProp.creator.picture" alt="Profile Image" class="icon rounded-circle p-0 m-0" @click="getOtherProfile(profileKeepProp.creatorId)">
        </div>
      </div>
    </div>
    <div class="modal fade" id="keepModal" tabindex="-1" aria-labelledby="keepModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-xl p-5">
        <div class="modal-content p-5">
          <active-keep-component />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
import { useRouter } from 'vue-router'
import { keepsService } from '../services/KeepsService'
export default {
  name: 'ProfileKeepComponent',
  props: {
    profileKeepProp: Object
  },
  setup(props) {
    const router = useRouter()
    return {
      keep: computed(() => props.profileKeepProp),
      profile: computed(() => AppState.profile),
      getActiveKeep(keepId) {
        const index = AppState.keeps.findIndex(k => k.id === keepId)
        AppState.activeKeep = AppState.keeps[index]
      },
      getOtherProfile(creatorId) {
        router.push({ name: 'OtherProfilePage', params: { profileId: creatorId } })
      },
      deleteKeep() {
        keepsService.deleteKeep(this.keep.id, this.profile.id)
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
