<template>
    <div v-if="isAdmin" id="customers">
        <table class="table">
            <thead>
                <tr>
                    <th>
                        Логин
                    </th>
                    <th>
                        Имя
                    </th>
                    <th>
                        Email
                    </th>
                    <th>
                        Код
                    </th>
                    <th>
                        Адрес
                    </th>
                    <th>
                        Скидка
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="user in users">
                    <td>
                        {{ user.userName }}
                    </td>
                    <td>
                        {{ user.customer.name }}
                    </td>
                    <td>
                        {{ user.email }}
                    </td>
                    <td>
                        {{ user.customer.code }}
                    </td>
                    <td>
                        {{ user.customer.address }}
                    </td>
                    <td>
                        {{ user.customer.discount }}
                    </td>
                    <td>
                        <a :href="EditUrl + '/' + user.id">Edit</a>
                        <a @click="deleteUser(user.id)">Delete</a>
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td>
                        <a v-if="isAdmin" :href="CreateUrl">Add customer</a>
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
            UsersUrl: String,
            EditUrl: String,
            CreateUrl: String,
            DeleteUrl: String
        },
        data() {
            return {
                users: [],
            }
        },


        methods: {
            deleteUser(id) {
                var base = this;

                var currentUser = base.users.filter(f => { return f.id === id; })[0];
                var sure = confirm("Do you want to delete item -> " + currentUser.userName + "?");

                if (sure) {
                    new Promise(function (resolve, reject) {
                        Axios
                            .post(base.DeleteUrl + '/' + currentUser.id)
                            .then(res => {
                                console.log(res);
                                window.location.reload();
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
                    .get(base.UsersUrl)
                    .then(response => {
                        console.log(response);
                        base.users = response.data;
                    })
                    .catch(error => {
                        console.log(error);
                    });
            });   
        }
    };
</script>