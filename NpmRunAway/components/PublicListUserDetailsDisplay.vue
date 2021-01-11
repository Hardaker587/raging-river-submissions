<template>
  <div>
    <v-list dense>
      <v-subheader>Leaderboard</v-subheader>
      <v-list-item-group
        color="primary"
      >
        <v-list-item
          v-for="(item, index) in leaderBoardUsers"
          :key="item.userName"
        >
          <v-list-item-content>
            <v-list-item-title v-text="index + 1" />
          </v-list-item-content>
          <v-list-item-icon>
            <v-icon>
              mdi-account
            </v-icon>
          </v-list-item-icon>
          <v-list-item-content>
            <v-list-item-title v-text="item.username" />
          </v-list-item-content>
          <v-list-item-content>
            <v-list-item-title v-text="item.score" />
          </v-list-item-content>
        </v-list-item>
      </v-list-item-group>
    </v-list>
  </div>
</template>

<script>
export default {
  name: 'PublicListUserDetailsDisplay',
  props: [
    'leaderBoardUsers'],
  metaInfo () {
    return {
      leaderBoardUsers: this.leaderBoardUsers,
      meta: [
      ]
    }
  }
}
</script>
