<template>
  <div class="container ">
    <section class="row" v-if="user.isAuthenticated">
      <CultForm/>
    </section>
    <section class="row">

      <div v-for="cult in cults" :key="cult.id" class="col-12 col-md-4">
        <CultCard :cult="cult"/>
      </div>

    </section>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { cultsService } from '../services/CultsService.js';
import {AppState} from '../AppState.js'
import CultForm from '../components/CultForm.vue';

export default {
    setup() {
        onMounted(() => {
            getCults();
        });
        async function getCults() {
            try {
                await cultsService.getCults();
            }
            catch (error) {
                Pop.error(error);
            }
        }
        return {
            user: computed(()=> AppState.user),
            cults: computed(() => AppState.cults)
        };
    },
    components: { CultForm }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
