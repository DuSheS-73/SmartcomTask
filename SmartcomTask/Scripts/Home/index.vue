<template>
    <div class="home">
        <h1>Новики</h1>
        <item-blocks-component :is-admin="isAdmin"
                        :items-url="ItemsUrl"
                        :edit-url="EditUrl"
                        :create-url="CreateUrl"
                        :delete-url="DeleteUrl"
                        :add-to-cart-url="AddToCartUrl"></item-blocks-component>
        <a :href="ItemsPageUrl" class="btn red">Показать все</a>
    </div>
</template>

<script>
import ItemComponent from "../Items/item_blocks.vue";

    export default {
        components: {
            'item-blocks-component': ItemComponent
        },

        props: {
            isAdmin: Boolean,
            ItemsUrl: String,
            EditUrl: String,
            CreateUrl: String,
            DeleteUrl: String,
            AddToCartUrl: String,
            ItemsPageUrl: String
        }
    };
</script>