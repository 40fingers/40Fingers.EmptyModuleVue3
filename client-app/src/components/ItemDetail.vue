<template>
    <div class="modal" tabindex="-1" id="itemEditModal">
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
                        <label for="itemId">Item Id</label>
                        <input type="text" class="form-control" id="itemId" v-model="item.id" readonly>
                    </div>
                    <div class="form-group">
                        <label for="itemName">Name</label>
                        <input type="text" class="form-control" id="itemName" v-model="item.name" :readonly="itemOptions.editMode === false">
                    </div>
                    <div class="form-group form-check">
                        <label for="itemDescription">Description</label>
                        <textarea class="form-control" id="itemDescription" v-model="item.description" :readonly="itemOptions.editMode === false"></textarea>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" v-if="itemOptions.editMode" @click="doSaveItem()">Save</button>
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup>
    import { defineEmits, defineProps, onMounted, ref, toRef, watch } from 'vue';
    import { getItem, saveItem } from "../assets/api";

    // define the properties to be passed into this component
    const props = defineProps(["itemOptions"]);
    const emit = defineEmits(["change", "delete"]);

    // create a ref for the props we need to watch
    const itemOptions = toRef(props, "itemOptions");

    // create refs for reactive data items
    const item = ref(null);

    let hideModal;

    // fetch initial data
    // https://vuejs.org/api/composition-api-lifecycle.html
    onMounted(() => {
        hideModal = function () {
            window.$("#itemEditModal").modal('hide');
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
        getItem(itemOptions.value.itemId, (resp) => {
            item.value = resp;
        });
    }

    // save data
    function doSaveItem() {
        saveItem(item.value, (resp) => {
            console.log("saved");
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
