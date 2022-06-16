<template>
    <SettingsPage moduleId="0" tabId="0" />
</template>

<script>
    import SettingsPage from './components/SettingsPage.vue'

    export default {
        name: 'App',
        components: {
            SettingsPage
        },
        mounted: function () {
            this.moduleid = Number(this.$refs.approot.parentNode.attributes["data-moduleid"].nodeValue);
            this.tabid = Number(this.$refs.approot.parentNode.attributes["data-tabid"].nodeValue);
        }
    }
</script>

<style>
</style>
