<template>
  <v-app-bar color="transparent" dark height="120" flat app>
    <nuxt-link
      to="/"
      src="
        https://www.nasa.gov/sites/all/themes/custom/nasatwo/images/nasa-logo.svg
      "
      tag="img"
      height="100px"
      contain
      position="center"
    />
    <v-spacer></v-spacer>
    <span v-if="isLoggedIn" class="mr-4">
      <span
        class="role"
        v-if="admin && isLoggedIn"
        @click="$router.push('/admin')"
        >Admin</span
      >
      <span class="role" v-else-if="!admin && isLoggedIn">User</span>
      Howdy
      <span class="font-weight-bold">{{ account.email }}</span></span
    >
    <AccountMenu :is-logged-in="isLoggedIn" />
  </v-app-bar>
</template>

<script>
import AccountMenu from '~/components/UI/AccountMenu'
export default {
  name: 'NavBar',
  components: { AccountMenu },
  props: {
    isLoggedIn: {
      type: Boolean,
      required: true,
      default: false,
    },
    account: {
      type: Object,
      required: false,
      default: () => {},
    },
    admin: {
      type: Boolean,
      required: false,
      default: false,
    },
  },
}
</script>

<style scoped lang="scss">
.role {
  background: #00a826;
  color: #fff;
  padding: 5px 20px;
  border-radius: 15px;
  min-width: 50px;
  text-align: center;
}
</style>
