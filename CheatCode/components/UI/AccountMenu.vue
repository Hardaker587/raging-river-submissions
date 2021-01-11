<template>
  <div class="text-center">
    <v-menu
      v-model="menu"
      :close-on-content-click="false"
      :nudge-width="200"
      offset-x
    >
      <template v-slot:activator="{ on, attrs }">
        <v-btn dark v-bind="attrs" v-on="on" icon color="white">
          <v-icon large>mdi-account-outline</v-icon>
        </v-btn>
      </template>

      <v-card v-if="!isLoggedIn">
        <v-list>
          <v-list-item>
            <v-list-item-content>
              <v-list-item-title>Log in / Register</v-list-item-title>
              <v-list-item-subtitle
                >Log in to your existing account or register a new
                one</v-list-item-subtitle
              >
            </v-list-item-content>
          </v-list-item>
        </v-list>
        <v-divider></v-divider>
        <AuthForm @close="closeMenu" />
      </v-card>
      <v-card v-else class="pa-4">
        <v-list>
          <v-list-item>
            <v-list-item-content>
              <v-list-item-title>Account</v-list-item-title>
              <v-list-item-subtitle
                >You are already Logged in</v-list-item-subtitle
              >
            </v-list-item-content>
          </v-list-item>
        </v-list>
        <v-divider></v-divider>
        <v-btn
          block
          color="red"
          dark
          @click="
            closeMenu()
            $nuxt.$emit('log-out')
          "
          >Log out</v-btn
        >
      </v-card>
    </v-menu>
  </div>
</template>

<script>
import AuthForm from '~/components/UI/AuthForm'
export default {
  name: 'AccountMenu',
  components: { AuthForm },
  props: {
    isLoggedIn: { type: Boolean, required: true, default: false },
  },
  data: () => ({
    fav: true,
    menu: false,
    message: false,
    hints: true,
  }),
  methods: {
    closeMenu() {
      this.menu = !this.menu
    },
  },
}
</script>
