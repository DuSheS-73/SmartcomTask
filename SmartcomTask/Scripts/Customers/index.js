import Vue from 'vue';
import IndexComponent from './index.vue';
import EditComponent from './edit.vue';
import CreateComponent from './create.vue';

new Vue({
    el: "#app",
    components: {
        'index-component': IndexComponent,
        'edit-component': EditComponent,
        'create-component': CreateComponent
    }
});