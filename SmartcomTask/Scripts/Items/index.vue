<template>
    <div id="items">
        <table class="table">
            <thead>
                <tr>
                    <th v-if="isAdmin">
                        Code
                    </th>
                    <th>
                        Name
                    </th>
                    <th>
                        Price
                    </th>
                    <th>
                        Category
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in items">
                    <td v-if="isAdmin">
                        {{ item.code }}
                    </td>
                    <td>
                        {{ item.name }}
                    </td>
                    <td>
                        {{ item.price }}
                    </td>
                    <td>
                        {{ item.category }}
                    </td>
                    <td>
                        <a @click="addToCart(item.id)">Add to cart</a>
                        <a v-if="isAdmin" :href="EditUrl + '/' + item.id">Edit</a>
                        <a v-if="isAdmin" @click="deleteItem(item.id)">Delete</a>
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td>
                        <a v-if="isAdmin" :href="CreateUrl">Add Item</a>
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
            ItemsUrl: String,
            EditUrl: String,
            CreateUrl: String,
            DeleteUrl: String,
            AddToCartUrl: String
        },
        data() {
            return {
                items: [],
            }
        },


        methods: {
            deleteItem(id) {
                var base = this;

                var currentItem = base.items.filter(f => { return f.id === id; })[0];
                var sure = confirm("Do you want to delete item -> " + currentItem.name + " ( " + currentItem.code + " )? ");

                if (sure) {
                    new Promise(function (resolve, reject) {
                        Axios
                            .post(base.DeleteUrl + '/' + currentItem.id)
                            .then(res => {
                                console.log(res);
                                window.location.reload();
                            })
                            .catch(error => { console.log(error); });
                    });
                }
            },

            addToCart(id) {
                var base = this;

                var currentItem = base.items.filter(f => { return f.id === id; })[0];
                var sure = confirm("Do you want to add item to cart -> " + currentItem.name + "?");

                if (sure) {
                    new Promise(function (resolve, reject) {
                        Axios
                            .post(base.AddToCartUrl, currentItem)
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
                    .get(base.ItemsUrl)
                    .then(response => {
                        console.log(response);
                        base.items = response.data;
                    })
                    .catch(error => {
                        console.log(error);
                    });
            });   
        }
    };
</script>