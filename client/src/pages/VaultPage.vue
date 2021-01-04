<template>
  <div class="VaultPage container-fluid">
    <div class="row mt-3">
      <div class="col-12 mt-3 p-3">
        <h1 class="ml-5">vault.name</h1>
        <p class="ml-5">Keeps: vault.keeps</p>
      </div>
    </div>
    <div class="row">
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'VaultPage',
  setup() {
    return {
      profile: computed(() => AppState.profile)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 350px;
  border-radius: 15px;
}
</style>
