<template>
  <div
    id="app"
    data-app
  >
    <v-row justify="center">
      <v-dialog
        v-model="dialog"
        persistent
        max-width="360"
        max-height="180"
      >
        <v-card>
          <v-card-text>
            <v-row>
              <v-col
                cols="12"
              >
                <v-text-field
                  v-model="userName"
                  label="Username"
                  required
                />
              </v-col>
            </v-row>
          </v-card-text>
          <v-card-actions>
            <v-btn
              color="blue darken-1"
              text
              @click="saveUserName"
            >
              Save
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </v-row>
  </div>
</template>

<script>
export default {
  data () {
    return {
      dialog: true,
      userName: ''
    }
  },
  created () {
    if (process.browser) {
      const user = localStorage.getItem('userName')
      if (user) {
        this.$store.commit('setUsername', user)
        this.dialog = false
      }
    }
  },
  methods: {
    saveUserName () {
      localStorage.setItem('userName', this.userName)
      this.dialog = false
      this.$store.commit('setUsername', this.userName)
    }
  }
}

</script>
