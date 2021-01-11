<template>
  <v-footer app>
    <span>&copy; {{ new Date().getFullYear() }} Gavin Hardaker</span>
    <v-spacer></v-spacer>
    <!--    <v-dialog-->
    <!--      v-model="dialog"-->
    <!--      v-if="typeof backgroundInfo !== 'undefined'"-->
    <!--      width="500"-->
    <!--    >-->
    <!--      <template v-slot:activator="{ on, attrs }">-->
    <!--        <v-btn color="primary" text v-bind="attrs" v-on="on">-->
    <!--          About Background-->
    <!--        </v-btn>-->
    <!--      </template>-->

    <!--      <v-card>-->
    <!--        <v-card-title-->
    <!--          class="headline grey lighten-2"-->
    <!--          v-if="backgroundInfo.title !== null"-->
    <!--        >-->
    <!--          {{ backgroundInfo.title }}-->
    <!--        </v-card-title>-->

    <!--        <v-card-text>-->
    <!--          <v-img-->
    <!--            v-if="backgroundInfo.url !== null"-->
    <!--            :src="backgroundInfo.url"-->
    <!--            width="100%"-->
    <!--            height="auto"-->
    <!--            class="my-2"-->
    <!--          ></v-img>-->
    <!--          {{ backgroundInfo.explanation }}-->
    <!--        </v-card-text>-->

    <!--        <v-divider></v-divider>-->

    <!--        <v-card-actions>-->
    <!--          <v-spacer></v-spacer>-->
    <!--          <v-btn color="primary" text @click="dialog = false">Awesome!</v-btn>-->
    <!--        </v-card-actions>-->
    <!--      </v-card>-->
    <!--    </v-dialog>-->
  </v-footer>
</template>

<script>
export default {
  name: 'Footer',
  props: {
    backgroundInfo: { type: Object, required: false, default: () => {} },
  },
  data() {
    return {
      dialog: false,
    }
  },
}
</script>
