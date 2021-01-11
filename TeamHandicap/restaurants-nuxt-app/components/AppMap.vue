
<template>
  <div>
    <v-alert
      v-model="showLocationAlert"
      dense
      color="red"
      outlined
      type="error"
      dismissible
      >Unable to use your browser's location</v-alert
    >
    <div class="osm-map">
      <client-only>
        <l-map
          :zoom="13"
          :center="mapCenter"
        >
          <l-tile-layer
            url="http://{s}.tile.osm.org/{z}/{x}/{y}.png"
          ></l-tile-layer>
          <l-marker v-for="restaurant in restaurants" :key="restaurant.id" :lat-lng="[restaurant.location.latitude, restaurant.location.longitude]">
            <restaurant-map-popup :restaurant="restaurant" />
          </l-marker>
        </l-map>
      </client-only>
    </div>
  </div>
</template>
  

<script>
import RestaurantMapPopup from '@/components/RestaurantMapPopup'
export default {
  name: "AppMap",
  components: { 
    RestaurantMapPopup, 
  },
  data() {
    return {
      showLocationAlert: false,
      mapCenter: [-25.7305802,28.2451057],
      radius: 20
    };
  },
  methods: {
    updateMarkers(coordinates) {
      this.$store.commit("setCoordinates", coordinates);
      this.$openStreetMapClient().reverseGeocode(coordinates);
      let queryString = `?start=0&pageSize=500&cityId=0&lat=${coordinates.latitude}&lon=${coordinates.longitude}&radius=5000&categoryId=0&cuisineId=0`;
      this.$apiClient().get(`Zomato/Restaurants${queryString}`)
          .then(function(resp) {
              this.$store.commit("setRestaurants", resp.data.results);
          }.bind(this));      
    },
    success(position) {
      let coordinates = {
        latitude: position.coords.latitude,
        longitude: position.coords.longitude,
      };
      this.mapCenter = [coordinates.latitude, coordinates.longitude];
      this.updateMarkers(coordinates);
    },
    error() {
      this.showLocationAlert = true;
      const coordinates = {latitude:-25.7305802, longitude:28.2451057};
      this.updateMarkers(coordinates);
      setTimeout(
        function () {
          this.showLocationAlert = false;
        }.bind(this),
        5000
      );
    },
  },
  created() {
    if (process.browser) {
      if (!window.navigator.geolocation) {
        this.status = "Geolocation is not supported by your browser";
      } else {
        this.status = "Locating…";
        window.navigator.geolocation.getCurrentPosition(
          this.success,
          this.error
        );
      }
    }
  },
  computed: {
    coordinates() {
      return this.$store.getters.getCoordinates;
    },
    restaurants() {
      return this.$store.getters.getRestaurants;
    }
  },
};
</script>

<style scoped>
  @import "leaflet/dist/leaflet.css";

.osm-map {
  height: 85vh;
  width: 100vw;
}
</style>