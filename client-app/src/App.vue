<template>
    <ItemList />
</template>

<script setup>
    //import { onMounted } from 'vue';

    //onMounted(() => {
    //})
</script>

<script>
    import ItemList from './components/ItemList.vue';
    export default {
        name: 'App',
        components: {
            ItemList
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
