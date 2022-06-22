<template>
    <div>
        <h1>Client</h1>
        <table class="table table-hover">
            <thead>
                <tr class="d-flex">
                    <th class="col-3">
                        <button type="button" class="btn btn-secondary mr-1" data-toggle="modal" :data-target="`#itemEditModal`" @click="openItem(0, true)">New</button>
                    </th>
                    <th class="col-2">Id</th>
                    <th class="col-7">Name</th>
                </tr>
            </thead>
            <tbody v-for="item in items" :key="item.id">
                <tr class="d-flex">
                    <td class="col-3">
                        <button type="button" class="btn btn-secondary mr-1" data-toggle="modal" :data-target="`#itemEditModal`" @click="openItem(item.id, false)">View</button>
                        <button type="button" class="btn btn-secondary" data-toggle="modal" :data-target="`#itemEditModal`"  @click="openItem(item.id, true)">Edit</button>
                    </td>
                    <td class="col-2">{{ item.id }}</td>
                    <td class="col-7">{{ item.name }}</td>
                </tr>
            </tbody>
        </table>
        <div id="itemEdit">
            <ItemDetail 
                v-if="itemOptions" 
                v-on:change="loadData()"
                :itemOptions="itemOptions" />
        </div>
    </div>
</template>

<script setup>
    import { onMounted, ref } from 'vue';
    import { getItems } from "../assets/api";
    import ItemDetail from './ItemDetail.vue';

    const items = ref(null);
    const itemOptions = ref(null);

    // https://vuejs.org/api/composition-api-lifecycle.html
    onMounted(() => {
        loadData();
    })

    function loadData() {
        getItems((resp) => {
            items.value = resp;
        });
    }

    function openItem(id, editMode) {
        itemOptions.value = { itemId: id, editMode };
    }

</script>

<script>
    export default {
        name: 'ItemList',
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    h3 {
        margin: 40px 0 0;
    }

    ul {
        list-style-type: disc;
        padding: 0;
    }

    li {
        margin: 0 10px;
    }

    a {
        color: #42b983;
    }
</style>
