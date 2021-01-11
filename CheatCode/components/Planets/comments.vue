<template>
  <v-container>
    <v-row>
      <v-col cols="12">
        <v-textarea
          v-model="comment"
          label="Comment"
          rounded
          outlined
          dense
        ></v-textarea>
        <v-btn :disabled="!comment" block color="#00a826" @click="commented"
          >Submit Comment</v-btn
        >
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import { mapActions } from 'vuex'
export default {
  name: 'Comments',
  props: {
    mediaId: {
      type: String,
      required: true,
      default: '',
    },
    mediaType: {
      type: String,
      required: true,
      default: '',
    },
    mediaLink: {
      type: String,
      required: true,
      default: '',
    },
  },
  data() {
    return {
      comment: '',
    }
  },
  methods: {
    ...mapActions({
      addComment: 'planets/writeComment',
      fetchComment: 'planets/fetchComment',
    }),
    async commented() {
      await this.addComment({
        mediaId: this.mediaId,
        comment: this.comment,
        mediaType: this.mediaType,
        mediaLink: this.mediaLink,
      })
        .then(() => {
          this.fetchComment(this.mediaId)
        })
        .then(() => {
          this.comment = ''
        })
    },
  },
}
</script>
