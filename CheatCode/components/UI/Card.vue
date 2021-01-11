<template>
  <v-card
    rounded
    height="200px"
    width="200px"
    elevation="8"
    class="cardHover d-flex flex-column align-center pa-4 mr-4"
    @click="$nuxt.$emit('navigate', `/planets/${planet.link}`)"
  >
    <div v-if="planet.isFiction" class="fictionalIndicator">Fictional</div>
    <Planet
      v-if="planet.isPlanet"
      :name="planet.name.toLowerCase()"
      :texture="returnTextureType(planet, planet.texture)"
      :card="true"
      :width="100"
      :height="100"
      :is-fiction="planet.isFiction === 'true'"
    />
    <div class="informationBox d-flex flex-column">
      <div class="text-h5 font-weight-bold">{{ planet.name }}</div>
    </div>
  </v-card>
</template>

<script>
import Planet from '~/components/Planets/world'
export default {
  name: 'Card',
  components: { Planet },
  props: {
    planet: { type: Object, default: () => {} },
  },
  methods: {
    returnTextureType(obj, texture) {
      if (obj.isFiction === 'true') {
        return `/images/fictionalTextures/${obj.fictionalType}/${texture}.png`
      } else {
        return `/images/textures/2k_${obj.name.toLowerCase()}.jpg`
      }
    },
  },
}
</script>
