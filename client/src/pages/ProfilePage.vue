<template>
  <div class="about container-fluid">
    <div class="row mt-3">
      <div class="col-2 p-3 ml-3">
        <img class="rounded" :src="profile.picture" alt="" />
      </div>
      <div class="col-8 p-3">
        <h1>{{ profile.name }}</h1>
        <h5>Vaults: {{ profile.vaults }}</h5>
        <h5>Keeps: {{ profile.keeps }}</h5>
      </div>
    </div>
    <div class="row mt-3 align-items-center">
      <h2 class="ml-3 p-3">
        Vaults
      </h2>
      <i class="fas fa-plus text-dark" type="button" data-bs-toggle="modal" data-bs-target="#vaultsModal"></i>
    </div>
    <div class="row">
      <vault-component v-for="vault in vaults" :vault-prop="vault" :key="vault.id" class="p-3" />
    </div>
    <div class="row mt-3 align-items-center">
      <h2 class="ml-3 p-3">
        Keeps
      </h2>
      <i class="fas fa-plus text-dark" type="button" data-bs-toggle="modal" data-bs-target="#keepsModal"></i>
    </div>
    <div class="row">
      <profile-keep-component v-for="profileKeep in profileKeeps" :profile-keep-prop="profileKeep" :key="profileKeep.id" class="p-3" />
    </div>

    <!-- Modal -->
    <div class="modal fade" id="vaultsModal" tabindex="-1" aria-labelledby="vaultsModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content border border-primary">
          <div class="modal-header">
            <h5 class="modal-title" id="vaultsModalLabel">
              New Vault
            </h5>
            <button type="button" class="btn-close bg-danger" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="createVault">
              <div class="mb-3">
                <label for="vaultTitle" class="form-label">Title</label>
                <input type="text"
                       class="form-control"
                       id="vaultTitle"
                       aria-describedby="vaultTitle"
                       placeholder="Title..."
                       v-model="state.newVault.name"
                >
              </div>
              <div class="mb-3">
                <label for="vaultDescription" class="form-label">Description</label>
                <input type="text"
                       class="form-control"
                       id="vaultDescription"
                       placeholder="Description..."
                       v-model="state.newVault.description"
                >
              </div>
              <div class="mb-3 form-check">
                <input type="checkbox"
                       class="form-check-input"
                       id="privateVault"
                       v-model="state.newVault.isPrivate"
                >
                <label class="form-check-label" for="privateVault">Private Vault?</label>
                <div id="privateVaultHelp" class="form-text seeThrough">
                  Private vaults can only be seen by you.
                </div>
              </div>
              <div class="w-100 d-flex justify-content-end align-items-center">
                <button type="submit" class="btn btn-primary">
                  Create
                </button>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>

    <!-- Modal -->
    <div class="modal fade" id="keepsModal" tabindex="-1" aria-labelledby="keepsModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content border border-primary">
          <div class="modal-header">
            <h5 class="modal-title" id="keepsModalLabel">
              New Keep
            </h5>
            <button type="button" class="btn-close bg-danger" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="createKeep">
              <div class="mb-3">
                <label for="keepTitle" class="form-label">Title</label>
                <input type="text"
                       class="form-control"
                       id="keepTitle"
                       aria-describedby="vaultTitle"
                       placeholder="Title..."
                       v-model="state.newKeep.name"
                >
              </div>
              <div class="mb-3">
                <label for="imgUrl" class="form-label">Image URL</label>
                <input type="text"
                       class="form-control"
                       id="imgUrl"
                       placeholder="URL..."
                       v-model="state.newKeep.img"
                >
              </div>
              <div class="mb-3">
                <label for="keepDescription" class="form-label">Description</label>
                <input type="textarea"
                       class="form-control"
                       id="keepDescription"
                       aria-describedby="vaultTitle"
                       placeholder="Description..."
                       v-model="state.newKeep.description"
                >
              </div>
              <!-- <div class="mb-3">
                <label for="tags" class="form-label">Tags</label>
                <input type="text"
                       class="form-control"
                       id="tags"
                       placeholder="Tags..."
                       v-model="state.newKeep.tags"
                >
                <div id="tagsHelp" class="form-text seeThrough">
                  Seperate tags with a comma
                </div>
              </div> -->
              <div class="w-100 d-flex justify-content-end align-items-center">
                <button type="submit" class="btn btn-primary">
                  Create
                </button>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { profileService } from '../services/ProfileService'
import { vaultsService } from '../services/VaultsService'
import { keepsService } from '../services/KeepsService'
export default {
  name: 'Profile',
  setup() {
    const state = reactive({
      newKeep: {},
      newVault: {}
    })
    onMounted(async() => {
      await profileService.getOtherProfile(AppState.profile.id)
      await vaultsService.getVaults(AppState.profile.id)
      await keepsService.getProfileKeeps(AppState.profile.id)
    })
    return {
      state,
      profile: computed(() => AppState.profile),
      otherProfile: computed(() => AppState.otherProfile),
      vaults: computed(() => AppState.vaults),
      profileKeeps: computed(() => AppState.profileKeeps),
      async createVault() {
        await vaultsService.createVault(state.newVault, this.profile.id)
        state.newVault = {}
      },
      async createKeep() {
        await keepsService.createKeep(state.newKeep, this.profile.id)
        state.newKeep = {}
      }
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
