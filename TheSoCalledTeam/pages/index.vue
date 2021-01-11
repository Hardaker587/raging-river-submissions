<template>
  <div>
    <p v-if="!($auth.loggedIn)">
      <v-container>
      You're not authenticated yet. Maybe you want to <a @click="$auth.login()">sign in</a> and see what happens?
      </v-container>
    </p>
    <div v-if="$auth.loggedIn" class="search-section">
      <v-container>
        <v-row justify="center" align="center">
          <v-col cols="12" sm="12" md="12">
            <img
              class="logo"
              :src="require(`~/assets/img/cocktail.png`)"
            >
            <h2 class="title lh-100">
              Where's my drink?
            </h2>
            <v-spacer />
          </v-col>
        </v-row>
      </v-container>
      <v-container>
        <h1 class="headline">
          Filter Drinks
        </h1>
        <CocktailSearch />
      </v-container>
    </div>
    <v-container v-if="$auth.loggedIn">
      <h1 class="headline">
        Our Favourites
      </h1>
      <br>
      <SearchResults :results="sublist" />
    </v-container>
  </div>
</template>

<script>
import CocktailSearch from '@/components/search'
import SearchResults from '@/components/searchResults'

export default {
  components: {
    CocktailSearch,
    SearchResults
  },
  data () {
    return {
      cocktails: []
    }
  },
  async fetch () {
    await this.$store.dispatch('get')
  },
  computed: {
    sublist () {
      return this.$store.state.list.slice(0, 9)
    }
  }
}

</script>

<style scoped>
.container {
  max-width: 1185px;
}
.search-section{
  padding: 60px 0;
  background-image: url('../assets/img/back.jpg');
  background-size: cover;
  background-position: center;
  background-color: #fcfdff;
  border-bottom: solid 1px #ddd;
}
.logo{
  height: 90px;
  float: left;
}

.lh-100{
  line-height: 100px;
}
</style>
