import { mapGetters } from 'vuex'

export default {
    data() {
        return {
            restaurant: undefined
        }
    },
    computed: {
        ...mapGetters({
            isLoggedIn: 'hasValidJwt'
        })
    },
    watch: {
        isLoggedIn(newValue, oldValue) {
            this.refreshRestaurant();
        }
    },
    methods: {
        setFavourite() {
            if (!this.isLoggedIn) {
                this.$store.commit('showLogin');
            } else {
                if (this.restaurant.isFavourite) {
                    this.restaurant.isFavourite = false;
                    this.$apiClient().delete(`Zomato/Favourite/${this.restaurant.id}`)
                        .then(() => {
                        });    
                } else {
                    this.restaurant.isFavourite = true;
                    this.$apiClient().post(`Zomato/Favourite`, this.restaurant)
                        .then(() => { 
                        });
                }
            }
        },
        refreshRestaurant() {
            const restaurantId = this.$route.params.id;
            this.$apiClient().get(`Zomato/Restaurant/${restaurantId}`)
                .then(response => {
                    this.restaurant = response.data;
                });
        }
    },
    mounted() {
        this.refreshRestaurant();
    }
}