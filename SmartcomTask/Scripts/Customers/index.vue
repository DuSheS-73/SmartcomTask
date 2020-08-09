<template>
    <div v-if="isAdmin" id="customers">
        <table class="table">
            <thead>
                <tr>
                    <th>
                        Name
                    </th>
                    <th>
                        Code
                    </th>
                    <th>
                        Address
                    </th>
                    <th>
                        Discount
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in customers">
                    <td>
                        {{ item.name }}
                    </td>
                    <td>
                        {{ item.code }}
                    </td>
                    <td>
                        {{ item.address }}
                    </td>
                    <td>
                        {{ item.discount }}
                    </td>
                    <td>
                        <a :href="EditUrl + '/' + item.id">Edit</a>
                        <a href="javascript:window.location.reload();" v-on:click="deleteItem(item.id)">Delete</a>
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td>
                        <a v-if="isAdmin" :href="CreateUrl">Add customer</a>
                    </td>
                </tr>
            </tfoot>
        </table>
    </div>
</template>

<script>
import Axios from "axios"

    export default {
        props: {
            isAdmin: Boolean,
            CustomersUrl: String,
            EditUrl: String,
            CreateUrl: String,
            DeleteUrl: String
        },
        data() {
            return {
                customers: [],
            }
        },


        methods: {
            deleteItem(id) {
                var base = this;

                var currentItem = base.customers.filter(f => { return f.id === id; })[0];
                var sure = confirm("Do you want to delete item -> " + currentItem.name + "?");

                if (sure) {
                    new Promise(function (resolve, reject) {
                        Axios
                            .post(base.DeleteUrl + '/' + currentItem.id)
                            .then(res => res)
                            .catch(error => { console.log(error); });
                    });
                }
            }
        },

        mounted() {
            var base = this;

            new Promise(function (resolve, reject) {
                Axios
                    .get(base.CustomersUrl)
                    .then(response => {
                        console.log(response);
                        base.customers = response.data;
                    })
                    .catch(error => {
                        console.log(error);
                    });
            });   
        }
    };
</script>