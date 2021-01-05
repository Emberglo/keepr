<template>
  <div class="VaultComponent col-6 col-sm-3 p-2">
    <div class="vault container-fluid p-2 h-100 d-flex flex-column justify-content-end shadow-sm border border-primary">
      <div class="row align-items-end">
        <div class="col-12 text-center">
          <h3 class="cursor-pointer">{{ vault.name }}</h3>
        </div>
        <!-- <div class="col-12 text-center">
          <p>{{ vault.description }}</p>
        </div> -->
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
export default {
  name: 'VaultComponent',
  props: {
    vaultProp: Object
  },
  setup(props) {
    return {
      vault: computed(() => props.vaultProp)
    }
  }
}
</script>

<style lang="scss" scoped>
.vault {
  min-width: 150px;
  min-height: 150px;
  border-radius: 10px;
  background-size: cover;
  background-color: #18d2d1;
}
.icon {
  max-width: 20px;
  max-height: 20px;
}

</style>
