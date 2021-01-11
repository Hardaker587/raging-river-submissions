<template>
  <div class="register-container">
      <form id="registrationForm" @submit="submitForm">
         <div class="close">
             <button type="button" class="btn primary"  @click="hideRegister">
                 &times;
             </button>
        </div> 
        <div class="row">
            <div class="col-12">
                <h1>
                    Register
                </h1>
            </div>

            <div v-if="errors && errors.length" class="col-12">
                <ul class="msg error pl-30px">
                    <li v-for="(error, index) in errors" :key="'err_' + index">{{ error }}</li>
                </ul>
            </div>

            <div v-if="success" class="col-12">
                <div class="msg confirm">
                    Your account has been created &check;
                </div>
            </div>

            <div class="col-12">
                <div class="form-input-wrap">
                    <label for="emailAddress" class="form-input-label" >Email address:</label>
                    <input type="email" class="text-input form-input" id="emailAddress" name="emailAddress" v-model="formData.emailAddress" />
                </div>
            </div>

            <div class="col-12">
                <div class="form-input-wrap">
                    <label for="firstName" class="form-input-label" >First name:</label>
                    <input type="text" class="text-input form-input" id="firstName" name="firstName" v-model="formData.firstName" />
                </div>
            </div>

            <div class="col-12">
                <div class="form-input-wrap">
                    <label for="lastName" class="form-input-label" >Last name:</label>
                    <input type="text" class="text-input form-input" id="lastName" name="lastName" v-model="formData.lastName" />
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
                    Register Now
                    <img v-if="processing" class="spinner" src="@/assets/loading.gif" alt="Loading..." />
                </button>
                <button v-if="!processing" type="button" class="btn link ml-5px" @click="showLogin">
                    Log in
                </button>
            </div>
        </div>
      </form>
  </div>
</template>

<script src="./register.js"></script>
<style scoped lang="scss" rel="stylesheet/scss">
@import './register.scss';
</style>