<template>
  <v-container>
    <CocktailOfTheDay
      :cocktail="this.$store.state.cocktail"
    />
  </v-container>
</template>

<script>
export default {
  async fetch () {
    await this.$store.dispatch('getCocktailofDay')
  }
}
</script>
