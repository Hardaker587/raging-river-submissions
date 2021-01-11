export default {
    computed: {
        imgId: () => `jwt_img_${Math.floor(Math.random() * 100000)}`
    },
    data() {
        return {
            processing: false,
            blobUrl: '',
        }
    },
    props: {
        imgSrc: '',
        placeholderImgName: '',
        editable: false,
        uploadUrl: '',
        imgClass: ''
    },
    watch: { 
      	imgSrc(newVal, oldVal) {
            this.refreshImg(newVal);
        }
    },
    mounted() {
        this.refreshImg(this.imgSrc);
    },
    methods: {
        refreshImg(imgSrc) {
            if (imgSrc) {
                this.processing = true;
                this.$apiClient().getFileBlob(imgSrc)
                    .then(response => {
                        this.processing = false;
                        this.blobUrl = (URL || webkitURL).createObjectURL(response.data);
                    }).catch(() => {
                        this.processing = false;
                    });
            }
        },
        onImgUpload: function(e) {
            const file = (e.dataTransfer ? e.dataTransfer.files[0] : e.target.files[0]);
            this.processing = true;
            this.$apiClient().uploadFile(this.uploadUrl, file)
                .then((response) => {
                  this.processing = false;
                  this.$store.commit('setJwt', response.data.token);
              }).catch(() => {
                this.processing = false;
              });

            e.preventDefault();
            e.stopPropagation();
        },
        consumeEvent(e) {
            e.preventDefault();
            e.stopPropagation();
        }
    }
}