// https://vuejs.org/guide/reusability/composables.html#async-state-example
// https://sfc.vuejs.org/#eyJBcHAudnVlIjoiPHNjcmlwdCBzZXR1cD5cbmltcG9ydCB7IHJlZiwgY29tcHV0ZWQgfSBmcm9tICd2dWUnXG5pbXBvcnQgeyB1c2VGZXRjaCB9IGZyb20gJy4vdXNlRmV0Y2guanMnXG5cbmNvbnN0IGJhc2VVcmwgPSAnaHR0cHM6Ly9qc29ucGxhY2Vob2xkZXIudHlwaWNvZGUuY29tL3RvZG9zLydcbmNvbnN0IGlkID0gcmVmKCcxJylcbmNvbnN0IHVybCA9IGNvbXB1dGVkKCgpID0+IGJhc2VVcmwgKyBpZC52YWx1ZSlcblxuY29uc3QgeyBkYXRhLCBlcnJvciwgcmV0cnkgfSA9IHVzZUZldGNoKHVybClcbjwvc2NyaXB0PlxuXG48dGVtcGxhdGU+XG4gIExvYWQgcG9zdCBpZDpcbiAgPGJ1dHRvbiB2LWZvcj1cImkgaW4gNVwiIEBjbGljaz1cImlkID0gaVwiPnt7IGkgfX08L2J1dHRvbj5cblxuXHQ8ZGl2IHYtaWY9XCJlcnJvclwiPlxuICAgIDxwPk9vcHMhIEVycm9yIGVuY291bnRlcmVkOiB7eyBlcnJvci5tZXNzYWdlIH19PC9wPlxuICAgIDxidXR0b24gQGNsaWNrPVwicmV0cnlcIj5SZXRyeTwvYnV0dG9uPlxuICA8L2Rpdj5cbiAgPGRpdiB2LWVsc2UtaWY9XCJkYXRhXCI+RGF0YSBsb2FkZWQ6IDxwcmU+e3sgZGF0YSB9fTwvcHJlPjwvZGl2PlxuICA8ZGl2IHYtZWxzZT5Mb2FkaW5nLi4uPC9kaXY+XG48L3RlbXBsYXRlPiIsImltcG9ydC1tYXAuanNvbiI6IntcbiAgXCJpbXBvcnRzXCI6IHtcbiAgICBcInZ1ZVwiOiBcImh0dHBzOi8vc2ZjLnZ1ZWpzLm9yZy92dWUucnVudGltZS5lc20tYnJvd3Nlci5qc1wiLFxuICAgIFwidnVlL3NlcnZlci1yZW5kZXJlclwiOiBcImh0dHBzOi8vc2ZjLnZ1ZWpzLm9yZy9zZXJ2ZXItcmVuZGVyZXIuZXNtLWJyb3dzZXIuanNcIlxuICB9XG59IiwidXNlRmV0Y2guanMiOiJpbXBvcnQgeyByZWYsIGlzUmVmLCB1bnJlZiwgd2F0Y2hFZmZlY3QgfSBmcm9tICd2dWUnXG5cbmV4cG9ydCBmdW5jdGlvbiB1c2VGZXRjaCh1cmwpIHtcbiAgY29uc3QgZGF0YSA9IHJlZihudWxsKVxuICBjb25zdCBlcnJvciA9IHJlZihudWxsKVxuXG4gIGFzeW5jIGZ1bmN0aW9uIGRvRmV0Y2goKSB7XG4gICAgLy8gcmVzZXQgc3RhdGUgYmVmb3JlIGZldGNoaW5nLi5cbiAgICBkYXRhLnZhbHVlID0gbnVsbFxuICAgIGVycm9yLnZhbHVlID0gbnVsbFxuICAgIFxuICAgIC8vIHJlc29sdmUgdGhlIHVybCB2YWx1ZSBzeW5jaHJvbm91c2x5IHNvIGl0J3MgdHJhY2tlZCBhcyBhXG4gICAgLy8gZGVwZW5kZW5jeSBieSB3YXRjaEVmZmVjdCgpXG4gICAgY29uc3QgdXJsVmFsdWUgPSB1bnJlZih1cmwpXG4gICAgXG4gICAgdHJ5IHtcbiAgICAgIC8vIGFydGlmaWNpYWwgZGVsYXkgLyByYW5kb20gZXJyb3JcbiAgXHQgIGF3YWl0IHRpbWVvdXQoKVxuICBcdCAgLy8gdW5yZWYoKSB3aWxsIHJldHVybiB0aGUgcmVmIHZhbHVlIGlmIGl0J3MgYSByZWZcblx0ICAgIC8vIG90aGVyd2lzZSB0aGUgdmFsdWUgd2lsbCBiZSByZXR1cm5lZCBhcy1pc1xuICAgIFx0Y29uc3QgcmVzID0gYXdhaXQgZmV0Y2godXJsVmFsdWUpXG5cdCAgICBkYXRhLnZhbHVlID0gYXdhaXQgcmVzLmpzb24oKVxuICAgIH0gY2F0Y2ggKGUpIHtcbiAgICAgIGVycm9yLnZhbHVlID0gZVxuICAgIH1cbiAgfVxuXG4gIGlmIChpc1JlZih1cmwpKSB7XG4gICAgLy8gc2V0dXAgcmVhY3RpdmUgcmUtZmV0Y2ggaWYgaW5wdXQgVVJMIGlzIGEgcmVmXG4gICAgd2F0Y2hFZmZlY3QoZG9GZXRjaClcbiAgfSBlbHNlIHtcbiAgICAvLyBvdGhlcndpc2UsIGp1c3QgZmV0Y2ggb25jZVxuICAgIGRvRmV0Y2goKVxuICB9XG5cbiAgcmV0dXJuIHsgZGF0YSwgZXJyb3IsIHJldHJ5OiBkb0ZldGNoIH1cbn1cblxuLy8gYXJ0aWZpY2lhbCBkZWxheVxuZnVuY3Rpb24gdGltZW91dCgpIHtcbiAgcmV0dXJuIG5ldyBQcm9taXNlKChyZXNvbHZlLCByZWplY3QpID0+IHtcbiAgICBzZXRUaW1lb3V0KCgpID0+IHtcbiAgICAgIGlmIChNYXRoLnJhbmRvbSgpID4gMC4zKSB7XG4gICAgICAgIHJlc29sdmUoKVxuICAgICAgfSBlbHNlIHtcbiAgICAgICAgcmVqZWN0KG5ldyBFcnJvcignUmFuZG9tIEVycm9yJykpXG4gICAgICB9XG4gICAgfSwgMzAwKVxuICB9KVxufSJ9
import { ref, isRef, unref, watchEffect } from 'vue'


export const baseUrls = {
    getItem : "/API/40Fingers/EmptyModuleVue3/Item/GetItem?itemid="
}

export function getItem(id) {
    const { data, error } = useFetch(`/API/40Fingers/EmptyModuleVue3/Item/GetItem?itemid=${id}`);
    return { item: data, error };
}

export function getItems() {
    const { data, error } = useFetch("/API/40Fingers/EmptyModuleVue3/Item/GetList");
    return { items: data, error };
}

export function useFetch(url) {
    const data = ref(null)
    const error = ref(null)

    async function doFetch() {
        // reset state before fetching..
        data.value = null
        error.value = null

        // resolve the url value synchronously so it's tracked as a
        // dependency by watchEffect()
        const urlValue = unref(url)

        try {
            // unref() will return the ref value if it's a ref
            // otherwise the value will be returned as-is
            const res = await fetch(urlValue)
            data.value = await res.json()
        } catch (e) {
            error.value = e
        }
    }

    if (isRef(url)) {
        // setup reactive re-fetch if input URL is a ref
        watchEffect(doFetch)
    } else {
        // otherwise, just fetch once
        doFetch()
    }

    return { data, error, reload: doFetch }
}