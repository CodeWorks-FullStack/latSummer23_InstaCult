<template>
<form @submit.prevent="createCult" class="text-light p-3 bg-dark border border-danger elevation-2 row">
  <div class="col-12">START A CULT</div>
  <div class="mb-3 col-4">
    <label for="">Name</label>
    <input v-model="cultData.name" type="text" minlength="5" class="form-control bg-dark text-light" required>
  </div>
  <div class="mb-3 col-4">
    <label for="">Entry Fee</label>
    <input v-model="cultData.fee" type="number" min="0" class="form-control bg-dark text-light" required>
  </div>
  <div class="mb-3 col-4">
    <label for="">Requires Invitation</label>
    <input v-model="cultData.invitationRequired" type="checkbox" class="form-checkbox bg-dark text-light">
  </div>
  <div class="mb-3 col-12">
    <label for="">Describe the cult</label>
    <textarea v-model="cultData.description" rows="10" class="form-control bg-dark text-light"></textarea>
  </div>
  <div class="mb-3 col-12">
    <label for="">Cover Image</label>
    <input v-model="cultData.coverImg" type="url" class="form-control bg-dark text-light">
    <img :src="cultData.coverImg" alt="" class="img-fluid">
  </div>
  <button class="btn btn-success">Get Going</button>
</form>
</template>


<script setup>
import { onMounted, ref } from 'vue';
import Pop from '../utils/Pop.js';
import { cultsService } from '../services/CultsService.js';
import { AppState } from '../AppState.js';


  const cultData = ref({})
  onMounted(()=> resetForm())

  async function createCult(){
    try {
      await cultsService.createCult(cultData.value)
      Pop.toast("Cult Created!")
      resetForm()
    } catch (error) {
      Pop.error(error)
    }
  }

  async function resetForm(){
    // NOTE pre-populate form with data
    // cultData.value = AppState.activeCult || {}
    cultData.value = {fee: 25}
  }
</script>


<style lang="scss" scoped>

</style>
