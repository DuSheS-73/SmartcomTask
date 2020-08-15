<template>
    <div class="registration">

        <h1>Регистрация</h1>

        <form>
            <div class="form-group">
                <label for="Name" class="form-label">Имя</label>
                <input v-model="Name" class="form-input" required />
            </div>

            <div class="form-group">
                <label for="UserName" class="form-label">Логин</label>
                <input v-model="UserName" class="form-input" required />
            </div>

            <div class="form-group">
                <label for="Email" class="form-label">Email</label>
                <input v-model="Email" class="form-input" required />
            </div>

            <div class="form-group">
                <label for="Password" class="form-label">Пароль</label>
                <input v-model="Password" type="password" class="form-input" required />
            </div>

            <div class="form-group">
                <label for="Address" class="form-label">Адрес</label>
                <input v-model="Address" class="form-input" required />
            </div>
            <div class="form-group">
                <input type="button" @click="register" value="Зарегистрироваться" class="form-submit-btn" />
            </div>
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
                Address: ''
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
                    address: base.Address
                };

                new Promise(function (resolve, reject) {
                    Axios
                        .post(base.RegisterUrl, data)
                        .then(response => {
                            console.log(response);
                            window.location.href = base.IndexUrl;
                        })
                        .catch(error => { console.log(error); });
                });
                
            }
        } 
    };
</script>