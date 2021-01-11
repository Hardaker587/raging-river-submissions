export default {
    data() {
        return {
            processing: false,
            errors: [],
            emailAddress: undefined,
            formData: {
                token: undefined,
                newPassword: undefined
            }
        }
    },
    mounted() {
        this.formData.token = this.$nuxt.context.query.token;
        this.emailAddress = atob(this.$nuxt.context.query.user);
    },
    methods: {
        resetPassword(e) {
            this.processing = true;
            this.errors = [];
            this.$apiClient().post('accounts/reset-password', this.formData)
              .then((response) => {
                  this.$store.commit('setJwt', response.data.token);
                  this.$store.commit('hideLogin');
                  this.$router.push('/');
              })
              .catch((err) => { 
                if (err.response && err.response.status === 400 && err.response.data) {
                    for (let key in err.response.data) {
                        if (Array.isArray(err.response.data[key])) {
                            this.errors = this.errors.concat(err.response.data[key]);
                        } else {
                            this.errors.push(err.response.data[key]);
                        }
                    }
                  } else {
                    this.errors.push('Oops, something went wrong. Please try again later.');
                  }
                })
                .finally(() => this.processing = false);

            e.preventDefault();
        }
    }
}