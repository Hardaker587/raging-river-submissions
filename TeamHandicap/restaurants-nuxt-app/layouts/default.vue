<template>
  <div>
    <AppHeader />
    <div class="body-wrap">
      <Nuxt />
    </div>
    <AppFooter />
    <div v-if="showLogin || showRegister" class="modal-background">
      <Login v-if="showLogin" />
      <Register v-else />
    </div>
  </div>
</template>

<script>
import { mapState } from 'vuex'
import AppHeader from '@/components/app-header/app-header'
import AppFooter from '@/components/app-footer/app-footer'
import Login from '@/components/login/index'
import Register from '@/components/register/index'

export default {
  components: {
    AppHeader,
    AppFooter,
    Login,
    Register
  },
  computed: {
    ...mapState([ 'showLogin', 'showRegister' ])
  }
}
</script>

<style lang="scss" rel="stylesheet/scss">
@import '@/node_modules/bootstrap/dist/css/bootstrap-grid.min.css';
@import '@/styles.scss';
</style>

<style scoped>
.body-wrap {
    width: 100%;
    min-height: 100vh;
    padding: 40px 0 50px;
    margin: -40px 0 -30px;
}

.modal-background {
  position: fixed;
  width: 100%;
  height: 100%;
  top: 0;
  right: 0;
  bottom: 0;
  left: 0;
  background-color: rgba(9, 9, 9, 0.8);
}
</style>