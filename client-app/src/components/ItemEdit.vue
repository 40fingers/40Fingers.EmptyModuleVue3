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
                        <input type="text" class="form-control" id="itemName" v-model="item.name">
                    </div>
                    <div class="form-group form-check">
                        <label for="itemDescription">Description</label>
                        <textarea class="form-control" id="itemDescription" v-model="item.description"></textarea>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save</button>
                </div>
            </div>
        </div>
    </div>
    <div v-if="error">
        {{itemdata.error}}
    </div>
</template>

<script setup>
    import { defineProps, onMounted, ref, toRef, watch } from 'vue';
    import { getItem } from "../assets/api";

    // define the properties to be passed into this component
    const props = defineProps(["itemId"]);

    // create a ref for the props we need to watch
    const editItemId = toRef(props, "itemId");

    // create refs for reactive data items
    const item = ref(null);

    // fetch initial data
    // https://vuejs.org/api/composition-api-lifecycle.html
    onMounted(() => {
        refreshItem()
    });

    // add watch for the ref we just created
    // this will get triggered when the ref.value changes
    watch(editItemId, (newItemId, prvItemId) => {
        refreshItem();
    });

    // function to fetch data
    function refreshItem() {
        getItem(editItemId.value, (resp) => {
            item.value = resp;
        });
    }

</script>

<script>
    export default {
        name: 'ItemEdit',
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
