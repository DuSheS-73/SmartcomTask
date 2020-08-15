<template>
    <div id="cart">
        <table class="table">
            <thead>
                <tr>
                    <th>
                        Name
                    </th>
                    <th>
                        Price
                    </th>
                    <th>
                        Amount
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="i in cart.shoppingCart.shoppingCartItems">
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
                        <a @click="removeFromCart(i.item)">Убрать</a>
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td>
                        <a @click="makeOrder">Buy</a>
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
            CartUrl: String,
            RemoveUrl: String,
            OrderUrl: String,
            IndexUrl: String
        },

        data() {
            return {
                cart: {
                    shoppingCart: {
                        shoppingCartItems: []
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

            makeOrder() {
                var base = this;
                var cartItems = this.cart.shoppingCart.shoppingCartItems;

                var sure = confirm("Сделать заказ?");
                if (sure) {
                    new Promise(function (resolve, reject) {
                        Axios
                            .post(base.OrderUrl, cartItems)
                            .then(response => {
                                console.log(response);
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