<template>
  <div id="app">
    <UserNameDialog />
    <v-container>
      <v-row no-gutters>
        <v-col cols="12" :style="{ 'text-align': 'left' }">
          <strong>{{ this.userName }}</strong> | Score: {{ Score }}
        </v-col>
      </v-row>
    </v-container>
    <v-container id="card">
      <v-row no-gutters>
        <v-col cols="12" :style="{ 'text-align': 'left' }">
          <strong>
            Question {{ Score + 1 }}
          </strong>
          <br>
          <p>
            Based on the following image <b>AND</b> list of ingredients, which cocktail is this?
          </p>
        </v-col>
        <v-col cols="3" sm="3">
          <strong>Cocktail Image</strong>
          <div v-if="Drinks.length > 0 && Drinks[PrimaryDrink] !== undefined" id="drinkImg">
            <v-img
              :lazy-src="Drinks[PrimaryDrink].strDrinkThumb"
              :style="{ 'margin': '0px 45px' }"
              :src="Drinks[PrimaryDrink].strDrinkThumb"
            />
          </div>
        </v-col>
        <v-col cols="6" sm="6">
          <strong>Ingredients</strong>
          <div id="PossibleIngredientsList">
            <v-list-item-group v-if="Ingredients.length > 0" id="ingredientsElement">
              <v-list-item
                v-for="ingredient in Ingredients"
                :key="ingredient.idIngredient"
              >
                <Accordion
                  :title="ingredient.strIngredient"
                  :description="ingredient.strDescription"
                />
              </v-list-item>
            </v-list-item-group>
          </div>
        </v-col>
        <v-col cols="3" sm="3">
          <strong>Options</strong>
          <div>
            <v-list-item-group id="drinkButtons">
              <v-list-item
                v-for="drink in Drinks"
                :key="drink.idDrink"
                :style="{ 'text-align': 'center', 'display': 'inline-block' }"
              >
                <v-btn color="error" @click="ChosenDrink = drink.idDrink">
                  {{ drink.strDrink.trim() }}
                </v-btn>
              </v-list-item>
            </v-list-item-group>
          </div>
          <div id="footer-container" cols="12">
            <v-btn color="success" :class="{ greyOut: ChosenDrink === undefined }" @click="onClickCocktail()">
              Confirm
            </v-btn>
          </div>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script>
import Vuetify from 'vuetify'
import Vue from 'vue'
import UserNameDialog from '~/components/UserNameDialog.vue'

Vue.use(Vuetify)

export default {
  components: { UserNameDialog },
  data () {
    return {
      Drinks: [],
      Ingredients: [],
      PrimaryDrink: Number,
      Score: 0,
      ChosenDrink: undefined
    }
  },
  async fetch () {
    this.clearInMemoryData()
    await this.fetchRandomDrinks(5, 2)
    this.PrimaryDrink = this.getRandomNumber(0, 4)
    await this.assignIngredients()
  },
  computed: {
    userName () {
      return this.$store.state.userName
    }
  },
  methods: {
    clearInMemoryData () {
      if (this.Drinks.length > 0) {
        this.Drinks.length = 0
      }
      if (this.Ingredients.length > 0) {
        this.Ingredients.length = 0
      }
    },

    /* Randomize array in-place using Durstenfeld shuffle algorithm
        CREDIT: https://stackoverflow.com/a/12646864
        ALGORITHM: https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle#The_modern_algorithm */
    shuffleArray (array) {
      for (let i = array.length - 1; i > 0; i--) {
        const j = Math.floor(Math.random() * (i + 1));
        [array[i], array[j]] = [array[j], array[i]]
      }
    },

    async fetchRandomDrinks (n, rdmN) {
      if (rdmN < n) {
        for (let i = 0; i < rdmN; i++) {
          const drinkArrRdmGenerated = await this.$axios.$get('/data/api/json/v1/1/random.php')
          const rdmGeneratedDrink = [drinkArrRdmGenerated.drinks[0]][0]
          const apiDataCall = await this.$axios.$get('api//RandomName.php?amount=' + rdmN.toString())
          rdmGeneratedDrink.strDrink = [apiDataCall[0]][0]
          this.Drinks.push(rdmGeneratedDrink)
        }
      } else {
        console.log('random number of drinks should be less than the total number of potential drinks')
      }
      for (let i = rdmN; i < n; i++) {
        const drinkArr = await this.$axios.$get('/data/api/json/v1/1/random.php')
        const newDrink = [drinkArr.drinks[0]][0]
        this.Drinks.push(newDrink)
      }
      this.shuffleArray(this.Drinks)
    },

    async assignIngredients () {
      const drink = this.Drinks[this.PrimaryDrink]

      // eslint-disable-next-line prefer-const
      let ingredientString = []

      for (let x = 0; x < 15; x++) {
        const el = drink['strIngredient' + x.toString()]
        if (el) {
          ingredientString[x] = el
        }
      }

      for (let i = 0; i < ingredientString.length; i++) {
        const element = ingredientString[i]
        if (element) {
          const ingredientArr = await this.$axios.$get((
            encodeURI('/data/api/json/v1/1/search.php?i=' + element)
          ))
          const newIngredient = [ingredientArr.ingredients[0]][0]
          this.Ingredients.push(newIngredient)
        }
      }
    },

    getRandomNumber (min, max) {
      min = Math.ceil(min)
      max = Math.floor(max)
      return Math.floor(Math.random() * (max - min + 1)) + min
    },

    async onClickCocktail () {
      this.$toast.clear()
      if (this.ChosenDrink === this.Drinks[this.PrimaryDrink].idDrink) {
        this.Score++
        this.$fetch()
        this.$toast.success('Correct, 1 point added!').goAway(3000)
      } else {
        if (this.Score > 0) {
          await this.$axios.$get(
            '/api/AddScore.php?username=' + this.userName + '&score=' + this.Score.toString()
          )
        }
        this.$toast.error('Game Over! Final Score: ' + this.Score).goAway(5000)
        this.Score = 0
        this.$fetch()
      }
    }
  }
}
</script>

<style>
#footer-container > .greyOut{
  background-color: grey !important;
  color: white !important;
  pointer-events: none;
}
#footer-container {
  text-align: center;
  margin-top: 30px;
}
.container {
  margin-top: 40px;
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
}
#card {
  border: solid 1px;
  border-radius: 5px;
  -webkit-box-shadow: 10px 10px 5px 0px rgba(0,0,0,0.75);
  -moz-box-shadow: 10px 10px 5px 0px rgba(0,0,0,0.75);
  box-shadow: 10px 10px 5px 0px rgba(0,0,0,0.75);
  background-color: whitesmoke;
  padding:40px;
}
</style>
