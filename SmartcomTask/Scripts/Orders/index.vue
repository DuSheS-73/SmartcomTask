<template>
    <div id="cart">
        <table class="table">
            <thead>
                <tr>
                    <th>
                        Shipment date
                    </th>
                    <th>
                        Number
                    </th>
                    <th>
                        Status
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in orders">
                    <td>
                        {{ item.item.name }}
                    </td>
                    <td>
                        
                    </td>
                    <td>
                        
                    </td>
                    <td>

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
            OrdersDataUrl: String
        },

        data() {
            return {
               orders: []
            }
        },

        methods: {
           
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