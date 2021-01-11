export default {
    data() {
        return {
            clampedPageIndex: 0,
            pagesWindow: []
        }
    },
    props: {
        pageIndex: 0,
        pageCount: 0,
        windowSize: 0
    },
    watch: { 
        pageCount(newVal, oldVal) {
            this.calculatePageWindow();
        },
        pageIndex(newVal, oldVal) {
            this.calculatePageWindow();
        }
    },
    mounted() {
        this.calculatePageWindow();
    },
    methods: {
        onPageChanged(newPage) {
            this.$nuxt.$emit('page-changed', newPage);
        },
        calculatePageWindow() {
            this.clampedPageIndex = Math.max(0, Math.min(this.pageCount - 1, this.pageIndex));
            const realWindowSize = Math.min(this.windowSize, this.pageCount);
            const halfWindow = Math.floor(realWindowSize / 2);
            const firstPageOffset = Math.max(0, Math.min(this.pageCount - 1, this.clampedPageIndex + halfWindow) - (realWindowSize - 1));
            this.pagesWindow = new Array(realWindowSize).fill(firstPageOffset).map((x, i) => x + i);
        }
    }
}
