<template>
  <div class="position-relative">
    <img class="img-fluid" :src="cultist.picture" :alt="`a picture of the cultist ${cultist.name}`">
    <div class="text-center">{{ cultist.name.slice(0, cultist.name.indexOf('@')) }}</div>
    <button @click="removeCultMember" v-if="canDelete" class="btn btn-danger rounded-circle position-absolute"><i class="mdi mdi-cancel"></i></button>
  </div>
</template>

<script setup>
import { computed } from 'vue';
import { Cultist } from '../models/Account.js';
import { AppState } from '../AppState.js';
import Pop from '../utils/Pop.js';
import { cultMembersService } from '../services/CultMembersService.js';

const props = defineProps({cultist: {type: Cultist, required: true}})
const canDelete = computed(()=> AppState.account.id == AppState.activeCult?.leaderId)

async function removeCultMember(){
  try {
    await cultMembersService.removeCultMember(props.cultist.cultMemberId)
    Pop.success('cult member exiled!')
  } catch (error) {
    Pop.error(error)
  }
}

</script>

<style scoped>
button{
  top: 0;
  left: 0;
  width: 100%;
  aspect-ratio: 1/1;
  opacity: 0;
}
button:hover{
  opacity: 1;
  transition: opacity .2s ease;
}
</style>
