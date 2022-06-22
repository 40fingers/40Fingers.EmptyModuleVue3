import { createApp } from 'vue'
import App from './App.vue'


const allAppElements = document.getElementsByClassName("appEmptyModuleVue3");
window.onload = function () {
    for (var i = 0; i < allAppElements.length; i++) {
        const app = createApp(App);
        app.config.devtools = true;

        const thisAppElm = allAppElements[i];

        // https://vuejs.org/api/application.html#app-config-globalproperties
        app.provide("dnnConfig",
            {
                tabId: Number(thisAppElm.getAttribute("data-tabid")),
                moduleId: Number(thisAppElm.getAttribute("data-moduleid")),
                editMode: thisAppElm.getAttribute("data-editmode").toLowerCase() === "true",
                apiBaseUrl: thisAppElm.getAttribute("data-apibaseurl"),
                rvt: window.$("input[name='__RequestVerificationToken']").val()
            });
        //app.config.globalProperties.dnnConfig = {
        //    tabId: Number(thisAppElm.getAttribute("data-tabid")),
        //    moduleId: Number(thisAppElm.getAttribute("data-moduleid")),
        //    editMode: thisAppElm.getAttribute("data-editmode").toLowerCase() === "true",
        //    apiBaseUrl: thisAppElm.getAttribute("data-apibaseurl"),
        //};

        //app.config.globalProperties.tabid = thisAppElm.getAttribute("data-tabid");
        //app.config.globalProperties.moduleid = thisAppElm.getAttribute("data-moduleid");
        //app.config.globalProperties.editmode = thisAppElm.getAttribute("data-editmode");

        app.mount(`#${thisAppElm.id}`);
    }
};

