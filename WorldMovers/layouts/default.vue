<template>
  <v-app dark>
    <v-navigation-drawer
      v-model="drawer"
      :mini-variant="miniVariant"
      :clipped="clipped"
      fixed
      app
    >
      <v-list>
        <v-list-item
          v-for="(item, i) in items"
          :key="i"
          :to="item.to"
          router
          exact
        >
          <v-list-item-action>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title v-text="item.title" />
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-app-bar :clipped-left="clipped" fixed app>
      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
      <v-btn icon @click.stop="miniVariant = !miniVariant">
        <v-icon>mdi-{{ `chevron-${miniVariant ? "right" : "left"}` }}</v-icon>
      </v-btn>
      <v-btn icon @click.stop="clipped = !clipped">
        <v-icon>mdi-application</v-icon>
      </v-btn>
      <v-toolbar-title v-text="title" />
      <v-spacer />
      <div v-if="loggedInUser.isLoggedIn">
        {{ loggedInUser.email }}
        <v-btn text @click="logOut">Logout</v-btn>
      </div>
      <div v-else>
        <v-btn text to="/auth/login">Login</v-btn>
        <v-btn text to="/auth/register">Register</v-btn>
      </div>
    </v-app-bar>
    <v-main>
      <v-container>
        <nuxt />
      </v-container>
    </v-main>
    <v-footer :absolute="!fixed" app>
      <span>&copy; World Movers {{ new Date().getFullYear() }}</span>
    </v-footer>
  </v-app>
</template>

<script>
import firebase from "firebase/app";
import "firebase/auth";
import { persistCookie } from "@/utils/helper";
export default {
  data() {
    return {
      clipped: false,
      drawer: false,
      fixed: false,
      loggedInUser: {
        isLoggedIn: false,
        email: "",
      },
      items: [
        {
          icon: "mdi-apps",
          title: "Home",
          to: "/",
        },
        {
          icon: "mdi-soccer-field",
          title: "Sports",
          to: "/sport",
        },
        {
          icon: "mdi-teams",
          title: "My Favorite Teams",
          to: "/favoriteTeams",
        },
      ],
      miniVariant: false,
      right: true,
      rightDrawer: false,
      title: "World Movers",
    };
  },
  mounted() {
    this.setupFirebase();
  },
  methods: {
    logOut() {
      this.$store.dispatch("logout").then(() => {
        this.loggedInUser.isLoggedIn = false;
        this.loggedInUser.email = "";
        this.$router.push("/auth/login");
      });
    },
    setupFirebase() {
      firebase.auth().onAuthStateChanged((user) => {
        if (user) {
          this.loggedInUser.isLoggedIn = true;
          this.loggedInUser.email = user.email;
          if (persistCookie()) {
            this.$store.dispatch("setUserDetail", user);
          }
        }
      });
    },
  },
};
</script>
