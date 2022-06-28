<template>
    <ItemList v-if="false" />
    <ItemDatatable />
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
