<template>
    <div class="modal" tabindex="-1" :id="`itemEditModal-${dnnConfig.moduleId}`">
        <div class="modal-dialog">
            <div class="modal-content" v-if="item">
                <div class="modal-header">
                    <h5 class="modal-title">{{item.name}}</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="itemId">{{resx.ItemIdLabel}}</label>
                        <input type="text" class="form-control" id="itemId" v-model="item.id" readonly>
                    </div>
                    <div class="form-group">
                        <label for="itemName">{{resx.ItemNameLabel}}</label>
                        <input type="text" class="form-control" id="itemName" v-model="item.name" :readonly="itemOptions.editMode === false">
                    </div>
                    <div class="form-group form-check">
                        <label for="itemDescription">{{resx.ItemDescriptionLabel}}</label>
                        <textarea class="form-control" id="itemDescription" v-model="item.description" :readonly="itemOptions.editMode === false"></textarea>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" v-if="itemOptions.editMode" @click="doDeleteItem()">{{resx.Delete}}</button>
                    <button type="button" class="btn btn-primary" v-if="itemOptions.editMode" @click="doSaveItem()">{{resx.Save}}</button>
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">{{resx.Close}}</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup>
    import { defineEmits, defineProps, inject, onMounted, ref, toRef, watch } from 'vue';
    import { deleteItem, getItem, saveItem } from "../assets/api";

    // define the properties to be passed into this component
    const props = defineProps(["itemOptions"]);
    const emit = defineEmits(["change", "delete"]);

    const dnnConfig = inject("dnnConfig");
    const resx = inject("resx");
    const $ = inject("jQuery");

    // create a ref for the props we need to watch
    const itemOptions = toRef(props, "itemOptions");

    // create refs for reactive data items
    const item = ref(null);

    let hideModal;
    let showModal;

    // fetch initial data
    // https://vuejs.org/api/composition-api-lifecycle.html
    onMounted(() => {
        hideModal = function () {
            $(`#itemEditModal-${dnnConfig.moduleId}`).modal('hide');
        }
        showModal = function () {
            $(`#itemEditModal-${dnnConfig.moduleId}`).modal('show');
        }
        refreshItem()
    });

    // add watch for the ref we just created
    // this will get triggered when the ref.value changes
    watch(itemOptions, (newOptions, prvOptions) => {
        refreshItem();
    });

    // function to fetch data
    function refreshItem() {
        getItem(dnnConfig, itemOptions.value.itemId, (resp) => {
            item.value = resp;
            showModal();
        });
    }

    // save data
    function doSaveItem() {
        saveItem(dnnConfig, item.value, (resp) => {
            hideModal();
            emit("change");
        });
    }
    function doDeleteItem() {
        deleteItem(dnnConfig, item.value.id, (resp) => {
            hideModal();
            emit("change");
        });
    }
</script>

<script>
    export default {
        name: 'ItemDetail',
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
