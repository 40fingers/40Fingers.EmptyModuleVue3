<template>
    <div>
        <h1>{{resx.ModuleName}}</h1>
        <table class="table table-hover">
            <thead>
                <tr class="d-flex">
                    <th class="col-3">
                        <button type="button" class="btn btn-secondary mr-1" :id="`lstAddButton-${dnnConfig.moduleId}`" @click="openItem(0, true)" v-if="canEdit">{{resx.Add}}</button>
                    </th>
                    <th class="col-2">{{resx.ItemIdLabel}}</th>
                    <th class="col-7">{{resx.ItemNameLabel}}</th>
                </tr>
            </thead>
            <tbody v-for="item in items" :key="item.id">
                <tr class="d-flex">
                    <td class="col-3">
                        <button type="button" class="btn btn-secondary mr-1" @click="openItem(item.id, false)">{{resx.View}}</button>
                        <button type="button" class="btn btn-secondary"  @click="openItem(item.id, true)" v-if="canEdit">{{resx.Edit}}</button>
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
    import { inject , onMounted, ref } from 'vue';
    import { getItems } from "../assets/api";
    import ItemDetail from './ItemDetail.vue';

    const items = ref(null);
    const itemOptions = ref(null);
    const canEdit = ref(false);

    const dnnConfig = inject("dnnConfig");
    console.log("injecting resx");
    const resx = inject("resx");


    // https://vuejs.org/api/composition-api-lifecycle.html
    onMounted(function() {
        console.log(dnnConfig);
        loadData();
    })

    function loadData() {
        getItems(dnnConfig, (resp) => {
            canEdit.value = resp.canEdit;
            items.value = resp.items;
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
