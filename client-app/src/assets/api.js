//import { ref, isRef, unref, watchEffect } from 'vue'


export function getItem(id, onSuccess) {
    doFetch(`/API/40Fingers/EmptyModuleVue3/Item/GetItem?itemid=${id}`, undefined, undefined, onSuccess);
}

export function getItems(onSuccess) {
    doFetch(`/API/40Fingers/EmptyModuleVue3/Item/GetList`, undefined, undefined, onSuccess);
}

export function saveItem(item, onSuccess) {
    doFetch(`/API/40Fingers/EmptyModuleVue3/Item/Save`, { method: "POST" }, item, onSuccess);
}

function doFetch(url, setOptions, data, onSuccess) {
    // default options
    let options = {
        method: "GET",
        // headers go here
        headers: {
            'Content-Type': 'application/json'
        },
        body: data ? JSON.stringify(data) : null
    };
    if (setOptions) {
        options = { ...options, ...setOptions };
    }
    console.log(options);
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
