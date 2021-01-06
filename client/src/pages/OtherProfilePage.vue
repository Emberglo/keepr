<template>
  <div class="OtherProfile container-fluid">
    <div class="row mt-3">
      <div class="col-2 p-3 ml-3">
        <img class="rounded" :src="otherProfile.picture" alt="" />
      </div>
      <div class="col-8 p-3">
        <h1>{{ otherProfile.name }}</h1>
        <h5>Vaults: {{ otherProfileVaults.length }}</h5>
        <h5>Keeps: {{ profileKeeps.length }}</h5>
      </div>
    </div>
    <div class="row mt-3 align-items-center">
      <h2 class="ml-3 p-3">Vaults</h2>
    </div>
    <div class="row">
      <vault-component v-for="vault in vaults" :vault-prop="vault" :key="vault.id" class="p-3" />
    </div>
    <div class="row mt-3 align-items-center">
      <h2 class="ml-3 p-3">Keeps</h2>
    </div>
    <div class="row">
      <div class="card-columns">
        <profile-keep-component v-for="profileKeep in profileKeeps" :profile-keep-prop="profileKeep" :key="profileKeep.id" class="card-container" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { useRoute } from 'vue-router'
import { profileService } from '../services/ProfileService'
import { vaultsService } from '../services/VaultsService'
import { keepsService } from '../services/KeepsService'
export default {
  name: 'OtherProfilePage',
  setup() {
    const route = useRoute()
    onMounted(async() => {
      await profileService.getOtherProfile(route.params.profileId)
      await vaultsService.getVaults(route.params.profileId)
      await keepsService.getProfileKeeps(route.params.profileId)
    })
    return {
      otherProfile: computed(() => AppState.otherProfile),
      vaults: computed(() => AppState.vaults),
      profileKeeps: computed(() => AppState.profileKeeps),
      otherProfileVaults: computed(() => AppState.vaults.filter(v => v.isPrivate === false))
    }
  }
}
</script>

<style scoped>
img {
  max-width: 350px;
  border-radius: 15px;
}
.seeThrough {
  opacity: 0.7;
}
</style>
