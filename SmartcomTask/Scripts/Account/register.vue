<template>
    <div class="registration">

        <h1>Регистрация</h1>

        <form>

            <div class="form-group">
                <label for="Name" class="form-label">Логин</label>
                <input v-model="Name" class="form-input" required />
            </div>

            <div class="form-group">
                <label for="UserName" class="form-label">Логин</label>
                <input v-model="UserName" class="form-input" required />
            </div>

            <div class="form-group">
                <label for="Email" class="form-label">Логин</label>
                <input v-model="Email" class="form-input" required />
            </div>

            <div class="form-group">
                <label for="Password" class="form-label">Пароль</label>
                <input v-model="Password" type="password" class="form-input" required />
            </div>

            <div class="form-group">
                <label for="Address" class="form-label">Логин</label>
                <input v-model="Address" class="form-input" required />
            </div>
            <div class="form-group">
                <input @click="register" type="submit" value="Войти" class="form-submit-btn" />
            </div>

        </form>

    </div>
</template>

<script>
import Axios from "axios";

    export default {
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
                var data = {
                    Name: this.Name,
                    UserName: this.UserName,
                    Email: this.Email,
                    Password: this.Password,
                    Address: this.Address
                };

                new Promise(function (resolve, reject) {
                    Axios
                        .post("./Account/Registration", data)
                        .then(response => { console.log(response); })
                        .catch(error => { console.log(error); });
                });
                
            }
        } 
    };
</script>