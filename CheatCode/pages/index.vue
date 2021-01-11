<template>
  <CardNavigation
    :column="$vuetify.breakpoint.smAndDown"
    :planets="returnPlanets"
  />
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
import CardNavigation from '~/components/UI/CardNavigation'
export default {
  components: { CardNavigation },
  computed: {
    ...mapGetters({
      returnPlanets: 'planets/returnPlanetsFromDB',
    }),
  },
  mounted() {
    this.fetchPlanets()
  },
  methods: {
    ...mapActions({
      fetchPlanets: 'planets/fetchPlanetsFromDb',
    }),
  },
}
</script>
