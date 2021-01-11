<template>
  <v-row justify="center" align="center">
    <v-col cols="12" sm="8" md="5">
      <v-card>
        <v-card-title class="headline justify-center green-text">
          Login
        </v-card-title>
        <v-card-text>
          <UserAuthForm :submitForm="authenticateUser" buttonText="Login" />
        </v-card-text>
      </v-card>
    </v-col>
  </v-row>
</template>

<script>
import firebase from "firebase/app";
import "firebase/auth";

export default {
  methods: {
    authenticateUser(loginDetail) {
      firebase
        .auth()
        .signInWithEmailAndPassword(loginDetail.email, loginDetail.password)
        .then((result) => {
          this.$store.dispatch("setUserDetail", result.user).then(() => {
            this.$router.push("/");
          });
        })
        .catch((error) => {
          alert(error.message);
        });
    },
  },
};
</script>
