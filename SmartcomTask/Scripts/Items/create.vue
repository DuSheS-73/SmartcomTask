<template>
    <div class="create">
        <h1>Create new Item</h1>
        <form>
            <div class="form-group">
                <label for="Code" class="form-label">Код товара</label>
                <input v-model="Code" class="form-input" required />
            </div>

            <div class="form-group">
                <label for="Name" class="form-label">Наименование</label>
                <input v-model="Name" class="form-input" required />
            </div>

            <div class="form-group">
                <label for="Price" class="form-label">Цена</label>
                <input v-model="Price" class="form-input" required />
            </div>

            <div class="form-group">
                <label for="Category" class="form-label">Категория</label>
                <input v-model="Category" class="form-input" required />
            </div>

            <div class="form-group">
                <input type="button" value="Создать" @click="save" class="form-submit-btn" />
            </div>
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
                Category: ''
            }
        },

        methods: {
            save() {
                var base = this;
                
                new Promise(function (resolve, reject) {
                    Axios
                        .post(base.CreateUrl, {
                            Code: base.Code,
                            Name: base.Name,
                            Price: parseInt(base.Price),
                            Category: base.Category
                        })
                        .then(res => { window.location.href = base.IndexUrl; })
                        .catch(error => { console.log(error); });
                });
            }
        }
    };
</script>