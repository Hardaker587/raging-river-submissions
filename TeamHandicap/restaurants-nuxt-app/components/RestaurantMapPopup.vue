
<template>
  <l-popup>
    <v-container>
      <v-row>
        <v-col cols="6" class="restaurant-name">{{ restaurant.name }}</v-col>
      </v-row>
      <v-row>
        <v-col cols="6">{{ restaurant.cuisines }}</v-col>
      </v-row>
    </v-container>
  </l-popup>
</template>
  

<script>
export default {
  name: "RestaurantMapPopup",
  props: ["restaurant"],
  data() {
    return {};
  },
  methods: {},
  created() {},
  computed: {},
};
</script>

<style scoped>
  @import "leaflet/dist/leaflet.css";

  .restaurant-name {
    font-weight: bold;
  }
</style>