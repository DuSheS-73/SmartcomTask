<template>
    <div id="items">
        <table class="table">
            <thead>
                <tr>
                    <th>
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
                    <td>
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
                        <a v-if="isAdmin" :href="EditUrl + '/' + item.id">Edit</a>
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
            CreateUrl: String
        },
        data() {
            return {
                items: [],
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