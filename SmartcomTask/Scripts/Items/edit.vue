<template>
    <div class="edit">
        <h1>Edit item {{ item.code }} / {{ item.name }}</h1>
        <form>
            <div class="form-group">
                <label for="item.code" class="form-label">Логин</label>
                <input v-model="item.code" class="form-input" required />
            </div>

            <div class="form-group">
                <label for="item.name" class="form-label">Пароль</label>
                <input v-model="item.name" class="form-input" required />
            </div>

            <div class="form-group">
                <label for="item.price" class="form-label">Пароль</label>
                <input v-model="item.price" class="form-input" required />
            </div>

            <div class="form-group">
                <label for="item.category" class="form-label">Пароль</label>
                <input v-model="item.category" class="form-input" required />
            </div>

            <div class="form-group">
                <input type="button" @click="save" value="Войти" class="form-submit-btn" />
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
                item: {
                    id: 0,
                    code: '',
                    name: '',
                    price: '',
                    category: ''
                }
            }
        },

        methods: {
            save() {
                var base = this;

                new Promise(function (resolve, reject) {
                    Axios
                        .post(base.EditUrl, {
                            ID: base.item.id,
                            Code: base.item.code,
                            Name: base.item.name,
                            Price: parseInt(base.item.price),
                            Category: base.item.category
                        })
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
                        base.item = res.data;
                        console.log(res);
                    })
                    .catch(error => { console.log(error); });
            });
        }
    };
</script>