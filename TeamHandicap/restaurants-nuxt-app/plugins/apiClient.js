export default (context, inject) => {
    inject('apiClient', () => {
        const apiBaseUrl = process.env.apiBaseUrl;

        function _addAuthHeader(headers) {
            if (context.store.getters.hasValidJwt) {
                headers['Authorization'] = `Bearer ${context.store.getters.getJwt}`;
            }
            return headers;
        }

        return {
            get(path) {
                const headers = _addAuthHeader({
                    'Pragma': 'no-cache',
                    'Expires': 'Sat, 01 Jan 2000 00:00:00 GMT',
                    'Cache-Control': 'no-cache, no-store'
                });
                return context.$axios.get(apiBaseUrl + encodeURI(path), { headers });
            },
            post(path, payload) {
                let serializedPayload = null;
                if (payload) {
                    serializedPayload = JSON.stringify(payload);
                }
                const headers = _addAuthHeader({ 'Content-Type': 'application/json' });
                return context.$axios.post(apiBaseUrl + encodeURI(path), serializedPayload, { headers });
            },
            put(path, payload) {
                const serializedPayload = JSON.stringify(payload);
                const headers = _addAuthHeader({ 'Content-Type': 'application/json' });
                return context.$axios.put(apiBaseUrl + encodeURI(path), serializedPayload, { headers });
            },
            patch(path, payload) {
                const serializedPayload = JSON.stringify(payload);
                const headers = _addAuthHeader({ 'Content-Type': 'application/json' });
                return context.$axios.patch(apiBaseUrl + encodeURI(path), serializedPayload, { headers });
            },
            delete(path) {
                const headers = _addAuthHeader({});
                return context.$axios.delete(apiBaseUrl + encodeURI(path), { headers });
            },
            uploadFile(path, file) {
                const formData = new FormData();
                formData.append('file', file);

                const headers = _addAuthHeader({ 'Enctype': 'multipart/form-data' });
                return context.$axios.post(apiBaseUrl + encodeURI(path), formData, { headers });
            },
            getFileBlob(path) {
                const headers = _addAuthHeader({});
                return context.$axios.get(apiBaseUrl + encodeURI(path), { headers, responseType: 'blob' });
            }
        }
    })
}