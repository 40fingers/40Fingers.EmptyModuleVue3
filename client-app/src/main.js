import { createApp } from 'vue'
import App from './App.vue'
import { getResx } from "./assets/api";

const allAppElements = document.getElementsByClassName("appEmptyModuleVue3");

window.onload = function () {
    for (var i = 0; i < allAppElements.length; i++) {
        const app = createApp(App);
        app.config.devtools = true;

        const thisAppElm = allAppElements[i];

        const dnnConfig = {
            tabId: Number(thisAppElm.getAttribute("data-tabid")),
            moduleId: Number(thisAppElm.getAttribute("data-moduleid")),
            editMode: thisAppElm.getAttribute("data-editmode").toLowerCase() === "true",
            apiBaseUrl: thisAppElm.getAttribute("data-apibaseurl"),
            rvt: window.$("input[name='__RequestVerificationToken']").val()
        };

        getResx(dnnConfig,
            "View",
            (resx) => {
                // https://vuejs.org/api/application.html#app-config-globalproperties
                app.provide("dnnConfig", dnnConfig);
                app.provide("resx", resx);

                app.mount(`#${thisAppElm.id}`);

            });
    }
};

