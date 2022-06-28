<template>
    <div>
        <h1>DataTables.net {{resx.ModuleName}}</h1>
        <div v-once>
            <table class="table table-hover" :id="`dt-${dnnConfig.moduleId}`">
                <thead>
                    <tr>
                        <th>{{resx.ItemIdLabel}}</th>
                        <th>{{resx.ItemNameLabel}}</th>
                        <th>Description</th>
                        <th>User</th>
                        <th>
                            <button type="button" class="btn btn-secondary mr-1" data-toggle="modal" :data-target="`#itemEditModal`" @click="openItem(0, true)">{{resx.Add}}</button>
                        </th>
                    </tr>
                </thead>
            </table>
        </div>
        <div id="itemEdit">
            <ItemDetail v-if="itemOptions"
                        v-on:change="loadData()"
                        :itemOptions="itemOptions" />
        </div>
    </div>
</template>

<script setup>
    import { inject , onMounted, ref } from 'vue';
    import { getItems } from "../assets/api";
    import ItemDetail from './ItemDetail.vue';

    const $ = window.$;
    const items = ref(null);
    const itemOptions = ref(null);

    let dtId;
    let dtSel;

    const dnnConfig = inject("dnnConfig");
    const resx = inject("resx");

    // https://vuejs.org/api/composition-api-lifecycle.html
    onMounted(function() {
        dtId = `dt-${dnnConfig.moduleId}`;
        dtSel = `#${dtId}`;
        loadData();
    })

    function loadData() {
        getItems(dnnConfig, (resp) => {
            items.value = resp;
            if ($.fn.DataTable.isDataTable(dtSel)) {
                let dt = $(dtSel).DataTable();
                dt.clear();
                dt.rows.add(resp);
                dt.draw();
            } else {
                $(`#dt-${dnnConfig.moduleId}`).DataTable({
                    "data": resp,
                    "columns": [
                        { "data": "id" },
                        { "data": "name" },
                        { "data": "description" },
                        { "data": "assignedUser" },
                        { "data": "editUrl" },
                    ]
                });
            }
        });
    }

    function openItem(id, editMode) {
        itemOptions.value = { itemId: id, editMode };
    }

</script>

<script>
    export default {
        name: 'ItemDatatable',
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
