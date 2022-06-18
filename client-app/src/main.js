import { createApp } from 'vue'
import App from './App.vue'

const allAppElements = document.getElementsByClassName("appEmptyModuleVue3");
for (var i = 0; i < allAppElements.length; i++) {
    const app = createApp(App);
    app.config.devtools = true;
    app.mount(`#${allAppElements[i].id}`);
}

