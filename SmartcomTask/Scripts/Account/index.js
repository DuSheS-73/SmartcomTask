import Vue from 'vue';
import LoginComponent from "./login.vue";
import RegisterComponent from "./register.vue";

new Vue({
    el: "#app",
    components: {
        'login-component': LoginComponent,
        'register-component': RegisterComponent
    },
});