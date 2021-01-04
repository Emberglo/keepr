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
      <h2 class="ml-3 p-3">Vaults</h2>
      <i class="fas fa-plus text-dark" type="button"  data-bs-toggle="modal" data-bs-target="#vaultsModal"></i>
    </div>
    <div class="row">
    </div>
    <div class="row mt-3 align-items-center">
      <h2 class="ml-3 p-3">Keeps</h2>
      <i class="fas fa-plus text-dark" type="button" data-bs-toggle="modal" data-bs-target="#keepsModal"></i>
    </div>
    <div class="row">
    </div>

    <!-- Modal -->
    <div class="modal fade" id="vaultsModal" tabindex="-1" aria-labelledby="vaultsModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content border border-primary">
          <div class="modal-header">
            <h5 class="modal-title" id="vaultsModalLabel">New Vault</h5>
            <button type="button" class="btn-close bg-danger" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <form>
              <div class="mb-3">
                <label for="title" class="form-label">Title</label>
                <input type="text" class="form-control" id="title" aria-describedby="vaultTitle" placeholder="Title...">
              </div>
              <div class="mb-3">
                <label for="imgUrl" class="form-label">Image URL</label>
                <input type="text" class="form-control" id="imgUrl" placeholder="URL...">
              </div>
              <div class="mb-3 form-check">
                <input type="checkbox" class="form-check-input" id="privateVault">
                <label class="form-check-label" for="privateVault">Private Vault?</label>
                <div id="privateVault" class="form-text">Private vaults can only be seen by you.</div>
              </div>
              <button type="submit" class="btn btn-primary">Create</button>
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
            <h5 class="modal-title" id="keepsModalLabel">New Keep</h5>
            <button type="button" class="btn-close bg-danger" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <form>
              <div class="mb-3">
                <label for="title" class="form-label">Title</label>
                <input type="text" class="form-control" id="title" aria-describedby="vaultTitle" placeholder="Title...">
              </div>
              <div class="mb-3">
                <label for="imgUrl" class="form-label">Image URL</label>
                <input type="text" class="form-control" id="imgUrl" placeholder="URL...">
              </div>
              <div class="mb-3">
                <label for="description" class="form-label">Description</label>
                <input type="textarea" class="form-control" id="description" aria-describedby="vaultTitle" placeholder="Description...">
              </div>
              <div class="mb-3">
                <label for="tags" class="form-label">Tags</label>
                <input type="text" class="form-control" id="tags" placeholder="Tags...">
                <div id="tags" class="form-text">Seperate tags with a comma</div>
              </div>
              <button type="submit" class="btn btn-primary">Create</button>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'Profile',
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
