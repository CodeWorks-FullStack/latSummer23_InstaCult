<template>
  <router-link :to="{name: 'Cult Details', params:{cultId: cult.id}}">
    <div class="card mb-2 elevation-2 bg-dark lighten-20 text-danger">
      <div class="card-img">
        <img class="blur" src="https://images.unsplash.com/photo-1519751138087-5bf79df62d5b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=200&q=1"/>
        <img :src="cult.coverImg" @load="pictureLoaded = true" class="transparent" :class="{'fade-in': pictureLoaded}"/>
      </div>
      <div class="p-2">
        <p class="fs-3 text-danger">{{ cult.name }}</p>
        <div class="d-flex justify-content-between">
          <div>
            👥{{ cult.memberCount }}
          </div>
          <div>
            <img class="profile-pic" :src="cult.leader.picture" :title="cult.leader.name" alt="">
          </div>
        </div>
    </div>
  </div>
</router-link>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import { Cult } from '../models/Cult.js';
export default {
  props: {cult: {type: Cult, required: true}},
  setup(){
    const pictureLoaded = ref(false)
  return { pictureLoaded }
  }
};
</script>


<style lang="scss" scoped>
.card{
  overflow: hidden;
}

.card-img>img{
  width: 100%;
  object-fit: cover;
  object-position: center;
  grid-column: 1/1;
  grid-row: 1/1;
  height: 100%;
  object-fit: cover;
  backdrop-filter: blur(50px);
}


.profile-pic{
  height: 50px;
  aspect-ratio: 1/1;
  border-radius: 10px;
}

.card-img{
  display: grid;
  grid-template-columns: 1fr;
  grid-template-rows: 1fr;
}

.transparent{
  opacity: 0;
}
.fade-in{
 opacity: 1;
 transition: all ease-in .2s;
}
</style>
