<template>
    <div class="form__block">
        <h1>Авторизация</h1>

        <div v-if="errors.length != 0" class="alert danger__alert">
            {{ errors[0] }}
        </div>

        <form class="form-submit">
            <div class="form-group">
                <input v-model="userName" placeholder="Логин" />
            </div>
            <div class="form-group">
                <input v-model="password" type="password" placeholder="Пароль" />
            </div>
            <div class="form-group">
                <span>Запомнить пароль?</span>
                <input v-model="rememberMe" type="checkbox" class="form-checkbox"/>
            </div>
            <a @click="login" class="btn red">Войти</a>

        </form>
    </div>
</template>

<script>
import Axios from "axios";

    export default {
        props: {
            LoginUrl: String,
            IndexUrl: String
        },

        data() {
            return {
                userName: '',
                password: '',
                rememberMe: false,

                errors: []
            }
        },

        methods: {
            login() {
                var base = this;

                var data = {
                    UserName: base.userName,
                    Password: base.password,
                    RememberMe: base.rememberMe
                }

                new Promise(function (resolve, reject) {
                    Axios
                        .post(base.LoginUrl, data)
                        .then(response => {
                            if (response.data.success) {
                                window.location.href = base.IndexUrl;
                            }
                            else {
                                base.errors = response.data.errors;
                            }
                        })
                        .catch(error => { console.log(error); });
                });
            }
        }
    };
</script>