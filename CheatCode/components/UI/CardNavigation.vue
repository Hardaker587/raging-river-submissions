<template>
  <v-container fluid class="pa-0">
    <v-row dense>
      <v-col
        v-for="(card, index) in planets"
        :key="index"
        :cols="column ? 12 : 4"
        :class="column ? 'pb-2' : 'pa-2'"
      >
        <v-sheet
          rounded
          height="200px"
          width="100%"
          elevation="8"
          class="cardHover d-flex align-center pa-4"
          @click="$nuxt.$emit('navigate', `/planets/${card.link}`)"
        >
          <div v-if="card.isFiction" class="fictionalIndicator">Fictional</div>
          <Planet
            v-if="card.isPlanet"
            :name="card.name.toLowerCase()"
            :texture="returnTextureType(card, card.texture)"
            :card="true"
            :width="100"
            :height="100"
            :is-fiction="card.isFiction === 'true'"
          />
          <div class="informationBox d-flex flex-column">
            <div class="text-h5 font-weight-bold">{{ card.name }}</div>
            <div class="text-paragraph">
              {{ card.additionalInformation }}
            </div>
          </div>
        </v-sheet>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import Planet from '~/components/Planets/world'
export default {
  name: 'CardNavigation',
  components: { Planet },
  props: {
    column: { type: Boolean, required: true, default: false },
    planets: { type: [Object, Array], required: true, default: () => [] },
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

<style scoped lang="scss">
.cardHover {
  position: relative;
  &:hover {
    filter: opacity(50%);
    transition: ease all 0.3s;
  }
  .fictionalIndicator {
    position: absolute;
    top: 10px;
    right: 10px;
    background: #00a826;
    color: #fff;
    padding: 5px 10px;
    font-size: 10px;
    border-radius: 15px;
    min-width: 50px;
  }
}
.text-paragraph {
  max-height: 80%;
  overflow: scroll;
}
</style>
