export default {
    name: 'Register',
    data: function() {
        return {
            processing: false,
            errors: [],
            success: false,
            formData: {
                firstName: '',
                lastName: '',
                emailAddress: '',
                password: ''
            }
        }
    },
    methods: {
        showLogin: function() {
            this.$store.commit('toggleShowLoginOrRegister');
        },
        hideRegister: function() {
            this.$store.commit('hideRegister');
        },
        submitForm: function(e) {
            this.processing = true;
            this.errors = [];
            this.success = false;
            this.$apiClient().post('accounts/register', this.formData)
                .then((response) => {
                    this.success = true;
                    this.$store.commit('setJwt', response.data.token);
                    this.$store.commit('hideRegister');
                }).catch((err) => {
                    if (err.response && err.response.status === 400 && err.response.data) {
                        for (let key in err.response.data) {
                            if (Array.isArray(err.response.data[key])) {
                                this.errors = this.errors.concat(err.response.data[key]);
                            } else {
                                this.errors.push(err.response.data[key]);
                            }
                        }
                    } else {
                        this.errors.push('Oops, something went wrong... Try again later.');
                    }
                }).finally(() => this.processing = false);

            e.preventDefault();
        }
    }
}