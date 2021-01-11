import Cookie from "js-cookie";
import firebase from "firebase/app";
import "firebase/auth";
import { getLoggedInUserFromCookie } from "@/utils/helper";

export const strict = false;

export const state = () => ({
  currentUser: null,
  token: null,
});

export const mutations = {
  setLoggedInUser(state, user) {
    state.currentUser = user;
  },
  setToken(state, token) {
    state.token = token;
  },
  clearToken(state) {
    state.token = null;
  },
};

export const actions = {
  nuxtServerInit({ commit }, { req }) {
    const user = getLoggedInUserFromCookie(req);
    if (user) {
      commit("setLoggedInUser", {
        uid: user.user_id,
        name: user.name,
        email: user.email,
      });
    }
  },
  setUserDetail({ commit }, user) {
    commit("setLoggedInUser", {
      uid: user.uid,
      name: user.name,
      email: user.email,
    });
    user.getIdToken().then((idToken) => {
      Cookie.set("access_token", idToken);
      commit("setToken", idToken);
    });
  },
  logout({ commit }) {
    firebase
      .auth()
      .signOut()
      .then(() => {
        commit("setLoggedInUser", null);
        commit("setToken", null);
        Cookie.remove("access_token");
      });
  },
};

export const getters = {
  isAuthenticated(state) {
    return state.currentUser != null;
  },
};
