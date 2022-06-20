<template>
    <div>
        <h1>Client</h1>
        <table class="table table-hover">
            <thead>
                <tr class="d-flex">
                    <th class="col-3"></th>
                    <th class="col-2">Id</th>
                    <th class="col-6">Name</th>
                </tr>
            </thead>
            <tbody v-for="item in items" :key="item.id">
                <tr class="d-flex">
                    <td class="col-3">
                        <button type="button" class="btn btn-secondary mr-1" data-toggle="modal" :data-target="`#itemEditModal`" @click="editItemId=item.id">View</button>
                        <button type="button" class="btn btn-secondary">Edit</button>
                    </td>
                    <td class="col-2">{{ item.id }}</td>
                    <td class="col-6">{{ item.name }}</td>
                </tr>
            </tbody>
        </table>
        <div id="itemEdit">
            <ItemEdit v-if="editItemId" :itemId="editItemId" />
        </div>
        <div v-if="error">
            {{error}}
        </div>
    </div>
</template>

<script setup>
    import { ref } from 'vue';
    import { getItems } from "../assets/api";
    import ItemEdit from './ItemEdit.vue';

    const { items, error } = getItems();
    const editItemId = ref(null);

    // https://vuejs.org/api/composition-api-lifecycle.html
    //onMounted(() => { })

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
