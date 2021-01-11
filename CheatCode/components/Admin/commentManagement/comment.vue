<template>
  <v-card>
    <v-container fluid>
      <v-row>
        <v-col cols="6">
          <v-img
            v-if="comment.mediaType === 'image'"
            :src="comment.mediaLink"
          ></v-img>
          <video controls v-else :src="comment.mediaLink"></video>
        </v-col>
        <v-col cols="6">
          <v-list v-if="comment.length !== 0 || typeof comment !== 'undefined'">
            <v-list-item
              v-for="(comments, index) in comment"
              :key="index"
              :class="showHide(index)"
            >
              <div v-if="index !== 'key'" class="d-flex flex-column commentBox">
                <span class="user text-caption font-weight-bold green--text"
                  >{{ comments.email }} wrote</span
                >
                <span class="comment py-2">{{ comments.comment }}</span>
                <span class="date text-caption font-weight-bold pb-2"
                  >on: {{ comments.created }}</span
                >
                <v-divider></v-divider>
              </div>
            </v-list-item>
          </v-list>
        </v-col>
      </v-row>
    </v-container>
  </v-card>
</template>

<script>
import Media from '~/components/Planets/media'
export default {
  name: 'comment',
  // eslint-disable-next-line vue/no-unused-components
  components: { Media },
  props: {
    comment: { type: Object, required: true, default: () => {} },
  },
  methods: {
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
