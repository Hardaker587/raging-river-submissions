export const state = () => ({
  list: [],
  cocktail: Object,
  categories:
  [

    'Ordinary Drink',

    'Cocktail',

    'Milk OR Float OR Shake',

    'OtherORUnknown',

    'Cocoa',

    'Shot',

    'Coffee OR Tea',

    'Homemade Liqueur',

    'Punch OR Party Drink',

    'Beer',

    'Soft Drink OR Soda'

  ]

})

export const mutations = {
  set (state, cocktails) {
    state.list = cocktails
  },
  remove (state, { cocktail }) {
    state.list.splice(state.list.indexOf(cocktail), 1)
  },
  setCocktailOfDay (state, cocktail) { state.cocktail = cocktail }
}

export const actions = {
  async get ({ commit }) {
    await this.$axios.get('/search.php?f=a')
      .then((res) => {
        if (res.status === 200) {
          commit('set', res.data.drinks)
        }
      })
  },
  async set ({ commit }, cocktail) {
    await commit('set', cocktail)
  },
  async getCocktailofDay ({ commit }) {
    await this.$axios.get('/random.php')
      .then((res) => {
        if (res.status === 200) {
          commit('setCocktailOfDay', res.data.drinks[0])
        }
      })
  }
}

export const getters = {
  loadedCocktails (state) {
    return state.list
  },
  categories (state) {
    return state.categories
  }
}
