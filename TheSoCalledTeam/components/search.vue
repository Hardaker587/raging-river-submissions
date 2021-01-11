<template>
  <div>
    <v-form>
      <v-container>
        <v-row>
          <v-col cols="12" md="4">
            <v-select
              :items="categoryList"
              label="Category"
              item-text="strCategory"
              item-value="strCategory"
              required
              @change="selectCategory"
            />
          </v-col>
        </v-row>
      </v-container>
    </v-form>
  </div>
</template>

<script>
export default {
  name: 'CocktailSearch',
  data () {
    return {
      items: []
    }
  },
  computed: {
    categoryList () {
      return this.$store.getters.categories
    }
  },
  methods: {
    selectCategory (category) {
      // eslint-disable-next-line no-console
      console.log('selected cat', category)
    }
  }
}
</script>

<style scoped>
</style>
