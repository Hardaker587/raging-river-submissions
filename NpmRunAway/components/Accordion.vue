<template>
  <v-expansion-panels>
    <v-expansion-panel>
      <v-expansion-panel-header>
        {{ title }}
      </v-expansion-panel-header>
      <v-expansion-panel-content>
        {{ description }}
      </v-expansion-panel-content>
    </v-expansion-panel>
  </v-expansion-panels>
</template>

<script>
export default {
  name: 'Accordion',
  props: [
    'title',
    'description'],
  metaInfo () {
    return {
      title: this.title,
      meta: [
      ]
    }
  }
}
</script>
