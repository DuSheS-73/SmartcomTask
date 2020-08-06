import Vue from 'vue';
import HomeComponent from "./index.vue";

new Vue({
    el: "#app",
    components: {
        'home-component': HomeComponent
    }
});