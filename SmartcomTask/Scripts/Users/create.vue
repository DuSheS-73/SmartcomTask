<template>
    <div class="form__block">
    
        <h1>Создать нового пользователя</h1>

        <div v-if="errors.length != 0" class="alert danger__alert">
            {{ errors[0] }}
        </div>

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
            <a @click="save" class="btn red">Зарегистрировать</a>
        </form>
    </div>
</template>

<script>
import Axios from "axios";

    export default {
        props: {
            CreateUrl: String,
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
            save() {
                var base = this;

                var data = {
                    name: base.Name,
                    userName: base.UserName,
                    email: base.Email,
                    password: base.Password,
                    address: base.Address
                }
                
                new Promise(function (resolve, reject) {
                    Axios
                        .post(base.CreateUrl, data)
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