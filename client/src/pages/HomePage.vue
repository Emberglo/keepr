<template>
  <div class="home container">
    <div class="row" v-if="keeps">
      <div class="card-columns">
        <keep-component v-for="keep in keeps" :keep-prop="keep" :key="keep.id" class="card-container"/>
      </div>
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
.home {
  margin: 2.5% 0 2.5% 0;
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}
.row {
  width: 95vw;
  margin: 0;
}
.card-columns {
  width: 100%;
  column-count: 4;
}
@media screen and (max-width: 1000px) {
  .card-columns {
    column-count: 2;
  }
}
</style>
