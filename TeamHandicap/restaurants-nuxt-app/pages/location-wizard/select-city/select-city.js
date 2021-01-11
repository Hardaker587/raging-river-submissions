import TileSelect from '@/components/tile-select/index'

export default {
    data() {
        return {
            countryId: undefined,
            stateId: undefined
        }
    },
    computed: {
        dataPath() {
            if (this.stateId) {
                return `Zomato/Cities?stateId=${this.stateId}`;
            } else if (this.countryId) {
                return `Zomato/Cities?countryId=${this.countryId}`;
            } else {
                return '';
            }
        }
    },
    components: {
        TileSelect
    },
    created() {
        this.stateId = this.$nuxt.context.query.stateId;
        this.countryId = this.$nuxt.context.query.countryId;
        this.$nuxt.$on('selected', (e) => {
            if (e.tag === 'city') {
                this.$router.push({ path: '/restaurants', query: { cityId: e.option.id }});
            }
        });
    },
    beforeDestroy() {
        this.$nuxt.$off('selected');
    }
}