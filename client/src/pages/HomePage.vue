<template>
  <div class="home container-fluid">
    <div class="row" v-if="keeps">
      <keep-component v-for="keep in keeps" :keep-prop="keep" :key="keep.id" class="p-3" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import { vaultsService } from '../services/VaultsService'
export default {
  name: 'Home',
  setup() {
    onMounted(async() => {
      await keepsService.getAllKeeps()
      await vaultsService.getVaults(AppState.profile.id)
    })
    return {
      keeps: computed(() => AppState.keeps),
      profile: computed(() => AppState.profile),
      vaults: computed(() => AppState.vaults)
    }
  }
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}
</style>
