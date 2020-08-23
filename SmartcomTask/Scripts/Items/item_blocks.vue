<template>
	<div class="item__block">
        <div v-for="item in items" class="item__inner">
            <div class="item__image">
                        <!-- В перспективе передавть урл вместе с товаром -->
            </div>

            <div class="item__info">
                <h2 class="title">{{ item.name }}</h2>
                <h3>Категория: {{ item.category }}</h3>
                <h2>Цена: {{ item.price }}</h2>
                <h5>Код товара: {{ item.code }}</h5>
            </div>
                    
            <div class="item__actions">
                <a v-if="isAdmin" @click="deleteItem(item.id)" class="delete__btn">Удалить</a>
                <a v-if="isAdmin" :href="EditUrl + '/' + item.id" class="edit__btn">Редактировать</a>
                <a @click="addToCart(item.id)" class="btn red to_cart__btn">В корзину</a>
            </div>

        </div>
    </div>
</template>

<script>
import Axios from "axios";

	export default {
		props: {
			isAdmin: Boolean,
            ItemsUrl: String,
            EditUrl: String,
            CreateUrl: String,
            DeleteUrl: String,
            AddToCartUrl: String,
            ApplyFilterUrl: String
		},

		data() {
            return {
                items: []
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
                            .then(response => {
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
                            .then(response => {})
                            .catch(error => { console.log(error); });
                    });
                }
            },

            applyFilter(filterOptions) {
                var base = this;

                new Promise(function (resolve, reject) {
                    Axios
                        .post(base.ApplyFilterUrl, filterOptions)
                        .then(response => {
                            base.items = response.data;
                        })
                        .catch(error => { console.log(error); });
                });
            }
        },

        mounted() {
            var base = this;

            new Promise(function (resolve, reject) {
                Axios
                    .get(base.ItemsUrl)
                    .then(response => {
                        base.items = response.data;
                    })
                    .catch(error => {
                        console.log(error);
                    });
            });   
        }
	};
</script>