import TileSelect from '@/components/tile-select/index'

export default {
    components: {
        TileSelect
    },
    created() {
        this.$nuxt.$on('selected', (e) => {
            if (e.tag === 'country') {
                if (e.option.hasStates) {
                    this.$router.push({ path: '/location-wizard/select-state', query: { countryId: e.option.id }});
                } else {
                    this.$router.push({ path: '/location-wizard/select-city', query: { countryId: e.option.id }});
                }
            }
        });
    },
    beforeDestroy() {
        this.$nuxt.$off('selected');
    }
}