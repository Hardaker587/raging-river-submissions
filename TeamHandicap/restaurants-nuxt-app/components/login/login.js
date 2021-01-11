export default {
    name: 'Login',
    data: function() {
        return {
            sendingEmail: false,
            processing: false,
            errors: [],
            successMsg: undefined,
            formData: {
                userName: '',
                password: ''
            }
        }
    },
    methods: {
        showRegister: function() {
            this.$store.commit('toggleShowLoginOrRegister');
        },
        hideLogin: function() {
            this.$store.commit('hideLogin');
        },
        submitForm: function(e) {
            this.processing = true;
            this.errors = [];
            this.successMsg = undefined;
            this.$apiClient().post('accounts/login', this.formData)
                .then((response) => {
                    this.$store.commit('setJwt', response.data.token);
                    this.$store.commit('hideLogin');
                }).catch(() => {
                    this.errors.push('Invalid email address or password.');
                }).finally(() => this.processing = false);

            e.preventDefault();
        },
        sendPasswordResetLink() {
            if (!this.formData.userName) {
                this.errors = ['Enter your email address, then hit "Forgot password" again.'];
                return;
            }

            this.sendingEmail = true;
            this.errors = [];
            this.successMsg = undefined;
            this.$apiClient().post(`accounts/forgot-password/${this.formData.userName}`, null)
                .then(() => {
                    this.successMsg = 'We sent you a password reset link via email';
                })
                .catch(() => {
                    this.errors = ['Failed to send password reset link.'];
                })
                .finally(() => this.sendingEmail = false);
        }
    }
}