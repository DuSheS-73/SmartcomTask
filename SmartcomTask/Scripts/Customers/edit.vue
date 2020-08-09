<template>
    <div class="edit">
        <h1>Edit item {{ customer.code }} / {{ customer.name }}</h1>
        <form>
            <div class="form-group">
                <label for="customer.name" class="form-label">Name</label>
                <input v-model="customer.name" class="form-input" required />
            </div>

            <div class="form-group">
                <label for="customer.code" class="form-label">Code</label>
                <input v-model="customer.code" class="form-input" required />
            </div>

            <div class="form-group">
                <label for="customer.address" class="form-label">Address</label>
                <input v-model="customer.address" class="form-input" required />
            </div>

            <div class="form-group">
                <label for="customer.discount" class="form-label">Discount</label>
                <input v-model="customer.discount" class="form-input" required />
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
                customer: {
                    id: 0,
                    name: '',
                    code: '',
                    address: '',
                    discount: ''
                }
            }
        },

        methods: {
            save() {
                var base = this;

                new Promise(function (resolve, reject) {
                    Axios
                        .post(base.EditUrl, {
                            ID: base.customer.id,
                            Name: base.customer.name,
                            Code: base.customer.code,
                            Address: base.customer.address,
                            Discount: parseInt(base.customer.discount)
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
                        base.customer = res.data;
                        console.log(res);
                    })
                    .catch(error => { console.log(error); });
            });
        }
    };
</script>