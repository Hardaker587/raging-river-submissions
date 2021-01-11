<template>
  <v-container>
    <v-row align="center">
      <v-col :cols="$vuetify.breakpoint.smAndDown ? 12 : 4">
        <world
          v-if="displayPlanet"
          :name="id"
          :texture="returnTextureType(planet)"
          :height="250"
          :width="$vuetify.breakpoint.smAndDown ? 350 : 250"
        />
      </v-col>
      <v-col :cols="$vuetify.breakpoint.smAndDown ? 12 : 8">
        <div class="text-h4 white--text font-weight-bold">
          Welcome to {{ id }}
        </div>
        <div class="white--text">{{ planet.pageInformation }}</div>
      </v-col>
      <v-col cols="12">
        <observatory
          v-if="planetGallery.length !== 0 && !planet.isFiction"
          :images="planetGallery"
          :name="id"
          :comments="returnComments"
        />
      </v-col>
    </v-row>
    <v-row class="pa-0 mt-4">
      <div class="text-h5 white--text font-weight-bold mb-4">Explore more</div>
      <v-slide-group
        v-if="typeof returnPlanets !== 'undefined'"
        dark
        class="explore"
      >
        <v-slide-item v-for="(planetObj, index) in returnPlanets" :key="index">
          <Card :planet="planetObj" />
        </v-slide-item>
      </v-slide-group>
    </v-row>
  </v-container>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
import World from '~/components/Planets/world'
import Observatory from '~/components/Planets/observatory'
import Card from '~/components/UI/Card'
export default {
  name: 'Planet',
  components: { Card, Observatory, World },
  data() {
    return {
      id: this.$route.params.planet,
      displayPlanet: false,
      planet: [],
    }
  },
  beforeMount() {
    this.getPlanet(this.id)
    this.returnThisPlanet()
    this.$nuxt.$on('add-comment', (obj) => {
      this.addComment({ ...obj })
    })
    this.$nuxt.$on('fetch-comments', (mediaId) => {
      this.fetchComment(mediaId)
    })
  },
  destroyed() {
    this.dumpPlanet()
  },
  // eslint-disable-next-line vue/order-in-components
  computed: {
    ...mapGetters({
      planetGallery: 'planets/getPlanet',
      returnPlanets: 'planets/returnPlanetsFromDB',
      returnComments: 'planets/returnComments',
      authUser: 'auth/authUser',
    }),
  },
  methods: {
    ...mapActions({
      getPlanet: 'planets/fetchPlanet',
      dumpPlanet: 'planets/dumpPlanet',
      getPlanets: 'planets/fetchPlanetsFromDb',
      addComment: 'planets/writeComment',
      fetchComment: 'planets/fetchComment',
    }),
    async returnThisPlanet() {
      await this.getPlanets()
        .then(() => {
          for (let i = 0; i < this.returnPlanets.length; i++) {
            if (this.returnPlanets[i].link === this.id) {
              this.planet = this.returnPlanets[i]
            }
          }
        })
        .then(() => {
          this.displayPlanet = true
        })
    },
    returnTextureType(obj) {
      if (obj.isFiction === 'true') {
        return `/images/fictionalTextures/${obj.fictionalType}/${obj.texture}.png`
      } else {
        return `/images/textures/2k_${obj.link}.jpg`
      }
    },
  },
}
</script>
<style lang="scss" scoped>
.explore {
  ::v-deep .v-slide-group__next--disabled,
  ::v-deep .v-slide-group__prev--disabled {
    display: none;
  }
}
</style>
