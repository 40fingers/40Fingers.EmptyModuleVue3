<template>
    <ClientPage />
</template>

<script>
    import ClientPage from './components/ClientPage.vue'

    export default {
        name: 'App',
        components: {
            ClientPage
        },
        mounted: function () {
            this.moduleid = Number(this.$refs.approot.parentNode.attributes["data-moduleid"].nodeValue);
            this.tabid = Number(this.$refs.approot.parentNode.attributes["data-tabid"].nodeValue);
            this.dnnEditMode = this.$refs.approot.parentNode.attributes["data-editmode"].nodeValue.toLowerCase() === "true";
        }
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
