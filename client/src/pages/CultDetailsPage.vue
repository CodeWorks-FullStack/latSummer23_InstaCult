<template>
  <div class="component text-white">
    {{ cult?.name }}

  </div>
</template>


<script setup>
import { useRoute } from 'vue-router';
import { cultsService } from '../services/CultsService.js';
import Pop from '../utils/Pop.js';
import { computed, onMounted } from 'vue';
import {AppState} from '../AppState.js'

const route = useRoute()
const cult = computed(()=> AppState.activeCult)

onMounted(()=>{
  getCultById()
})

async function getCultById(){
  try {
    await cultsService.getCultById(route.params.cultId)
  } catch (error) {
    Pop.error(error)
  }
}
</script>


<style lang="scss" scoped>

</style>
