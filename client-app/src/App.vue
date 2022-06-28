<template>
    <div class="text-left d-none">
        <div class="custom-control custom-switch">
            <input type="checkbox" class="custom-control-input" id="showList" v-bind="showList">
            <label class="custom-control-label" for="showList">Show List</label>
        </div>
        <div class="custom-control custom-switch">
            <input type="checkbox" class="custom-control-input" id="switchDatatable" v-bind="showDatatable">
            <label class="custom-control-label" for="switchDatatable">Show Datatable</label>
        </div>
    </div>
    <ItemList v-if="showList" />
    <ItemDatatable v-if="showDatatable" :serverSide="true"/>
</template>

<script setup>
</script>

<script>
    import ItemList from './components/ItemList.vue';
    import ItemDatatable from './components/ItemDatatable.vue';

    export default {
        name: 'App',
        components: {
            ItemDatatable, ItemList
        },
        data: function() {
            return { showList: false, showDatatable: true };
        }
        // you can access the instance as the function's first argument
        // data: (inst) => { return { field: inst.someProp }; }
        // or use
        // data: () => { return { bla: 0, blo: true } }
    }
</script>

<style>
    .appEmptyModuleVue3 {
        font-family: Avenir, Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
        margin-top: 60px;
    }
</style>
