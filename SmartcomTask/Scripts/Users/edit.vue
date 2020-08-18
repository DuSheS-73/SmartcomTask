<template>
    <div class="edit">
        <form>
            <div class="form-group">
                <label for="user.userName" class="form-label">Логин</label>
                <input v-model="user.userName" class="form-input" required />
            </div>

            <div class="form-group">
                <label for="user.email" class="form-label">Email</label>
                <input v-model="user.email" class="form-input" required />
            </div>

            <div class="form-group">
                <label for="user.customer.name" class="form-label">Имя</label>
                <input v-model="user.customer.name" class="form-input" required />
            </div>

            <div class="form-group">
                <label for="user.customer.address" class="form-label">Адрес</label>
                <input v-model="user.customer.address" class="form-input" required />
            </div>

            <div class="form-group">
                <label for="user.customer.discount" class="form-label">Скидка</label>
                <input v-model="user.customer.discount" class="form-input" required />
            </div>

            <div class="form-group">
                <input type="button" @click="save" value="Сохранить" class="form-submit-btn" />
            </div>
        </form>
    </div>
</template>

<script>
import Axios from "axios";

    export default {
        props: {
            EditUrl: String,
            DetailsUrl: String
        },

        data() {
            return {
                user: {
                    id: 0,
                    userName: '',
                    email: '',
                    customer: {
                        name: '',
                        address: '',
                        discount: ''
                    }
                }
            }
        },

        methods: {
            save() {
                var base = this;

                var data = {
                    Name: base.user.customer.name,
                    UserName: base.user.userName,
                    Email: base.user.email,
                    Password: '',
                    Address: base.user.customer.address,
                    Discount: parseInt(base.user.customer.discount)    
                }

                new Promise(function (resolve, reject) {
                    Axios
                        .post(base.EditUrl, data)
                        .then(res => {
                            //window.location.href = base.IndexUrl;
                            console.log(res);
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
                    .then(res => {
                        base.user = res.data;
                        console.log(res);
                    })
                    .catch(error => { console.log(error); });
            });
        }
    };
</script>