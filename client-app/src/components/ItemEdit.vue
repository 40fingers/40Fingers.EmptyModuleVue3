<template>
    <div class="modal" tabindex="-1" id="itemEditModal">
        <div class="modal-dialog">
            <div class="modal-content" v-if="itemdata.item">
                <div class="modal-header">
                    <h5 class="modal-title">{{itemdata.item.name}}</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="itemId">Item Id</label>
                        <input type="text" class="form-control" id="itemId" v-model="itemdata.item.id" readonly>
                    </div>
                    <div class="form-group">
                        <label for="itemName">Name</label>
                        <input type="text" class="form-control" id="itemName" v-model="itemdata.item.name">
                    </div>
                    <div class="form-group form-check">
                        <label for="itemDescription">Description</label>
                        <textarea class="form-control" id="itemDescription" v-model="itemdata.item.description"></textarea>
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
    import { computed, defineProps } from 'vue';
    //import { ref, onMounted } from 'vue';
    import { baseUrls, useFetch } from "../assets/api";

    const props = defineProps(["itemId"]);
    const editItemId = computed(() => props.itemId);

    const url = computed(() => `${baseUrls.getItem}${editItemId.value}`);

    const itemdata = useFetch(url);

    //const { itemId } = toRefs(props);
    //const initialItem = getItem(props.itemId).item;
    //const item = ref(initialItem);

    //watch(itemId, (newItemId, prvItemId) => {
    //    console.log(`change value for item to ${newItemId}`);
    //    //const newItem = JSON.parse(JSON.stringify(item.value));
    //    //newItem.id = newItemId;
    //    const newItem = getItem(newItemId).item;
    //    console.log(`new item: ${JSON.stringify(newItem.value)}`);
    //    item.value = newItem.value;
    //    console.log(`new item value: ${JSON.stringify(item.value)}`);
    //});

    //const item = computed(() => {
    //    const newData = getItem(props.itemId).item;
    //    console.log(`new value for item: ${JSON.stringify(newData)}`)
    //    return newData;
    //})

    //const data = getDataFromApi();

    // https://vuejs.org/api/composition-api-lifecycle.html
    //onMounted(() => {});


    //const { itemId } = toRefs(props);

    //const {item} = getItem(props.itemId);

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
