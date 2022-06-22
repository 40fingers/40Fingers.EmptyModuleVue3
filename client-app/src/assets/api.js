//import { ref, isRef, unref, watchEffect } from 'vue'


export function getItem(dnnConfig, id, onSuccess) {
    doFetch(dnnConfig, `${dnnConfig.apiBaseUrl}/Item/GetItem?itemid=${id}`, undefined, undefined, onSuccess);
}

export function getItems(dnnConfig, onSuccess) {
    doFetch(dnnConfig, `${dnnConfig.apiBaseUrl}/Item/GetList`, undefined, undefined, onSuccess);
}

export function saveItem(dnnConfig, item, onSuccess) {
    doFetch(dnnConfig, `${dnnConfig.apiBaseUrl}/Item/Save`, { method: "POST" }, item, onSuccess);
}

function doFetch(dnnConfig, url, setOptions, data, onSuccess) {
    // default options
    let options = {
        method: "GET",
        // headers go here
        headers: {
            'Content-Type': 'application/json',
            "moduleid": dnnConfig.moduleId,
            "tabid": dnnConfig.tabId,
            "RequestVerificationToken": dnnConfig.rvt,
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
        });
}
