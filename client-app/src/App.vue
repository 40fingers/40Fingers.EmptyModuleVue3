<template>
    <ClientPage />
</template>

<script setup>
    //import { onMounted } from 'vue';

    //onMounted(() => {
    //})
</script>

<script>
    import ClientPage from './components/ClientPage.vue';
    export default {
        name: 'App',
        components: {
            ClientPage
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
