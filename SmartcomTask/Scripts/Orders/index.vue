<template>
    <div id="cart">
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
                    <th>
                        Дата заказа
                    </th>
                    <th>
                        Номер заказа
                    </th>
                    <th>
                        Дата доставки
                    </th>
                    <th>
                        Состояние заказа
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="order in orders">
                    <td>
                        {{ order.orderNumber }}
                    </td>
                    <td>
                        {{ order.orderDate }}
                    </td>
                    <td>
                        {{ order.shipmentDate }}
                    </td>
                    <td>
                        {{ order.status }}
                    </td>
                    <td>
                        <input type="button" @click="orderDetails(order.id)" value="Подробнее" />
                        <a v-if="isAdmin || order.status === 'New'" @click="deleteOrder(order)">Отменить заказ</a>
                    </td>

                </tr>
                <tr v-for="order in orders">
                    <td>
                        <div id="details">
                            <table>
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
                                    <tr v-for="element in details">
                                        <td>
                                            {{ element.item.name }}
                                        </td>
                                        <td>
                                            {{ element.itemPrice }}
                                        </td>
                                        <td>
                                            {{ element.itemsCount }}
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td>
                        
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
            OrdersDataUrl: String,
            OrderDetailsUrl: String,
            DeleteUrl: String
        },

        data() {
            return {
                orders: [],
                details: []
            }
        },

        methods: {
            orderDetails(id) {
                var base = this;

                new Promise(function (resolve, reject) {
                    Axios
                        .get(base.OrderDetailsUrl + '/' + id)
                        .then(response => {
                            console.log(response);
                            base.details = response.data;
                        })
                        .catch(error => {
                            console.log(error);
                        });
                });
            },

            deleteOrder(order) {
                var base = this;

                var sure = confirm("Отменить заказ " + order.orderNumber + "?");
                if (sure) {
                    new Promise(function (resolve, reject) {
                        Axios
                            .post(base.DeleteUrl + '/' + order.id)
                            .then(response => {
                                console.log(response);
                                window.location.reload();
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
                    .get(base.OrdersDataUrl)
                    .then(response => {
                        console.log(response);
                        base.orders = response.data;
                    })
                    .catch(error => {
                        console.log(error);
                    });
            });   
        }
    };
</script>