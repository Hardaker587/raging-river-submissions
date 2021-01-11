<template>
  <v-dialog v-model="enabledLightBox" fullscreen>
    <v-card>
      <v-card-title class="headline">
        Gallery
        <v-spacer></v-spacer>
        <v-icon @click="$nuxt.$emit('close-lightbox')">mdi-close</v-icon>
      </v-card-title>
      <div class="pa-4">
        <v-carousel
          v-model="carouselPosition"
          hide-delimiters
          class="rounded-xl"
          height="100%"
        >
          <v-carousel-item
            v-for="(item, i) in previews"
            :key="i"
            reverse-transition="fade-transition"
            transition="fade-transition"
          >
            <media
              :media-type="item.data[0].media_type"
              :media="item"
              :comments="returnCommentForId(item.data[0].nasa_id)"
            />
          </v-carousel-item>
        </v-carousel>
      </div>
    </v-card>
  </v-dialog>
</template>

<script>
import Media from '~/components/Planets/media'
export default {
  name: 'LightBox',
  components: { Media },
  props: {
    enabledLightBox: { type: Boolean, required: true, default: false },
    previews: { type: Array, required: true, default: () => [] },
    position: { type: Number, required: false, default: 0 },
    comments: { type: [Object, Array], required: false, default: () => {} },
  },
  data() {
    return {
      carouselPosition: '',
    }
  },
  watch: {
    position(val) {
      this.carouselPosition = val
    },
  },
  methods: {
    returnCommentForId(mediaId) {
      return this.comments.filter((m) => m.key === mediaId)
    },
  },
}
</script>
<style scoped lang="scss">
.v-responsive.v-carousel__item {
  height: 100% !important;
}
</style>
