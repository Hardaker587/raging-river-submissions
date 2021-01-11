<template>
  <v-form class="pa-4">
    <v-text-field
      label="Email Address"
      v-model="email"
      dense
      rounded
      outlined
    ></v-text-field>
    <v-text-field
      label="Password"
      v-model="password"
      dense
      type="password"
      rounded
      outlined
    ></v-text-field>
    <v-row>
      <v-col cols="6"
        ><v-btn dense block color="success" @click="createUser"
          >Register</v-btn
        ></v-col
      >
      <v-col cols="6"
        ><v-btn dense block color="primary" @click="signInUser"
          >Log in</v-btn
        ></v-col
      >
    </v-row>
  </v-form>
</template>

<script>
export default {
  name: 'AuthForm',
  data() {
    return {
      email: '',
      password: '',
    }
  },
  methods: {
    async createUser() {
      try {
        await this.$fire.auth
          .createUserWithEmailAndPassword(this.email, this.password)
          .then(() => {
            this.$emit('close')
            this.$nuxt.$emit('closeDialog')
          })
      } catch (e) {
        alert(e)
      }
    },
    async signInUser() {
      try {
        await this.$fire.auth
          .signInWithEmailAndPassword(this.email, this.password)
          .then(() => {
            this.$emit('close')
            this.$nuxt.$emit('closeDialog')
          })
          .then(
            this.$notifications.showMessage({
              content: 'Welcome back',
              color: 'success',
            })
          )
      } catch (e) {
        alert(e)
      }
    },
    async addAdmin(email, password) {
      const admin = {
        role: {
          admin: true,
        },
      }
      await this.$fire.auth
        .createUserWithEmailAndPassword(
          this.email.toString().trim(),
          this.password.toString().trim()
        )
        .then((response) => {
          if (response) {
            const setAdmin = this.$fire.functions.httpsCallable('setAdmin')
            const data = { uid: response.user.uid, role: admin.role }
            setAdmin(data)
          }
        })
    },
  },
}
</script>
