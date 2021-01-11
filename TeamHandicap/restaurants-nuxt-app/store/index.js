export const state = () => ({
    showLogin: false,
    showRegister: false,
    jwt: undefined,
    decodedJwt: undefined,
    coordinates: {
        longitude: 28.2451057,
        latitude: -25.7305802
    },
    address: {},
    restaurants: []
})

export const mutations = {
    showLogin(state) {
        state.showLogin = true;
    },
    hideLogin(state) {
        state.showLogin = false;
    },
    showRegister(state) {
        state.showRegister = true;
    },
    hideRegister(state) {
        state.showRegister = false;
    },
    toggleShowLoginOrRegister(state) {
        state.showRegister = state.showLogin;
        state.showLogin = !state.showLogin;
    },
    setJwt(state, newJwt) {
        state.jwt = newJwt;
        state.decodedJwt = JwtHelper().decodeToken(newJwt);
    },
    clearJwt(state) {
        state.jwt = undefined;
        state.decodedJwt = undefined;
    },
    setCoordinates(state, coordinates) {
        state.coordinates = coordinates;
    },
    setAddress(state, address){
        state.address = address;
    },
    setRestaurants(state, restaurants){
        state.restaurants = restaurants;
    }
}
export const actions = {
    setCoordinates(vuexContext, coordinates) {
        vuexContext.commit('setCoordinates', coordinates)
    },
    setAddress(vuexContext, address) {
        vuexContext.commit('setAddress', address)
    },
    setRestaurants(vuexContext, restaurants){
        vuexContext.commit('setRestaurants', restaurants)
    }
}

export const getters = {
    getJwt: (state) => state.jwt,
    hasValidJwt: (state) => !(JwtHelper().hasExpired(state.decodedJwt)),
    getAvatarImgId: (state) => JwtHelper().getAvatarImgId(state.decodedJwt),
    getFirstName: (state) => JwtHelper().getFirstName(state.decodedJwt),
    getUserName: (state) => JwtHelper().getSubject(state.decodedJwt),
    getCoordinates: (state) => state.coordinates,
    getAddress: (state) => state.address,
    getRestaurants: (state) => state.restaurants
}

const ClaimTypes = {
    SUBJECT: 'sub',
    EXPIRATION_DATE: 'exp',
    FIRST_NAME: "fnm",
    AVATAR_ID: "avtid"
}

function JwtHelper() {
    function getClaimValue(decodedToken, claimKey) {
        return decodedToken ? decodedToken[claimKey] : undefined;
    }

    function urlBase64Decode(str) {
        let output = str.replace(/-/g, '+').replace(/_/g, '/');
        switch (output.length % 4) {
            case 0: break;
            case 2: output += '=='; break;
            case 3: output += '='; break;
            default: return null;
        }
        return decodeURIComponent(escape(window.atob(output)));
    }

    return {
        getSubject: (decodedToken) => getClaimValue(decodedToken, ClaimTypes.SUBJECT),
        getFirstName: (decodedToken) => getClaimValue(decodedToken, ClaimTypes.FIRST_NAME),
        getAvatarImgId: (decodedToken) => getClaimValue(decodedToken, ClaimTypes.AVATAR_ID),
        hasExpired: (decodedToken) => {
            const timestamp = ((new Date()).getTime() / 1000); // Seconds since Unix epoch
            return decodedToken ? decodedToken[ClaimTypes.EXPIRATION_DATE] <= timestamp : true;
        },
        decodeToken: (token) => {
            const parts = token.split('.');
            if (parts.length !== 3) { // JWT must have 3 parts
                return null;
            }
            const decoded = urlBase64Decode(parts[1]);
            if (!decoded) { // Cannot decode the token
                return null;
            }
            return JSON.parse(decoded);
        }
    }
}












