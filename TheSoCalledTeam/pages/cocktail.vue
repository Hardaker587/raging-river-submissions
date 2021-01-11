<template>
  <div>
    <CocktailList
      v-if="$auth.loggedIn"
      :cocktails="this.$store.state.list"
    />
  </div>
</template>

<script>
export default {
  async fetch () {
    await this.$store.dispatch('get')
  },
  computed: {
    loadedCocktails () {
      return this.$store.getters.loadedCocktails
    }
  }
}
</script>
