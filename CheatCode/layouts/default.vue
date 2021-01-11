<template>
  <v-app dark :style="returnImage">
    <NavBar :is-logged-in="isLoggedIn" :account="user" :admin="admin" />
    <v-main>
      <v-container fluid>
        <nuxt />
      </v-container>
    </v-main>
    <Footer :background-info="background" />
    <Notifications />
    <login-register-dialog :show-form="loginDialog" @hide-modal="resetDialog" />
  </v-app>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
import NavBar from '~/components/UI/NavBar'
import Footer from '~/components/UI/Footer'
import Notifications from '~/components/UI/Notifications'
import LoginRegisterDialog from '~/components/UI/loginRegisterDialog'
export default {
  components: { LoginRegisterDialog, Notifications, Footer, NavBar },
  data() {
    return {
      image: '',
      background: null,
      loginDialog: false,
    }
  },
  computed: {
    ...mapGetters({
      isLoggedIn: 'auth/isLoggedIn',
      user: 'auth/authUser',
      admin: 'auth/admin',
    }),
    returnImage() {
      return `background-image: url('/images/textures/2k_stars_milky_way.jpg'); background-size: 100vw 100vh; background-attachment: fixed`
    },
  },
  async created() {
    // event bus
    this.$nuxt.$on('log-out', this.terminate)
    this.$nuxt.$on('navigate', (route) => {
      this.navigate(route)
    })
    this.$nuxt.$on('hideModal', this.resetDialog)
    this.$nuxt.$on('closeDialog', this.resetDialog)
    // auth
    await this.$fire.auth.onAuthStateChanged((userAuth) => {
      if (userAuth) {
        this.$fire.auth.currentUser.getIdTokenResult().then((tokenResult) => {
          if (tokenResult.claims.admin) {
            this.isAdmin(true)
          } else if (tokenResult.claims.user) {
            this.$router.push('/')
            this.isAdmin(false)
          } else {
            this.$router.push('/')
            this.isAdmin(false)
          }
        })
      }
    })
  },
  methods: {
    ...mapActions({
      logOut: 'auth/logOut',
      isAdmin: 'auth/isAdmin',
    }),
    navigate(route) {
      if (this.isLoggedIn) {
        this.$router.push(route)
      } else {
        return (this.loginDialog = true)
      }
    },
    async terminate() {
      this.logOut()
      await this.$fire.auth.signOut()
      await this.$router.push('/')
    },
    resetDialog() {
      this.loginDialog = false
    },
  },
}
</script>
