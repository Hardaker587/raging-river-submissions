<template>
  <article>
    <div
      class="post-thumbnail"
      :style="{backgroundImage: 'url(' + strDrinkThumb + ')'}"
    />
    <div>
      <h4>Name : {{ strDrink }}</h4>
      <p>Instructions : {{ strInstructions }} </p>
    </div>
  </article>
</template>

<script>
export default {
  name: 'CocktailPreview',
  props: {
    idDrink: {
      type: String,
      default: ''
    },
    strDrink: {
      type: String,
      default: ''
    },
    strInstructions: {
      type: String,
      default: ''
    },
    strDrinkThumb: {
      type: String,
      default: ''
    }
  }
}
</script>
<style scoped>

.post-thumbnail {
  width: 10%;
  height: 100px;
  background-position: center;
  background-size: cover;
}

</style>
