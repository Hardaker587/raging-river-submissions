<template>
  <v-container fluid>
    <v-row>
      <v-col cols="12">
        <v-expansion-panels>
          <v-expansion-panel v-for="(item, i) in userPanels" :key="i">
            <v-expansion-panel-header>
              {{ item.name }}
            </v-expansion-panel-header>
            <v-expansion-panel-content>
              <component :is="item.component"></component>
            </v-expansion-panel-content>
          </v-expansion-panel>
        </v-expansion-panels>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import AddAdminUser from '~/components/Admin/userManagement/AddAdminUser'
import AddNewUser from '~/components/Admin/userManagement/AddNewUser'
export default {
  name: 'ManageUsers',
  components: { AddAdminUser, AddNewUser },
  data() {
    return {
      userPanels: [
        { name: 'Add new admin', component: 'AddAdminUser' },
        { name: 'Add new user', component: 'AddNewUser' },
      ],
    }
  },
}
</script>
