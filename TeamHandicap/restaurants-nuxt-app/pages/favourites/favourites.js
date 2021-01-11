export default {
    middleware: 'validate-jwt',
    data() {
        return {
            favourites: []
        }
    },
    methods: {
        deleteFavourite(favIndex) {
            const restaurantId = this.favourites[favIndex].restaurantId;
            this.favourites.splice(favIndex, 1);
            this.$apiClient().delete(`Zomato/Favourite/${restaurantId}`)
                .then(() => {
                });           
        }
    },
    mounted() {
        this.$apiClient().get('Zomato/Favourites')
            .then(response => {
                this.favourites = response.data;
            });
    }
}