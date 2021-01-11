<template>
  <div class="header">
    <v-container>
    <nuxt-link to="/" exact>
      Home
    </nuxt-link>
    <nuxt-link to="/cotd" exact>
      Cocktail Of The Day
    </nuxt-link>
    <nuxt-link v-if="$auth.loggedIn" to="/about">
      About
    </nuxt-link>
    <a v-if="$auth.loggedIn" @click="$auth.logout()">Sign Off</a>
    <a v-else @click="$auth.loginWith('auth0')">Sign In</a>
    </v-container>
  </div>
</template>

<style scoped>
.header {
  display: flex;
  margin-bottom: 20px;
}
a {
  margin-right: 20px;
  font-size: 14px;
  color: #999;
  text-decoration: none;
  text-transform: uppercase;
  padding-top: 2px;
  padding-bottom: 2px;
  border-top: 1px solid transparent;
  border-bottom: 1px solid transparent;
  transition: color .25s;
  font-weight: 400;
  line-height: normal;
  cursor: pointer;
}
a:hover {
  color: #333;
}
a.nuxt-link-active {
  color: #333;
  border-top: 1px solid #333;
  border-bottom: 1px solid #333;
  font-weight: 600;
}
.container {
  max-width: 1185px;
}
</style>
