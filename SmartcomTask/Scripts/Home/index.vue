<template>
    <div id="items">
        <a :href="ItemsUrl">All items</a>
        <a v-if="isAdmin" :href="CustomersUrl">Show customers</a>
    </div>
</template>

<script>
import Axios from "axios"

    export default {
        props: {
            isAdmin: Boolean,
            ItemsUrl: String,
            CustomersUrl: String
            //ItemsUrl: String,
            //EditUrl: String,
            //CreateUrl: String,
            //DeleteUrl: String
        },
        data() {
            return {
                //items: [],
            }
        },


        methods: {
            //deleteItem(id) {
            //    var base = this;

            //    var currentItem = base.items.filter(f => { return f.id === id; })[0];
            //    var sure = confirm("Do you want to delete item -> " + currentItem.name + " ( " + currentItem.code + " )? ");

            //    if (sure) {
            //        new Promise(function (resolve, reject) {
            //            Axios
            //                .post(base.DeleteUrl + '/' + currentItem.id)
            //                .then(res => res)
            //                .catch(error => { console.log(error); });
            //        });
            //    }
            //}
        },

        mounted() {
            //var base = this;

            //new Promise(function (resolve, reject) {
            //    Axios
            //        .get(base.ItemsUrl)
            //        .then(response => {
            //            console.log(response);
            //            base.items = response.data;
            //        })
            //        .catch(error => {
            //            console.log(error);
            //        });
            //});   
        }
    };
</script>