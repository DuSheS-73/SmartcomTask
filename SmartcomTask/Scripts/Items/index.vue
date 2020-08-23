<template>
    <div class="items">

        <h1>Каталог товаров</h1>

        <div class="display__flex">

            <div class="filter__block">
                <div class="filter__inner">

                    <h3>Фильтр</h3>

                    <div v-if="isAdmin" class="filter__group">
                        <h4>Админ</h4>
                        <a :href="CreateUrl" class="edit__btn">Добавить товар</a>
                    </div>

                    <div class="filter__group">   
                        <h4 @click="extendSection(0)" class="clickable">Категория <i class="fas" v-bind:class="[expandableMenus[0].visible ? 'fa-angle-down' : 'fa-angle-right']"></i></h4>

                        <div v-bind:class="[expandableMenus[0].visible ? 'visible' : 'hidden']" >

                            <a v-for="category in categories" v-bind:class="{'active__filter': category.isSelected}"
                               class="clickable" @click="selectCategoryOption(categories.indexOf(category))">{{ category.name }}</a>

                        </div>
                    </div>

                    <div class="filter__group">
                        <h4 @click="extendSection(1)" class="clickable">Цена <i class="fas" v-bind:class="[expandableMenus[1].visible ? 'fa-angle-down' : 'fa-angle-right']"></i></h4>

                        <div v-bind:class="[expandableMenus[1].visible ? 'visible' : 'hidden']" >
                            <input v-model="priceFrom" type="text" placeholder="от">
                            <input v-model="priceTo" type="text" placeholder="до">
                        </div>
                    </div>

                    <div class="apply__block">
                        <a @click="applyFilterRef" class="btn red">Применить</a>
                    </div>
                </div>
            </div>
            
            <item-blocks-component ref="ItemBlock"
                                   :is-admin="isAdmin"
                                   :items-url="ItemsUrl"
                                   :edit-url="EditUrl"
                                   :create-url="CreateUrl"
                                   :delete-url="DeleteUrl"
                                   :add-to-cart-url="AddToCartUrl"
                                   :apply-filter-url="ApplyFilterUrl"></item-blocks-component>
        </div>
    </div>
</template>

<script>
import Axios from "axios";
import ItemsComponent from "./item_blocks.vue";

    export default {
        components: {
            'item-blocks-component': ItemsComponent
        },

        props: {
            isAdmin: Boolean,
            ItemsUrl: String,
            EditUrl: String,
            CreateUrl: String,
            DeleteUrl: String,
            AddToCartUrl: String,
            ApplyFilterUrl: String
        },
        data() {
            return {
                expandableMenus: [
                    {
                        visible: false
                    },
                    {
                        visible: false
                    }
                ],

                categories: [
                    {
                        name: 'Категория_1',
                        isSelected: false
                    },
                    {
                        name: 'Категория_2',
                        isSelected: false
                    },
                    {
                        name: 'Категория_3',
                        isSelected: false
                    },
                    {
                        name: 'Категория_4',
                        isSelected: false
                    },
                    {
                        name: 'Категория_5',
                        isSelected: false
                    },
                ],

                categoryOption: '',
                priceFrom: 0,
                priceTo: 50000
            }
        },

        methods: {
            extendSection(index) {
                var element = this.expandableMenus[index];
                element.visible ? element.visible = false : element.visible = true;
            },

            applyFilterRef() {
                var base = this;

                var filterOptions = {
                    Category: base.categoryOption,
                    PriceFrom: parseInt(base.priceFrom),
                    PriceTo: parseInt(base.priceTo)
                }

                base.$refs['ItemBlock'].applyFilter(filterOptions);
            },

            selectCategoryOption(index) {

                this.categories.forEach(category => { category.isSelected = false });

                if (this.categories[index].isSelected) {
                    this.categoryOption = '';
                    this.categories[index].isSelected = false;
                }
                else {
                    this.categoryOption = this.categories[index].name;
                    this.categories[index].isSelected = true;
                }
            }
        }
    };
</script>