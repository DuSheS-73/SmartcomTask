import Vue from 'vue';
import IndexComponent from "./index.vue";

new Vue({
    el: "#app",
    components: {
        'index-component': IndexComponent
    }
});