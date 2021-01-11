<template>
    <form id="passwordResetForm" @submit="resetPassword">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <h1> Reset your password</h1>
                </div>

                <div v-if="errors && errors.length" class="col-12">
                    <ul class="msg error pl-30px">
                        <li v-for="(error, index) in errors" :key="'err_' + index">{{ error }}</li>
                    </ul>
                </div>
            </div>

            <div class="row">
                <div class="col12 col-lg-6">
                    <div class="form-input-wrap">
                        <label for="emailAddress" class="form-input-label">
                           Email Address
                        </label>
                        <input type="email" id="emailAddress" name="emailAddress" class="form-input" v-model="emailAddress" disabled />
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col12 col-lg-6">
                    <div class="form-input-wrap">
                        <label for="newPassword" class="form-input-label">
                            New password
                        </label>
                        <input type="password" id="newPassword" name="newPassword" class="form-input" v-model="formData.newPassword" />
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-12 py-20px">
                    <button type="submit" class="btn primary">
                        submit
                        <img v-if="processing" class="spinner" src="@/assets/loading.gif" alt="Loading..." />
                    </button>
                </div>
            </div>
        </div>
    </form>
</template>

<script src="./reset-password.js"></script>