import { createApp } from 'vue'
import App from './App.vue'

const allAppElements = document.getElementsByClassName("appEmptyModuleVue3");
for (var i = 0; i < allAppElements.length; i++) {
    const app = createApp(App);
    app.config.devtools = true;

    const thisAppElm = allAppElements[i];

    // https://vuejs.org/api/application.html#app-config-globalproperties
    app.config.globalProperties.tabid = thisAppElm.getAttribute("data-tabid");
    app.config.globalProperties.moduleid = thisAppElm.getAttribute("data-moduleid");
    app.config.globalProperties.editmode = thisAppElm.getAttribute("data-editmode");

    app.mount(`#${thisAppElm.id}`);
}

