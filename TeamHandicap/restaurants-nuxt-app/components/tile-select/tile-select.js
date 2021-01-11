export default {
    props: {
        title: '',
        hasImg: false,
        tag: '',
        dataPath: ''
    },
    data() {
      return {
        options: [],
      }
    },
    mounted() {
      this.$apiClient().get(this.dataPath)
        .then(response => {
            this.options = response.data;
        })
        .catch(err => console.log(err));
    }
  }