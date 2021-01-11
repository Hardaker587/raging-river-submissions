<template>
  <v-container fluid>
    <v-row>
      <v-card width="100%">
        <v-toolbar flat color="#00a826" dark>
          <v-toolbar-title>Admin Dashboard</v-toolbar-title>
        </v-toolbar>
        <v-tabs vertical>
          <v-tab
            v-for="(tab, index) in adminTabs"
            :key="index"
            class="justify-start"
          >
            <v-icon left> mdi-{{ tab.icon }} </v-icon>
            {{ tab.name }}
          </v-tab>
          <v-tab-item v-for="(tabContent, index) in adminTabs" :key="index">
            <v-card flat>
              <v-card-text>
                <component
                  :is="tabContent.component"
                  :planets="returnPlanets"
                  :comments="returnComments"
                ></component>
              </v-card-text>
            </v-card>
          </v-tab-item>
        </v-tabs>
      </v-card>
    </v-row>
  </v-container>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
import AddPlanet from '~/components/Admin/AddPlanet'
import ManageUsers from '~/components/Admin/ManageUsers'
import comments from '~/components/Admin/commentManagement/comments'
export default {
  name: 'index',
  // eslint-disable-next-line vue/no-unused-components
  components: { AddPlanet, ManageUsers, comments },
  data() {
    return {
      adminTabs: [
        { name: 'Manage Planets', icon: 'earth', component: 'AddPlanet' },
        { name: 'Manage Users', icon: 'account', component: 'ManageUsers' },
        { name: 'View Comments', icon: 'chat', component: 'comments' },
      ],
    }
  },
  computed: {
    ...mapGetters({
      returnPlanets: 'planets/returnPlanetsFromDB',
      returnComments: 'planets/returnAllComments',
    }),
  },
  created() {
    this.$nuxt.$on('add-planet', (payload) => {
      this.addPlanet(payload).then(this.fetchPlanets)
    })
    this.$nuxt.$on('add-fictional-planet', (payload) => {
      this.addFictionalPlanet(payload).then(this.fetchPlanets)
    })
  },
  mounted() {
    this.fetchPlanets()
    this.fetchComments()
  },
  methods: {
    ...mapActions({
      addPlanet: 'planets/writePlanetToDB',
      addFictionalPlanet: 'planets/writeFictionalPlanetToDB',
      fetchPlanets: 'planets/fetchPlanetsFromDb',
      fetchComments: 'planets/fetchComments',
    }),
  },
}
</script>
