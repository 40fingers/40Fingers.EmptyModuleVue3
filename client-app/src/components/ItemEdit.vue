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
                        <input type="text" class="form-control" id="itemId" v-model="item.name" readonly>
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
    </div></template>

<script setup>
    import { defineProps } from 'vue';
    import { getItem } from "../assets/api";

    //import { ref, onMounted } from 'vue';

    //const data = getDataFromApi();

    // https://vuejs.org/api/composition-api-lifecycle.html
    //onMounted(() => {});

    const props = defineProps(["itemId"]);

    //const { itemId } = toRefs(props);

    const {item} = getItem(props.itemId);

    //const item = ref(null);
    //watch(itemId, (newItemId, prvItemId) => {
    //    const newData = getItem(props.itemId);
    //    console.log(`new value for item: ${JSON.stringify(newData.item)}`)
    //    item.value = newData.item;
    //});

</script>

<script>
    export default {
        name: 'ItemEdit',
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
