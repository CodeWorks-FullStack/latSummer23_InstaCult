<template>
  <div class="container text-white" v-if="cult">

    <section class="row p-4 cover-img align-items-center">

      <h4 class="col-12">{{ cult.name }}</h4>
      <!-- NOTE user comes back first, so this button appears first -->
      <div v-if="user.isAuthenticated && !isMember">
        <button @click="joinCult" class="btn btn-dark text-danger">User Join Today</button>
      </div>
      <div v-if="account.id && !isMember">
        <button @click="joinCult" class="btn btn-dark text-danger">Account Join Today</button>
      </div>
    </section>

    <section class="row bg-black rounded-bottom">
      <div class="col-12">
        <h3>Our Valued Members <span class="text-danger fw-bold">{{ cult.memberCount }} </span></h3>
      </div>
      <div v-for="c in cultists" :key="c.id" class="col-2">
        <Cultist :cultist="c"/>
        <!-- <img class="img-fluid" :src="c.picture" :alt="`a picture of the cultist ${c.name}`">
        <div class="text-center">{{ c.name.slice(0, c.name.indexOf('@')) }}</div> -->

      </div>
    </section>

    <section class="row mt-4">
      <div class="col-12 col-md-6">
        <h3>Our Leader</h3>
        <div>
          <img class="img-fluid rounded" :src="cult.leader.picture" :alt="`cult leader image of ${cult.leader.name}`">
          <h4>{{ cult.leader.name }}</h4>
        </div>
      </div>
      <div class="col-12 col-md-6 bg-black p-2 rounded">
        <p>{{ cult.description }}</p>
      </div>
    </section>

  </div>
</template>


<script setup>
import { useRoute } from 'vue-router';
import { cultsService } from '../services/CultsService.js';
import Pop from '../utils/Pop.js';
import { computed, onMounted } from 'vue';
import {AppState} from '../AppState.js'
import {cultMembersService} from '../services/CultMembersService.js'

const route = useRoute()
const cult = computed(()=> AppState.activeCult)
const cultists = computed(()=> AppState.cultists)
const user = computed(()=> AppState.user)
const account = computed(()=> AppState.account)

const coverImgStyle = computed(()=>`url(${AppState.activeCult?.coverImg})`)

const isMember = computed(()=> AppState.cultists.find(c => c.id == AppState.account.id))

onMounted(()=>{
  getCultById()
  getCultists()
})

async function getCultById(){
  try {
    await cultsService.getCultById(route.params.cultId)
  } catch (error) {
    Pop.error(error)
  }
}

async function getCultists(){
  try {
    await cultsService.getCultists(route.params.cultId)
  } catch (error) {
    Pop.error(error)
  }
}

async function joinCult(){
  try {
    const cultMember = {cultId: route.params.cultId}
    await cultMembersService.joinCult(cultMember)
  } catch (error) {
    Pop.error(error)
  }
}
</script>


<style lang="scss" scoped>
.cover-img{
  height: 40dvh;
  background-image: v-bind(coverImgStyle);
  background-position: center;
  background-size: cover;
}
</style>
