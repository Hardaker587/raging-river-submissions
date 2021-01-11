<template>
  <div class="login-container">
      <form id="loginForm" @submit="submitForm">
        <div class="close">
             <button type="button" class="btn primary"  @click="hideLogin">
                 &times;
             </button>
        </div> 
        <div class="row">
            <div class="col-12">
                <h1>
                    Log in
                </h1>
            </div>

            <div v-if="errors && errors.length" class="col-12">
                <ul class="msg error pl-30px">
                    <li v-for="(error, index) in errors" :key="'err_' + index">{{ error }}</li>
                </ul>
            </div>

            <div v-if="successMsg" class="col-12">
                <div class="msg confirm">
                    {{ successMsg }} &check;
                </div>
            </div>

            <div class="col-12">
                <div class="form-input-wrap">
                    <label for="userName" class="form-input-label" >Email address:</label>
                    <input type="email" class="text-input form-input" id="userName" name="userName" v-model="formData.userName" />
                </div>
            </div>

            <div class="col-12">
                <div class="form-input-wrap">
                    <label for="password" class="form-input-label" >Password:</label>
                    <input type="password" class="text-input form-input" id="password" name="password" v-model="formData.password" />
                </div>
            </div>
        
            <div class="col-12 pt-50px">
                <button type="submit" class="btn primary">
                    Log in
                    <img v-if="processing" class="spinner" src="@/assets/loading.gif" alt="Loading..." />
                </button>
                <span v-if="!processing">
                    <button type="button" class="btn link ml-5px px-5px" @click="showRegister">
                        Register
                    </button>
                    |
                    <button type="button" class="btn link px-5px" @click="sendPasswordResetLink">
                        Forgot password
                        <img v-if="sendingEmail" class="spinner" src="@/assets/loading.gif" alt="Loading..." />
                    </button>
                </span>
            </div>
        </div>
      </form>
  </div>
</template>

<script src="./login.js"></script>
<style scoped lang="scss" rel="stylesheet/scss">
@import './login.scss';
</style>