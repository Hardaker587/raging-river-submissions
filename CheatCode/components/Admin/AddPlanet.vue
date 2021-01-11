<template>
  <v-container fluid>
    <v-row>
      <v-col cols="6">
        <v-card class="pa-2" flat>
          <v-form>
            <v-text-field
              v-model="name"
              label="Name"
              outlined
              rounded
              color="primary"
            ></v-text-field>
            <v-select
              v-model="isPlanet"
              label="Is it a planet?"
              outlined
              rounded
              :items="bool"
            ></v-select>
            <v-select
              v-model="isFiction"
              label="Is it fictional?"
              outlined
              rounded
              :items="bool"
            ></v-select>
            <v-select
              v-if="isFiction"
              v-model="fictionalType"
              label="Type of World"
              outlined
              rounded
              :items="fictionalPlanetTypes"
              item-text="name"
              item-value="type"
            ></v-select>
            <v-select
              v-model="texture"
              v-if="fictionalType !== ''"
              :items="returnTextures(fictionalType)[0].items"
              label="Select Texture"
              rounded
              outlined
            >
              <template v-slot:item="{ item }" class="texturePicker">
                <v-img
                  :src="`/images/fictionalTextures/${fictionalType}/${item}.png`"
                  height="50px"
                  class="pb-2"
                ></v-img>
              </template>
            </v-select>
            <v-text-field
              v-model="additionalInformation"
              label="Additional Information"
              outlined
              rounded
            ></v-text-field>
            <v-text-field
              v-model="link"
              label="link"
              outlined
              rounded
            ></v-text-field>
            <v-textarea
              v-model="pageInformation"
              label="Page Information"
              outlined
              rounded
              required
            ></v-textarea>
            <v-btn block color="success" @click="addPlanet()">Add planet</v-btn>
          </v-form>
        </v-card></v-col
      >
      <v-col cols="6" class="planetContainer">
        <CardNavigation column :planets="planets" />
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import CardNavigation from '~/components/UI/CardNavigation'
export default {
  name: 'AddPlanet',
  components: { CardNavigation },
  props: {
    planets: { type: [Object, Array], required: true, default: () => [] },
  },
  data() {
    return {
      name: '',
      isPlanet: '',
      isFiction: false,
      bool: ['true', 'false'],
      additionalInformation: '',
      link: '',
      pageInformation: '',
      fictionalType: '',
      texture: '',
      fictionalPlanetTypes: [
        {
          type: 'GasGiant',
          name: 'Gas Giant',
          directory: 'GasGiant',
          items: ['Gaseous1', 'Gaseous2', 'Gaseous3', 'Gaseous4'],
        },
        {
          type: 'HabitalWorld',
          name: 'Habital World',
          directory: 'HabitalWorld',
          items: ['Alpine', 'Savannah', 'Swamp', 'Tropical'],
        },
        {
          type: 'InhospitableWorld',
          name: 'Inhospitable World',
          directory: 'InhospitableWorld',
          items: ['Icy', 'Martian', 'Venusian', 'Volcanic'],
        },
        {
          type: 'TerrestrialWorld',
          name: 'TerrestrialWorld',
          directory: 'TerrestrialWorld',
          items: [
            'Terrestrial1',
            'Terrestrial2',
            'Terrestrial3',
            'Terrestrial3',
          ],
        },
      ],
    }
  },
  methods: {
    returnTextures(worldType) {
      return this.fictionalPlanetTypes.filter((f) => f.type === worldType)
    },
    addPlanet(payload) {
      if (this.isFiction) {
        this.$nuxt.$emit('add-fictional-planet', {
          name: this.name,
          isPlanet: this.isPlanet,
          isFiction: this.isFiction,
          fictionalType: this.fictionalType,
          texture: this.texture,
          additionalInformation: this.additionalInformation,
          link: this.link,
          pageInformation: this.pageInformation,
        })
      } else {
        this.$nuxt.$emit('add-planet', {
          name: this.name,
          isPlanet: this.isPlanet,
          isFiction: this.isFiction,
          additionalInformation: this.additionalInformation,
          link: this.link,
          pageInformation: this.pageInformation,
        })
      }
    },
  },
}
</script>
<style scoped lang="scss">
.texturePicker {
  max-width: 200px;
}
.planetContainer {
  max-height: calc(100vh - 250px);
  overflow: scroll;
}
</style>
