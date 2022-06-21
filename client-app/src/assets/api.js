//import { ref, isRef, unref, watchEffect } from 'vue'


export function getItem(id, onSuccess) {
    doFetch(`/API/40Fingers/EmptyModuleVue3/Item/GetItem?itemid=${id}`, onSuccess);
}

export function getItems(onSuccess) {
    doFetch(`/API/40Fingers/EmptyModuleVue3/Item/GetList`, onSuccess);
}

function doFetch(url, onSuccess) {
    const options = {
        method: "GET",
        // headers go here
    };
    const req = new Request(url);
    
    fetch(req, options)
        .then((response) => {
            if (response.status === 200) {
              return response.json();
            }
        })
        .then((json) => {
            if (typeof (onSuccess) == "function") {

                onSuccess(typeof(json) === "string" ? JSON.parse(json) : json);
            }
        })
}
