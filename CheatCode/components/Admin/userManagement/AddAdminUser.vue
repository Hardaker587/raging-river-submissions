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
        ><v-btn dense block color="success" @click="addAdmin(email, password)"
          >Add new admin user</v-btn
        ></v-col
      >
    </v-row>
  </v-form>
</template>

<script>
export default {
  name: 'AddAdminUser',
  data() {
    return {
      email: '',
      password: '',
    }
  },
  methods: {
    async addAdmin(email, password) {
      const admin = {
        role: {
          admin: true,
        },
      }
      await this.$fire.auth
        .createUserWithEmailAndPassword(
          email.toString().trim(),
          password.toString().trim()
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
