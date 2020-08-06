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
                        <a v-if="isAdmin" :href="EditItemUrl + '/' + item.id">Edit</a>
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
            //EditItemUrl: String
        },
        data() {
            return {
                GetItemsUrl: './Items/ItemsData',
                EditItemUrl: '/Items/Edit',
                CreateUrl: './Items/Create',

                items: [],
            }
        },
        mounted() {
            Axios
                .get(this.ItemsUrl)
                .then(response => {
                    console.log(response);
                    this.items = response.data;
                })
                .catch(error => {
                    console.log(error);
                })
        }
    };
</script>