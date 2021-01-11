<template>
  <v-container>
    <v-row>
      <v-col cols="12">
        <div class="text-h5 white--text font-weight-bold">
          Check out the latest on {{ name }}book
        </div>
      </v-col>
      <v-col
        v-for="(image, index) in images.items"
        :key="index"
        :cols="$vuetify.breakpoint.smAndDown ? 6 : 3"
      >
        <div v-if="typeof image.links !== 'undefined'" class="mediaHolder">
          <v-img
            max-height="250"
            aspect-ratio="1"
            :src="image.links[0].href"
            class="rounded-xl elevation-12"
            @click="
              lightBox = !lightBox
              position = index
            "
          ></v-img>
          <v-icon class="mediaType" dark>{{
            image.data[0].media_type === 'video' ? 'mdi-video' : 'mdi-image'
          }}</v-icon>
        </div>
      </v-col>
    </v-row>
    <light-box
      :enabled-light-box="lightBox"
      :previews="images.items"
      :position="position"
      :comments="comments"
    />
  </v-container>
</template>

<script>
import LightBox from '~/components/Planets/lightBox'
export default {
  name: 'Observatory',
  components: { LightBox },
  props: {
    name: { type: String, required: false, default: '' },
    images: { type: Object, required: false, default: () => {} },
    comments: { type: [Object, Array], required: false, default: () => {} },
  },
  data() {
    return {
      lightBox: false,
      position: 0,
    }
  },
  created() {
    this.$nuxt.$on('close-lightbox', () => {
      return (this.lightBox = !this.lightBox)
    })
  },
}
</script>

<style scoped lang="scss">
.mediaHolder {
  position: relative;
}
.mediaType {
  position: absolute;
  bottom: 10px;
  left: 10px;
}
</style>
