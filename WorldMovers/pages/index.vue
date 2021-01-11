<template>
  <v-row justify="center" align="center">
    <v-col cols="12" sm="8" md="6">
      <div class="text-center">
        <logo />
        <vuetify-logo />
      </div>
      <v-card>
        <v-card-title class="headline">
          Welcome to the World Movers App
        </v-card-title>
        <v-card-text>
          <p>
            In much of the world, 2020 started off like any other year. January
            1 provided a reason to celebrate and look forward to good things.
            You don’t need to be a historian to know the rest of the story. The
            COVID-19 pandemic, coupled with social and political unrest, made
            2020 a memorable year – mostly for the wrong reasons.
          </p>
        </v-card-text>
        <v-card-actions>
          <v-spacer />
          <v-btn color="primary" nuxt to="/sport"> Continue </v-btn>
        </v-card-actions>
      </v-card>
    </v-col>
  </v-row>
</template>

<script>
import Logo from "~/components/Logo.vue";
import VuetifyLogo from "~/components/VuetifyLogo.vue";

export default {
  components: {
    Logo,
    VuetifyLogo,
  },
};
</script>
