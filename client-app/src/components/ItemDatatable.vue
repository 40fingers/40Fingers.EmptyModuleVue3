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
                            <button type="button" class="btn btn-secondary mr-1 d-none" @click="openItem(0, true)" :id="`dtAddButton-${dnnConfig.moduleId}`">{{resx.Add}}</button>
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
    import { defineProps, inject, onMounted, ref, watch } from 'vue';
    import { getItems } from "../assets/api";
    import ItemDetail from './ItemDetail.vue';

    const props = defineProps(["serverSide"]);
    const items = ref(null);
    const itemOptions = ref(null);
    const canEdit = ref(false); // `dtAddButton-${dnnConfig.moduleId}`

    // add watch for canEdit
    // this will get triggered when the canEdit.value changes
    // needed to show/hide the button manually, since it is inside of datatables and not managed by Vue
    watch(canEdit, (newValue, prvValue) => {
        if (newValue) {
            $(`#dtAddButton-${dnnConfig.moduleId}`).removeClass("d-none");
        } else {
            $(`#dtAddButton-${dnnConfig.moduleId}`).removeClass("d-none");
        }
    });

    let dtId;
    let dtSel;
    let openItemCallbackIndex;

    const dnnConfig = inject("dnnConfig");
    const resx = inject("resx");
    const window = inject("window");
    const $ = inject("jQuery");

    // https://vuejs.org/api/composition-api-lifecycle.html
    onMounted(function () {
        dtId = `dt-${dnnConfig.moduleId}`;
        dtSel = `#${dtId}`;

        // we add our openItem functions to it, and keep the index (which is index minus 1)
        openItemCallbackIndex = window.dtCallBacks.push(openItem) - 1;
        console.log("onMounted.loadData");
        loadData();
    })

    function openItem(id, editMode) {
        itemOptions.value = { itemId: id, editMode };
    }

    function loadData() {
        // for serverside processing, we just instanciate the table
        // otherwise we do that when we have data
        if (props.serverSide) {
            if ($.fn.DataTable.isDataTable(dtSel)) {
                let dt = $(dtSel).DataTable();
                dt.ajax.reload();
            } else {
                $(`#dt-${dnnConfig.moduleId}`).DataTable(getDtOptions());
            }
        } else {
            getItems(dnnConfig, (resp) => {
                console.log("getitems done");
                items.value = resp.items; // give the items to the vue app too, in case we need them for something outside of datatables
                canEdit.value = resp.canEdit;

                if ($.fn.DataTable.isDataTable(dtSel)) {
                    let dt = $(dtSel).DataTable();
                    dt.clear();
                    dt.rows.add(resp);
                    dt.draw();
                } else {
                    let dtoptions = getDtOptions();
                    dtoptions["data"] = resp.items;

                    $(`#dt-${dnnConfig.moduleId}`).DataTable(dtoptions);
                }
            });
        }

        function getDtOptions() {
            let dtoptions = {
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
                            let retval = `<button type="button" class="btn btn-secondary mr-1" data-method="openItem" data-edit="false" data-cbckix="${openItemCallbackIndex}" data-id="${row.id}">${resx.View}</button>`;
                            if (canEdit.value) {
                                retval += `<button type="button" class="btn btn-secondary" data-method="openItem" data-edit="true" data-cbckix="${openItemCallbackIndex}" data-id="${row.id}">${resx.Edit}</button>`;
                            }
                            return retval;
                        }
                    }
                ],
                drawCallback: function (settings) {
                    $(`${dtSel} button[data-method="openItem"]`).on("click", function () {
                        const id = $(this).attr("data-id");
                        const edit = $(this).attr("data-edit") == "true";
                        const ix = Number($(this).attr("data-cbckix"));
                        // here we're calling into the Vue component from the outside, so we're doing that through the array we manage above
                        const fn = window.dtCallBacks[ix];
                        fn(id, edit);
                    });
                }
            }
            if (props.serverSide) {
                dtoptions = {
                    ...dtoptions,
                    ...{
                        processing: true,
                        serverSide: true,
                        ajax: `${dnnConfig.apiBaseUrl}/Datatables/Processing`,
                    }
                }
            } else {
            //    dtoptions = {
            //        ...dtoptions,
            //        ...{
            //        }
            //    }
            }
            return dtoptions;
        }
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
