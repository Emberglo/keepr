<template>
  <div class="VaultKeepComponent card">
    <img class="card-img" :src="vaultKeepProp.img" alt="Card image">
    <div class="card-img-overlay container-fluid d-flex flex-column justify-content-between h-100">
      <div class="row w-100 justify-content-end">
        <i type="button" class="fas fa-minus text-danger cursor-pointer" v-if="profile.id == vaultKeepProp.creatorId" @click="deleteVaultKeep(keep.vaultKeepId)"></i>
      </div>
      <div class="row w-100 justify-content-between">
        <h5 class="mb-0 cursor-pointer" data-bs-toggle="modal" :data-bs-target="'#keepModal'+keep.id"  @click="getActiveKee (keep.id)">{{ vaultKeepProp.name }}</h5>
        <img :src="vaultKeepProp.creator.picture" alt="Profile Image" class="icon rounded-circle p-0 m-0 cursor-pointer" @click="getOtherProfile(vaultKeepProp.creatorId)">
      </div>
    </div>
  </div>
  <!-- <div class="VaultKeepComponent col-6 col-sm-3 p-2">
    <div class="keep container-fluid p-2 h-100 d-flex flex-column justify-content-between shadow-sm border border-primary" :style="{ backgroundImage: `url(${vaultKeepProp.img})` }">
      <div class="row align-self-start justify-content-end w-100">
        <i type="button" class="fas fa-minus text-danger cursor-pointer" @click="deleteVaultKeep(keep.vaultKeepId)"></i>
      </div>
      <div class="row align-items-end">
        <div class="col-8 text-left cursor-pointer">
          <p class="mb-0 font-weight-bold" data-bs-toggle="modal" :data-bs-target="'#keepModal'+keep.id" @click="getActiveKeep(keep.id)">{{ vaultKeepProp.name }}</p>
        </div>
        <div class="col-4 text-right cursor-pointer">
          <img :src="vaultKeepProp.creator.picture" alt="Profile Image" class="icon rounded-circle p-0 m-0" @click="getOtherProfile(vaultKeepProp.creatorId)">
        </div>
      </div>
    </div> -->
  <div class="modal fade" :id="'keepModal'+keep.id" tabindex="-1" aria-labelledby="keepModalLabel" aria-hidden="true">
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
                <form @submit.prevent="addToVault(keep.id)" class="row flex-column">
                  <select name="VaultId" id="VaultId" v-model="state.newVaultKeep.VaultId">
                    <option v-for="vault in vaults" :key="vault.id" :value="vault.id">
                      {{ vault.name }}
                    </option>
                  </select>
                  <button type="submit" class="btn btn-outline-primary">
                    Add To Vault
                  </button>
                </form>
              </div>
              <div class="col-6 d-flex align-items-center">
                <img :src="vaultKeepProp.creator.picture" alt="Profile Image" class="icon rounded-circle p-0 m-0 mr-2">
                <p class="mb-0">{{ vaultKeepProp.creator.name }}</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { useRouter, useRoute } from 'vue-router'
import { vaultsService } from '../services/VaultsService'
export default {
  name: 'VaultKeepComponent',
  props: {
    vaultKeepProp: Object
  },
  setup(props) {
    onMounted(async() => {
    })
    const state = reactive({
      newVaultKeep: {}
    })
    const router = useRouter()
    const route = useRoute()
    return {
      state,
      keep: computed(() => props.vaultKeepProp),
      profile: computed(() => AppState.profile),
      vaults: computed(() => AppState.vaults),
      getActiveKeep(keepId) {
        const index = AppState.keeps.findIndex(k => k.id === keepId)
        AppState.activeKeep = AppState.keeps[index]
        vaultsService.getVaults(AppState.profile.id)
      },
      getOtherProfile(creatorId) {
        router.push({ name: 'OtherProfilePage', params: { profileId: creatorId } })
      },
      addToVault(keepId) {
        state.newVaultKeep.KeepId = keepId
        vaultsService.addToVault(state.newVaultKeep)
      },
      deleteVaultKeep(vaultKeepId) {
        vaultsService.deleteVaultKeep(vaultKeepId, route.params.vaultId)
      }
    }
  }
}
</script>

<style lang="scss" scoped>
.card {
  border-radius: 10px;
  margin: 15px;
  box-shadow: 10px 10px 24px -12px rgba(0,0,0,0.75);
  transition: 0.3s;
}
.card img {
  width: 100%;
  transition: 0.3s;
  border-radius: 10px;
}
.card:hover img {
  transform: scale(0.8);
}
.icon {
  max-width: 20px;
  max-height: 20px;
}
</style>
