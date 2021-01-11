<template>
  <v-container>
    this is where imma put tech transfers
    <v-row>
      <v-col cols="6">
        <v-sheet color="white" class="pa-4 rounded-xl elevation-4"
          >There is currently
          <span class="font-weight-bold">{{ returnPatent.count }}</span>
          registered patents</v-sheet
        >
      </v-col>
      <v-col cols="6">
        <v-sheet color="white" class="pa-4 rounded-xl elevation-4"
          >There is currently
          <span class="font-weight-bold">{{ returnSoftware.count }}</span>
          registered software applications</v-sheet
        >
      </v-col>
    </v-row>
    <v-row>
      <div v-for="(patent, index) in returnPatent.results" :key="index">
        {{ patent[5] }}
      </div>
    </v-row>
  </v-container>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
export default {
  name: 'index.vue',
  data() {
    return {
      patents: null,
      software: null,
    }
  },
  beforeMount() {
    this.getPatents()
    this.getSoftware()
    this.techtransfer('patent')
    this.techtransfer('software')
  },
  computed: {
    ...mapGetters({
      returnPatent: 'techtransfers/returnPatent',
      returnSoftware: 'techtransfers/returnSoftware',
    }),
  },
  methods: {
    ...mapActions({
      techtransfer: 'techtransfers/techtransfers',
    }),
    async getPatents() {
      return await this.$axios
        .$get(`/api/techtransfer/patent/?api_key=${process.env.API_KEY}`)
        .then((p) => {
          this.patents = p
        })
    },
    async getSoftware() {
      return await this.$axios
        .$get(`/api/techtransfer/software/?api_key=${process.env.API_KEY}`)
        .then((s) => {
          this.software = s
        })
    },
  },
}
</script>
