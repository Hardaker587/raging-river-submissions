<template>
  <div>
    <v-app-bar
      color="deep-purple"
      dark
    >
      <v-app-bar-nav-icon @click="drawer = true" />
      <v-toolbar-title>NPM Run ᕕ(⍤~⍤)ᕗ</v-toolbar-title>
    </v-app-bar>
    <v-navigation-drawer
      v-model="drawer"
      absolute
      temporary
    >
      <v-list
        nav
        dense
      >
        <v-list-item-group
          v-model="group"
          active-class="deep-purple--text text--accent-4"
        >
          <v-list-item to="/" @click="drawer = false">
            <v-list-item-icon>
              <v-icon>mdi-home</v-icon>
            </v-list-item-icon>
            <v-list-item-action>
              <v-list-item-title>
                Home
              </v-list-item-title>
            </v-list-item-action>
          </v-list-item>
          <v-list-item to="/Leaderboard" @click="drawer = false">
            <v-list-item-icon>
              <v-icon>mdi-account</v-icon>
            </v-list-item-icon>
            <v-list-item-title>
              LeaderBoard
            </v-list-item-title>
          </v-list-item>
          <v-list-item @click="logout">
            <v-list-item-icon>
              <v-icon>mdi-account</v-icon>
            </v-list-item-icon>
            <v-list-item-title>
              Log Out
            </v-list-item-title>
          </v-list-item>
        </v-list-item-group>
      </v-list>
    </v-navigation-drawer>
  </div>
</template>

<script>
export default {
  name: 'HeaderHamburgerMenu',
  data: () => ({
    drawer: false,
    group: null
  }),
  methods: {
    logout () {
      localStorage.removeItem('userName')
      this.$router.go('/')
    }
  }
}
</script>
