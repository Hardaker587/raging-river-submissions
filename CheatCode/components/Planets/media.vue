<template>
  <v-container>
    <v-row>
      <v-col cols="8" class="rounded-xl pa-0">
        <v-img
          v-if="mediaType === 'image'"
          :src="returnSource()"
          width="100%"
          height="auto"
        ></v-img>
        <div v-else class="video-container">
          <video controls class="video">
            <source type="video/mp4" :src="returnSource()" />
          </video>
        </div>
      </v-col>
      <v-col cols="4" class="py-0"
        ><v-card height="100%" dark
          ><v-card-title>Comments</v-card-title>
          <v-card-text>
            <v-list
              v-if="comments.length !== 0 || typeof comments !== 'undefined'"
            >
              <v-list-item
                v-for="(comment, index) in comments[0]"
                :key="index"
                :class="showHide(index)"
              >
                <div
                  v-if="index !== 'key'"
                  class="d-flex flex-column commentBox"
                >
                  <span
                    class="user text-caption font-weight-bold green--text"
                    >{{ comment.email }}</span
                  >
                  <span class="comment py-2">{{ comment.comment }}</span>
                  <span class="date text-caption font-weight-bold pb-2">{{
                    comment.created
                  }}</span>
                  <v-divider></v-divider>
                </div>
              </v-list-item>
            </v-list>
            <v-list v-else>
              <v-list-item>
                <v-alert outlined type="success" text>
                  There are no comments, be the first!</v-alert
                >
              </v-list-item>
            </v-list>
            <comments
              :media-id="media.data[0].nasa_id"
              :media-link="returnSource()"
              :media-type="mediaType"
            />
          </v-card-text> </v-card
      ></v-col>
    </v-row>
  </v-container>
</template>

<script>
import Comments from '~/components/Planets/comments'
export default {
  name: 'media',
  components: { Comments },
  props: {
    media: { type: Object, required: true, default: () => {} },
    mediaType: { type: String, required: true, default: 'image' },
    comments: { type: [Object, Array], required: false, default: () => {} },
    admin: { type: Boolean, required: false, default: false },
  },
  created() {
    this.$nuxt.$emit('fetch-comments', this.media.data[0].nasa_id)
  },
  methods: {
    returnSource() {
      if (this.mediaType === 'image') {
        return this.media.links[0].href
      } else {
        return `https://images-assets.nasa.gov/${this.mediaType}/${this.media.data[0].nasa_id}/${this.media.data[0].nasa_id}~orig.mp4`
      }
    },
    showHide(index) {
      let returnClass
      switch (index) {
        case 'key':
          returnClass = 'd-none'
          break
        case 'mediaLink':
          returnClass = 'd-none'
          break
        case 'mediaType':
          returnClass = 'd-none'
          break
        default:
          returnClass = 'd-flex d-column'
      }
      return returnClass
    },
  },
}
</script>
<style scoped lang="scss">
.video-container {
  position: relative;
  padding-bottom: 56.25%;
  height: 0;
  overflow: hidden;
  max-width: 100%;
}
.video-container video {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
}
.commentBox {
  width: 100%;
}
</style>
