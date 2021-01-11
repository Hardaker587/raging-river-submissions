import { mapGetters } from 'vuex'
import Paginator from '@/components/paginator/index'

export default {
    data() {
        return {
            cityId: undefined,
            city: {},
            latitude: undefined,
            longitude: undefined,
            radius: undefined,
            categories: [],
            cuisines: [],
            restaurants: [],
            curPageIndex: 0,
            pageSize: 20,
            selectedCategory: -1,
            selectedCuisine: -1
        }
    },
    computed: {
        pageCount() {
            // Zomato can only return up to the first 100 restaurants.
            return this.restaurants ? Math.ceil(Math.min(100, this.restaurants.results_found) / this.pageSize) : 0;
        },
        ...mapGetters({
            isLoggedIn: 'hasValidJwt'
        })
    },
    watch: {
        isLoggedIn(newValue, oldValue) {
            this.refreshRestaurants();
        }
    },
    methods: {
        categoryChanged(e) {
            this.selectedCategory = e.target.value;
            this.curPageIndex = 0;
            this.refreshRestaurants();
        },
        cuisineChanged(e) {
            this.selectedCuisine = e.target.value;
            this.curPageIndex = 0;
            this.refreshRestaurants();
        },
        setFavourite(restaurantIndex) {
            if (!this.isLoggedIn) {
                this.$store.commit('showLogin');
            } else {
                let restaurant = this.restaurants.results[restaurantIndex];
                if (restaurant.isFavourite) {
                    restaurant.isFavourite = false;
                    this.$apiClient().delete(`Zomato/Favourite/${restaurant.id}`)
                        .then(() => {
                        });    
                } else {
                    restaurant.isFavourite = true;
                    this.$apiClient().post(`Zomato/Favourite`, restaurant)
                        .then(() => { 
                        });
                }
            }
        },
        refreshRestaurants() {
            let queryString = `?start=${this.curPageIndex * this.pageSize}&pageSize=${this.pageSize}`;
            if (this.cityId) queryString += `&cityId=${this.cityId}`;
            if (this.latitude && this.longitude) queryString += `&lat=${this.latitude}&lon=${this.longitude}`;
            if (this.radius) queryString += `&radius=${this.radius}`;
            if (this.selectedCategory) queryString += `&categoryId=${this.selectedCategory}`;
            if (this.selectedCuisine) queryString += `&cuisineId=${this.selectedCuisine}`;

            this.$apiClient().get(`Zomato/Restaurants${queryString}`)
                .then(response => {
                    this.restaurants = response.data;
                });
        }
    },
    mounted() {
        this.cityId = this.$nuxt.context.query.cityId;
        this.latitude = this.$nuxt.context.query.latitude;
        this.longitude = this.$nuxt.context.query.longitude;
        this.radius = this.$nuxt.context.query.radius;

        if (this.cityId) {
            this.$apiClient().get(`Zomato/City/${this.cityId}`)
                .then(response => {
                    this.city = response.data;
                });
        }

        this.$apiClient().get('Zomato/Categories')
            .then(response => {
                this.categories = response.data;
            });

        let cuisineQuery = this.cityId ? `cityId=${this.cityId}` : `lat=${this.latitude}&lon=${this.longitude}`;
        this.$apiClient().get(`Zomato/Cuisines?${cuisineQuery}`)
            .then(response => {
                this.cuisines = response.data;
            });

        this.refreshRestaurants();
    },
    created() {
        this.$nuxt.$on('page-changed', (e) => {
          if (this.curPageIndex !== e) {
            this.curPageIndex = e;
            this.refreshRestaurants();
          }
        });
    },
    beforeDestroy() {
        this.$nuxt.$off('page-changed');
    },
    components: {
        Paginator
    }
}