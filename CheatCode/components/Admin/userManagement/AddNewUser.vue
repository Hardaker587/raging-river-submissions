<template>
  <v-form class="pa-4">
    <v-text-field
      v-model="email"
      label="Email Address"
      dense
      rounded
      outlined
    ></v-text-field>
    <v-text-field
      v-model="password"
      label="Password"
      dense
      type="password"
      rounded
      outlined
    ></v-text-field>
    <v-row>
      <v-col cols="12"
        ><v-btn dense block color="success" @click="createUser(email, password)"
          >Add new user</v-btn
        ></v-col
      >
    </v-row>
  </v-form>
</template>

<script>
export default {
  name: 'AddNewUser',
  data() {
    return {
      email: '',
      password: '',
    }
  },
  methods: {
    async createUser(email, password) {
      try {
        await this.$fire.auth.createUserWithEmailAndPassword(
          email.toString().trim(),
          password.toString().trim()
        )
      } catch (e) {
        alert(e)
      }
    },
  },
}
</script>
