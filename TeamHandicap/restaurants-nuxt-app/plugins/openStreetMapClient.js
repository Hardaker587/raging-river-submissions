export default (context, inject) => {
    inject('openStreetMapClient', () => {
        const nominatimApiUrl = `https://nominatim.openstreetmap.org`;

        return {
            reverseGeocode(coordinates) {
                const prom = context.$axios.get(`${nominatimApiUrl}/reverse?lat=${coordinates.latitude}&lon=${coordinates.longitude}&format=json`).then(resp => {
                    context.store.commit("setAddress", resp.data.address);
                });
                return prom;
            },
        }
    })
}