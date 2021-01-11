<template>
  <v-app dark>
    <div class="main">
      <navbar />
      <nuxt />
    </div>
  </v-app>
</template>

<script>
import Navbar from '~/components/Navbar'

export default {
  components: {
    Navbar
  }
}
</script>

<style scoped>
.app {
  height: 100vh;
  width: 100vw;
}
.main {
  max-width: 1024px;
  margin: 0 auto;
  padding: 30px;
}
</style>
