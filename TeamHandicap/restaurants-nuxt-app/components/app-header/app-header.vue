<template>
    <header class="header">
      <nuxt-link to="/">
        <h1 class="title">
          Raging Restaurants
        </h1>
      </nuxt-link>

      <div v-if="isLoggedIn" class="nav-btn-wrap float-right">
          <button type="button" class="btn link" @click="logOut">
            Log out
          </button>
          <JwtImg class="float-right" :imgSrc="avatarImgPath" placeholderImgName="avatar-placeholder.jpg"
            imgClass="avatar-img" :editable="true" uploadUrl="accounts/avatar" />
          <nuxt-link to="/favourites">
            <img class="fav-img mr-15px my-5px float-right" src="@/assets/white-heart.png" />
          </nuxt-link>
      </div>
      <div v-else class="nav-btn-wrap float-right">
        <button type="button" class="btn mr-5px" @click="showLogin">
          Log in
        </button>
        <button type="button" class="btn" @click="showRegister">
          Register
        </button>
      </div>
    </header>
</template>

<script>
import { mapGetters } from 'vuex'
import JwtImg from '@/components/jwt-img/index'

export default {
  name: 'AppFooter',
  computed: {
    avatarImgPath() {
      return this.$store.getters.getAvatarImgId ? `files/${this.$store.getters.getAvatarImgId}` : '';
    },
    ...mapGetters({
        isLoggedIn: 'hasValidJwt'
    })
  },
  methods: {
    showLogin: function() {
      this.$store.commit('showLogin');
    },
    showRegister: function() {
      this.$store.commit('showRegister');
    },
    logOut: function() {
      this.$store.commit('clearJwt');
      this.$router.push('/');
    }
  },
  components: {
    JwtImg
  }
}
</script>

<style lang="scss" rel="stylesheet/scss">
@import './app-header.global.scss';
</style>

<style scoped lang="scss" rel="stylesheet/scss">
@import './app-header.scss';
</style>