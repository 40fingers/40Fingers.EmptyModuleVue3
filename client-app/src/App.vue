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
        data: function () {
            return {
                moduleid: 0,
                tabid: 0,
                dnnEditMode: false,
            }
        },
        mounted: function () {
            this.moduleid = Number(this.$el.parentNode.attributes["data-moduleid"].nodeValue);
            this.tabid = Number(this.$el.parentNode.attributes["data-tabid"].nodeValue);
            this.dnnEditMode = this.$el.parentNode.attributes["data-editmode"].nodeValue.toLowerCase() === "true";
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
