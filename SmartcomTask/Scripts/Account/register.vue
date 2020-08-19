<template>
    <div class="form__block">

        <h1>Регистрация</h1>
        <form class="form-submit">
            <div class="form-group">
                <input v-model="Name" placeholder="Имя"/>
            </div>

            <div class="form-group">
                <input v-model="UserName" placeholder="Логин"/>
            </div>

            <div class="form-group">
                <input v-model="Email" placeholder="Email"/>
            </div>

            <div class="form-group">
                <input v-model="Password" type="password" placeholder="Пароль"/>
            </div>

            <div class="form-group">
                <input v-model="Address" placeholder="Адрес"/>
            </div>
            <a @click="register" class="btn red">Зарегистрироваться</a>
        </form>
    </div>
</template>

<script>
import Axios from "axios";

    export default {
        props: {
            RegisterUrl: String,
            IndexUrl: String
        },
        data() {
            return {
                Name: '',
                UserName: '',
                Email: '',
                Password: '',
                Address: '',

                errors: []
            }
        },
        methods: {
            register() {
                var base = this;

                var data = {
                    name: base.Name,
                    userName: base.UserName,
                    email: base.Email,
                    password: base.Password,
                    address: base.Address,
                    Discount: 0
                };

                new Promise(function (resolve, reject) {
                    Axios
                        .post(base.RegisterUrl, data)
                        .then(response => {
                            if (response.data.success) {
                                window.location.href = base.IndexUrl;
                            }
                            else {
                                base.errors = response.data;
                            }   
                        })
                        .catch(error => { console.log(error); });
                });
                
            }
        } 
    };
</script>