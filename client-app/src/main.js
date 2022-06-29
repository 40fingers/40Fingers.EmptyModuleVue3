import { createApp } from 'vue'
import App from './App.vue'
import { getConfig, getResx } from "./assets/api";

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

        // we need to be able register callbackMethods for dataTables on window level, 
        // so we can call it from an event that Vue knows nothing about
        // here we make sure the array exists, so we can use it from a component
        if (window.dtCallBacks === undefined) {
            window.dtCallBacks = [];
        }

        // TODO: This would be much nicer using promises
        getConfig(dnnConfig,
            function(resp) {
                app.provide("moduleConfig", resp);

                getResx(dnnConfig,
                    "View",
                    (resx) => {
                        app.provide("dnnConfig", dnnConfig);
                        app.provide("resx", resx);
                        app.provide("window", window);
                        app.provide("jQuery", window.$);
                        app.mount(`#${thisAppElm.id}`);
                    }
                );
            }
        );

    }
};

