<template>
  <v-row>
    <v-list>
        <v-list-item
          v-for="(event, i) in events"
          :key="i"
        >
          <v-list-item-action>
            <v-icon>{{ event.id }}</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title v-text="event.title" />
          </v-list-item-content>
        </v-list-item>
      </v-list>
  </v-row>
</template>

<script>
export default {
   props: {
       events: {
           type: Array,
           required: true
       }
   }
}
</script>