<template>
  <div class="md-size-50 md-small-size-100">
    <v-form v-model="valid" @submit.prevent="submitForm(userDetail)">
      <v-text-field
        v-if="hasName"
        v-model="userDetail.name"
        label="Name"
        :rules="[required('name'), inputRange('name', 2, 200)]"
      />
      <v-text-field
        v-model="userDetail.email"
        label="Email"
        :rules="[required('email'), emailFormat()]"
      />
      <v-text-field
        v-model="userDetail.password"
        label="Password"
        :type="showPassword ? 'text' : 'password'"
        :append-icon="showPassword ? 'mdi-eye' : 'mdi-eye-off'"
        counter="true"
        :rules="[required('password'), minLength('password', 6)]"
        @click:append="showPassword = !showPassword"
      />

      <v-btn :disabled="!valid" type="submit">{{ buttonText }}</v-btn>
    </v-form>
  </div>
</template>

<script>
import validations from "@/utils/validations";
export default {
  props: {
    submitForm: {
      type: Function,
    },
    buttonText: {
      type: String,
      default: "Login",
    },
    hasName: {
      type: Boolean,
      default: false,
    },
  },
  data() {
    return {
      valid: false,
      showPassword: false,
      userDetail: {
        name: "",
        email: "",
        password: "",
      },
      ...validations,
    };
  },
};
</script>
