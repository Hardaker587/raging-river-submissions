<template>
  <div class="comments">
    <comment
      v-for="comment in comments"
      :key="comment.key"
      :comment="comment"
      :media-link="comment.mediaLink"
    />
  </div>
</template>

<script>
import Comment from '~/components/Admin/commentManagement/comment'
export default {
  name: 'comments',
  components: { Comment },
  props: {
    comments: { type: [Object, Array], required: true, default: () => {} },
  },
}
</script>
