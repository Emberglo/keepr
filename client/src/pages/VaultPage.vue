<template>
  <div class="VaultPage container-fluid">
    <div class="row mt-3">
      <div class="col-12 mt-3 p-3">
        <h1 class="ml-5">{{ vault.name}} </h1>
        <p class="ml-5">Keeps: {{ vaultKeeps.length }}</p>
      </div>
    </div>
    <hr class="w-100">
    <div class="row">
      <div class="card-columns">
        <vault-keep-component v-for="vaultKeep in vaultKeeps" :vault-keep-prop="vaultKeep" :key="vaultKeep.id" class="column-container"/>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { useRoute } from 'vue-router'
import { vaultsService } from '../services/VaultsService'
export default {
  name: 'VaultPage',
  setup() {
    const route = useRoute()
    onMounted(async() => {
      await vaultsService.getActiveVault(route.params.vaultId)
      await vaultsService.getVaultKeeps(route.params.vaultId)
    })
    return {
      profile: computed(() => AppState.profile),
      vault: computed(() => AppState.activeVault),
      vaultKeeps: computed(() => AppState.vaultKeeps)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 350px;
  border-radius: 15px;
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
