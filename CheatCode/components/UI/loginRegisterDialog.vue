<template>
  <v-dialog
    v-model="display"
    class="loginModal pa-2"
    @click:outside="$nuxt.$emit('hideModal')"
  >
    <v-card>
      <v-card-title>Please log in or register to continue</v-card-title>
      <auth-form />
    </v-card>
  </v-dialog>
</template>

<script>
import AuthForm from '~/components/UI/AuthForm'
export default {
  name: 'loginRegisterDialog',
  components: { AuthForm },
  props: {
    showForm: { type: Boolean, default: false },
  },
  data() {
    return {
      display: '',
    }
  },
  watch: {
    showForm(val) {
      this.display = val
    },
  },
}
</script>
<style scoped lang="scss">
.v-dialog__content {
  .v-dialog--active {
    background: white !important;
  }
}
</style>
