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
                        <th class="text-right">
                            <button type="button" class="btn btn-secondary mr-1" @click="openItem(0, true)">{{resx.Add}}</button>
                        </th>
                    </tr>
                </thead>
            </table>
        </div>
        <div id="itemEdit">
            <ItemDetail v-if="itemOptions"
                        :key="itemOptions.itemId"
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

    let dtId;
    let dtSel;
    let openItemCallbackIndex;

    const dnnConfig = inject("dnnConfig");
    const resx = inject("resx");
    const window = inject("window");
    const $ = inject("jQuery");

    // https://vuejs.org/api/composition-api-lifecycle.html
    onMounted(function() {
        dtId = `dt-${dnnConfig.moduleId}`;
        dtSel = `#${dtId}`;

        // we add our openItem functions to it, and keep the index (which is index minus 1)
        openItemCallbackIndex = window.dtCallBacks.push(openItem) - 1;

        loadData();
    })

    function openItem(id, editMode) {
        console.log(`called openItem(${id}, ${editMode})`);
        itemOptions.value = { itemId: id, editMode };
    }

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
                    ],
                    columnDefs: [
                        { targets: [0, 1, 2], className: "text-left" },
                        { targets: [3], visible: false },
                        { 
                            targets: [4],
                            className: "text-right",
                            render: function (data, type, row, meta) {
                                return `<button type="button" class="btn btn-secondary mr-1" data-method="openItem" data-edit="false" data-cbckix="${openItemCallbackIndex}" data-id="${row.id}">${resx.View}</button>`
                                    + `<button type="button" class="btn btn-secondary" data-method="openItem" data-edit="true" data-cbckix="${openItemCallbackIndex}" data-id="${row.id}">${resx.Edit}</button>`;
                            }
                        }
                    ],
                    drawCallback: function (settings) {
                        console.log("before draw");
                        $(`${dtSel} button[data-method="openItem"]`).on("click", function () {
                            const id = $(this).attr("data-id");
                            const edit = $(this).attr("data-edit") == "true";
                            const ix = Number($(this).attr("data-cbckix"));
                            console.log(`calling openItem(${id}, true) on window.dtCallbacks[${ix}] (it has ${window.dtCallBacks?.length})`);
                            // here we're calling into the Vue component from the outside, so we're doing that through the array we manage above
                            const fn = window.dtCallBacks[ix];
                            console.log(`fn = ${typeof(fn)}`);
                            fn(id, edit);
                        });
                    }
                });
            }
        });
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
