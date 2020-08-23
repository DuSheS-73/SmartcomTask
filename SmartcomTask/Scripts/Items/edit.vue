<template>
    <div class="form__block">

        <h1>Изменение данных</h1>

        <div v-if="errors.length != 0" class="alert danger__alert">
            {{ errors[0] }}
        </div>

        <form class="form-submit">
            <div class="form-group">
                <input v-model="item.code" placeholder="Код товара"/>
            </div>

            <div class="form-group">
                <input v-model="item.name" placeholder="Наименование"/>
            </div>

            <div class="form-group">
                <input v-model="item.price" placeholder="Цена"/>
            </div>

            <div class="form-group">
                <input v-model="item.category" placeholder="Категория" />
            </div>
            <a @click="save" class="btn red" >Сохранить</a>
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
                item: {
                    id: 0,
                    code: '',
                    name: '',
                    price: '',
                    category: ''
                },

                errors: []
            }
        },

        methods: {
            save() {
                var base = this;

                var data = {
                    ID: base.item.id,
                    Code: base.item.code,
                    Name: base.item.name,
                    Price: parseInt(base.item.price),
                    Category: base.item.category
                }

                var sure = confirm("Сохранить изменения?")
                if(sure) {
                    new Promise(function (resolve, reject) {
                        Axios
                            .post(base.EditUrl, data)
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
        },

        mounted() {
            var base = this;
            new Promise(function (resolve, reject) {
                Axios
                    .get(base.DetailsUrl)
                    .then(res => {
                        base.item = res.data;
                    })
                    .catch(error => { console.log(error); });
            });
        }
    };
</script>