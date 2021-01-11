<template>
  <div>
    <v-card>
          <v-img
            :src="cocktail.strDrinkThumb"
            height="400px"
          />
          <v-card-title class="headline">
            {{ cocktail.strDrink }}
          </v-card-title>
          <v-card-text>
            <b class="cocktail-category">Category: </b>{{ cocktail.strCategory }}<br>
            <p><b>Type:</b> {{ cocktail.strAlcoholic }}</p>
            <p><b>Glass:</b> {{ cocktail.strGlass }}</p>
            <p><b>Ingredients:</b> {{ ingredients }}</p>
            <p><b>Instructions:</b> {{ cocktail.strInstructions }}</p>
          </v-card-text>
        </v-card>
  </div>
</template>

<script>
export default {
  name: 'CocktailOfTheDay',
  props: {
    cocktail: {
      type: Object,
      default: null
    }
  },
  computed: {
    ingredients () {
      return this.cocktail.strIngredient1 + ', ' + this.cocktail.strIngredient2 + ', ' +
      this.cocktail.strIngredient3 + ', ' + this.cocktail.strIngredient4
    }
  }
}
</script>
<style scoped>

.post-thumbnail {
  width: 20%;
  height: 200px;
  background-position: center;
  background-size: cover;
}

</style>
