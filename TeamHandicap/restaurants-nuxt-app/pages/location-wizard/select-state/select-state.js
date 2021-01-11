import TileSelect from '@/components/tile-select/index'

export default {
    data() {
        return {
            countryId: undefined,
        }
    },
    components: {
        TileSelect
    },
    created() {
        this.countryId = this.$nuxt.context.query.countryId;
        this.$nuxt.$on('selected', (e) => {
            if (e.tag === 'state') {
                this.$router.push({ path: '/location-wizard/select-city', query: { stateId: this.stateId = e.option.id }});
            }
        });
    },
    mounted() {
    },
    beforeDestroy() {
        this.$nuxt.$off('selected');
    }
}