<template>
    <div class="create">
        <h1>Create new Customer</h1>
        <form>
            <div class="form-group">
                <label for="Name" class="form-label">Name</label>
                <input v-model="Name" class="form-input" required />
            </div>

            <div class="form-group">
                <label for="Code" class="form-label">Code</label>
                <input v-model="Code" class="form-input" required />
            </div>

            <div class="form-group">
                <label for="Address" class="form-label">Address</label>
                <input v-model="Address" class="form-input" required />
            </div>

            <div class="form-group">
                <label for="Discount" class="form-label">Discount</label>
                <input v-model="Discount" class="form-input" required />
            </div>

            <div class="form-group">
                <input type="button" value="Create" @click="save" class="form-submit-btn" />
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
                Name: '',
                Code: '',
                Address: '',
                Discount: ''
            }
        },

        methods: {
            save() {
                var base = this;
                
                new Promise(function (resolve, reject) {
                    Axios
                        .post(base.CreateUrl, {
                            Name: base.Name,
                            Code: base.Code,
                            Address: base.Address,
                            Discount: parseInt(base.Discount)
                        })
                        .then(res => { window.location.href = base.IndexUrl; })
                        .catch(error => { console.log(error); });
                });
            }
        }
    };
</script>