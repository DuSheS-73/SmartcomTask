<template>
    <div class="form__block">
        <h1>Добавить товар</h1>
        <form class="form-submit">
            <div class="form-group">
                <input v-model="Code" placeholder="Код товара"/>
            </div>

            <div class="form-group">
                <input v-model="Name" placeholder="Наименование"/>
            </div>

            <div class="form-group">
                <input v-model="Price" placeholder="Цена"/>
            </div>

            <div class="form-group">
                <input v-model="Category" placeholder="Категория" />
            </div>
            <a @click="save" class="btn red" >Создать</a>
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
                Code: '',
                Name: '',
                Price: '',
                Category: '',

                errors: []
            }
        },

        methods: {
            save() {
                var base = this;

                var sure = confirm("Создать запись?");
                if (sure) {
                    new Promise(function (resolve, reject) {
                        Axios
                            .post(base.CreateUrl, {
                                Code: base.Code,
                                Name: base.Name,
                                Price: parseInt(base.Price),
                                Category: base.Category
                            })
                            .then(res => {
                                if (res.data.success) {
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
        }
    };
</script>