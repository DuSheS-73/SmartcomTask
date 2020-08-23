<template>
    <div id="orders">

        <h1>Мои заказы</h1>

        <div class="display__flex">
            
            <div class="filter__block">
                <div class="filter__inner">
                    <div class="filter__group">
                        <h4>Показать</h4>
                        <a v-for="filter in orderFilers" @click="getOrdersByStatus(orderFilers.indexOf(filter))" v-bind:class="{ 'active__filter': filter.isActive }">{{ filter.filterName }}</a>
                    </div>
                </div>
            </div>
            <div class="orders__block">
                <div v-for="order in orders" class="order__inner">
                    <div class="display__flex">
                        <div class="order__info">

                            <div v-if="isAdmin" class="info__group">
                                <p><span>Заказчик:</span> </p>
                                <!-- В виде ссылки на профиль заказчика -->
                                <p>{{ order.customerId }}</p>
                            </div>

                            <p><span>Номер заказа:</span> {{ order.orderNumber }}</p>

                            <p><span>Дата заказа:</span> {{ order.orderDateDisplay }}</p>

                            <p><span>Ожидаемая дата доставки:</span> {{ order.shipmentDateDisplay }}</p>

                            <p><span>Состояние заказа:</span> {{ order.status }}</p>
                        </div>

                        <div class="order__action">
                            <a @click="getOrderDetails(order)" class="btn black">Подробнее</a>
                            <a v-if="isAdmin || order.status === 'Новый'" @click="deleteOrder(order)" class="btn red">Отменить заказ</a>
                            <a v-if="isAdmin && order.status != 'Выполнен'" @click="setOrderStatus(order)" class="edit__btn">Сменить статус</a>
                        </div>
                    </div>

                    <div class="order_detail__block" v-if="clickedOrderIndex == orders.indexOf(order)">
                        <div v-for="element in orderDetails" class="order__details">
                            <p><span>Товар:</span> {{ element.item.name }}</p>

                            <p><span>Цена за единицу:</span> {{ element.itemPrice }}</p>

                            <p><span>Количество:</span> {{ element.itemsCount }}</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import Axios from "axios"

    export default {
        props: {
            isAdmin: Boolean,
            OrdersDataUrl: String,
            OrderDetailsUrl: String,
            DeleteUrl: String,
            SetStatusUrl: String
        },

        data() {
            return {
                orders: [],
                orderDetails: [],
                clickedOrderIndex: null,

                errors: [],

                orderFilers: [
                    {
                        filterName: "Все",
                        isActive: true
                    },
                    {
                        filterName: "Новые",
                        isActive: false
                    },
                    {
                        filterName: "Выполняются",
                        isActive: false
                    },
                    {
                        filterName: "Завершенные",
                        isActive: false
                    }
                ]
            }
        },

        methods: {
            getOrderDetails(order) {
                var base = this;

                new Promise(function (resolve, reject) {
                    Axios
                        .get(base.OrderDetailsUrl + '/' + order.id)
                        .then(response => {
                            console.log(response);
                            base.orderDetails = response.data;
                        })
                        .catch(error => {
                            console.log(error);
                        });
                });

                base.clickedOrderIndex = base.orders.indexOf(order); 
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
            },

            getOrdersByStatus(statusIndex) {
                var base = this;

                var data = {
                    StatusIndex: statusIndex
                };

                new Promise(function (resolve, reject) {
                    Axios
                        .post(base.OrdersDataUrl, data)
                        .then(response => {
                            base.orders = response.data;
                        })
                        .catch(error => {
                            console.log(error);
                        });
                });

                base.orderFilers.forEach(element => { element.isActive = false; });
                base.orderFilers[statusIndex].isActive = true;
            },

            setOrderStatus(order) {
                var base = this;

                var sure = confirm("Сменить статус заказа?");
                if (sure) {
                    new Promise(function (resolve, reject) {
                        Axios
                            .post(base.SetStatusUrl, order)
                            .then(response => {
                                console.log(response);

                                if (response.data.success) {
                                    window.location.reload();
                                }
                                else {
                                    base.errors = response.data;
                                } 
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

            var data = {
                StatusIndex: 0
            };

            new Promise(function (resolve, reject) {
                Axios
                    .post(base.OrdersDataUrl, data)
                    .then(response => {
                        base.orders = response.data;
                    })
                    .catch(error => {
                        console.log(error);
                    });
            }); 
        }
    };
</script>