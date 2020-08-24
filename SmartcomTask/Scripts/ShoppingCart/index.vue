<template>
    <div id="cart" v-if="cart.shoppingCart.allItems.length > 0">
        <table class="table">
            <thead>
                <tr>
                    <th>
                        Товар
                    </th>
                    <th>
                        Цена за единицу
                    </th>
                    <th>
                        Количество
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="i in cart.shoppingCart.allItems">
                    <td>
                        {{ i.item.name }}
                    </td>
                    <td>
                        {{ i.item.price }}
                    </td>
                    <td>
                        {{ i.amount }}
                    </td>
                    <td>
                        <a @click="removeFromCart(i.item)" class="btn black">Убрать</a>
                    </td>
                </tr>
            </tbody>
        </table>

        <a @click="clearCart" class="btn black">Отчистить корзину</a>
        <a @click="makeOrder" class="btn red">Перейти к оплате</a>
        
    </div>
    <div v-else id="cart-empty">
        <h2>Корзина пуста. Загляните в <a :href="CatalogUrl">каталог товаров</a></h2>
    </div>
</template>

<script>
import Axios from "axios"

    export default {
        props: {
            CatalogUrl: String,
            CartUrl: String,
            RemoveUrl: String,
            OrderUrl: String,
            ClearUrl: String,
            IndexUrl: String
        },

        data() {
            return {
                cart: {
                    shoppingCart: {
                        allItems: []
                    },
                    total: 0
                }
            }
        },

        methods: {
            removeFromCart(item) {
                var base = this;

                var sure = confirm("Убрать из корзины " + item.name + "?");
                if (sure) {
                    new Promise(function (resolve, reject) {
                        Axios
                            .post(base.RemoveUrl, item)
                            .then(response => {
                                console.log(response);
                                window.location.reload();
                            })
                            .catch(error => {
                                console.log(error);
                            });
                    });
                }
            },

            clearCart() {
                var base = this;

                var sure = confirm("Желаете отчистить корзину?");
                if (sure) {
                    new Promise(function (resolve, reject) {
                        Axios
                            .post(base.ClearUrl)
                            .then(response => {
                                console.log(response);
                                window.location.reload();
                            })
                            .catch(error => {
                                console.log(error);
                            });
                    });
                }
            },

            makeOrder() {
                var base = this;
                var cartItems = this.cart.shoppingCart.allItems;

                var sure = confirm("Оформить заказ?");
                if (sure) {
                    new Promise(function (resolve, reject) {
                        Axios
                            .post(base.OrderUrl, cartItems)
                            .then(response => {
                                console.log(response);
                                alert("Заказ успешно создан!");
                                window.location.href = base.IndexUrl;
                            })
                            .catch(error => {
                                console.log(error);
                            });
                    });
                }
            }
        },

        mounted() {
            var base = this;

            new Promise(function (resolve, reject) {
                Axios
                    .get(base.CartUrl)
                    .then(response => {
                        console.log(response);
                        base.cart = response.data;
                    })
                    .catch(error => {
                        console.log(error);
                    });
            });   
        }
    };
</script>