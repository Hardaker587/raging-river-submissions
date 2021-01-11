<template>
  <div id="app">
    <v-app id="inspire">
      <v-card
        class="mx-auto"
        width="400px"
      >
        <PublicListUserDetailsDisplay
          :leader-board-users="leaderBoardUsers"
        />
      </v-card>
    </v-app>
  </div>
</template>

<script>
import Vuetify from 'vuetify'
import Vue from 'vue'

Vue.use(Vuetify)

export default {
  data () {
    return {
      leaderBoardUsers: []
    }
  },
  async fetch () {
    await this.fetchLeaderboardData()
  },
  computed: {
    userName () {
      return this.$store.state.userName
    }
  },
  methods: {

    async fetchLeaderboardData () {
      const leaderboardArr = await this.$axios.$get(
        '/api/GetTopScores.php'
      )
      this.leaderBoardUsers = (leaderboardArr)
    }
  }
}

</script>
