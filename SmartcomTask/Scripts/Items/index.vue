<template>
    <div class="items">

        <a v-if="isAdmin" :href="CreateUrl">Add Item</a>

        <div v-for="item in items" class="item__block">
            <h2>{{ item.name }}</h2>

            <div class="item__inner">
                <div class="item__image"></div>

                <div class="item__info">
                    <p>Категория: {{ item.category }}</p>
                    <p>Цена {{ item.price }}</p>
                    <p>Код товара: {{ item.code }}</p>
                </div>
                
                <div class="item__actions">
                    <a v-if="isAdmin" @click="deleteItem(item.id)">Удалить</a>
                    <a v-if="isAdmin" :href="EditUrl + '/' + item.id">Редактировать</a>
                    <a @click="addToCart(item.id)">В корзину</a>
                </div>

            </div>
        </div>
    </div>



    <!-- <div id="items">
        <table class="table">
            <thead>
                <tr>
                    <th v-if="isAdmin">
                        Код товара
                    </th>
                    <th>
                        Наименование
                    </th>
                    <th>
                        Цена
                    </th>
                    <th>
                        Категория
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
                        <a @click="addToCart(item.id)">Добавить в корзину</a>
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
    </div> -->
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
                var sure = confirm("Удалить " + currentItem.name + "?");

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
                var sure = confirm("Добавить " + currentItem.name + " в корзину? ");

                if (sure) {
                    new Promise(function (resolve, reject) {
                        Axios
                            .post(base.AddToCartUrl, currentItem)
                            .then(res => {
                                console.log(res);
                            })
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