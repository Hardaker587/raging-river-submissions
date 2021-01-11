<template>
  <v-row justify="center" align="center">
    <v-col cols="12" sm="8" md="7">
      <v-card>
        <v-card-title class="headline justify-center green-text">
          Register An Account
        </v-card-title>
        <v-card-text>
          <UserAuthForm
            :submitForm="registerUser"
            buttonText="Register"
            hasName
          />
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
    registerUser(registrationDetail) {
      firebase
        .auth()
        .createUserWithEmailAndPassword(
          registrationDetail.email,
          registrationDetail.password
        )
        .then((result) => {
          result.user
            .updateProfile({ displayName: registrationDetail.name })
            .then(() => {
              this.$store.dispatch("setUserDetail", result.user).then(() => {
                this.$router.push("/");
              });
            });
        })
        .catch((error) => {
          alert(error.message);
        });
    },
  },
};
</script>
