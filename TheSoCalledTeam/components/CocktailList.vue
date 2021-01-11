<template>
  <section>
    <CocktailPreview
      v-for="cocktail in cocktails"
      :key="cocktail.idDrink"
      :id-drink="cocktail.idDrink"
      :str-drink="cocktail.strDrink"
      :str-instructions="cocktail.strInstructions"
      :str-drink-thumb="cocktail.strDrinkThumb"
    />
  </section>
</template>

<script>
import CocktailPreview from '@/components/CocktailPreview'

export default {
  components: {
    CocktailPreview
  },
  props: {
    cocktails: {
      type: Array,
      default: null
    }
  }
}
</script>
