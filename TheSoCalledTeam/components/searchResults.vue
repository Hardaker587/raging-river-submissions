<template>
  <div>
    <v-row v-if="results && results.length">
      <v-col
        v-for="result in results"
        :key="result.strDrink"
        cols="4"
        sm="4"
        md="4"
      >
        <v-card>
          <v-img
            :src="result.strDrinkThumb"
            height="200px"
          />
          <v-card-title class="headline">
            {{ result.strDrink }}
          </v-card-title>
          <v-card-text>
            <b class="cocktail-category">{{ result.strCategory }}</b><br>
            <p>{{ result.strInstructions }}</p>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </div>
</template>

<script>
export default {
  name: 'SearchResults',
  props: {
    results: {
      type: Array,
      default: null
    }
  }
}
</script>

<style scoped>
.cocktail-category{
color: #e75500;
}
</style>
