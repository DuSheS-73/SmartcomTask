<template>
    <div class="form__block">

        <h1>Изменение данных</h1>

        <div v-if="errors.length != 0" class="alert danger__alert">
            {{ errors[0] }}
        </div>

        <form class="form-submit">
            <div class="form-group">
                <input v-model="user.userName" class="form-input" placeholder="Логин" />
            </div>

            <div class="form-group">
                <input v-model="user.email" class="form-input" placeholder="Email"  />
            </div>

            <div class="form-group">
                <input v-model="user.customer.name" class="form-input" placeholder="Имя" />
            </div>

            <div class="form-group">
                <input v-model="user.customer.code" class="form-input" placeholder="Код" />
            </div>

            <div class="form-group">
                <input v-model="user.customer.address" class="form-input" placeholder="Адрес" />
            </div>

            <div class="form-group">
                <input v-model="user.customer.discount" class="form-input" placeholder="Скидка" />
            </div>

            <a @click="save" class="btn red">Сохранить</a>
        </form>
    </div>
</template>

<script>
import Axios from "axios";

    export default {
        props: {
            EditUrl: String,
            DetailsUrl: String,
            IndexUrl: String
        },

        data() {
            return {
                user: {
                    id: 0,
                    userName: '',
                    email: '',
                    customer: {
                        name: '',
                        code: '',
                        address: '',
                        discount: ''
                    }
                },

                errors: []
            }
        },

        methods: {
            save() {
                var base = this;

                var data = {
                    Id: base.user.id,
                    Name: base.user.customer.name,
                    UserName: base.user.userName,
                    Email: base.user.email,
                    code: base.user.customer.code,
                    Address: base.user.customer.address,
                    Discount: parseInt(base.user.customer.discount)    
                }

                new Promise(function (resolve, reject) {
                    Axios
                        .post(base.EditUrl, data)
                        .then(response => {
                            if(response.data.success) {
                                window.location.href = base.IndexUrl;
                            }
                            else {
                                base.errors = response.data.errors;
                            }
                        })
                        .catch(error => { console.log(error); });
                });
            }
        },

        mounted() {
            var base = this;
            new Promise(function (resolve, reject) {
                Axios
                    .get(base.DetailsUrl)
                    .then(response => {
                        base.user = response.data;
                    })
                    .catch(error => { console.log(error); });
            });
        }
    };
</script>