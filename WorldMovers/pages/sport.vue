<template>
  <p v-if="$fetchState.pending">Fetching sport data...</p>
  <p v-else-if="$fetchState.error">An error occurred :(</p>
  <div v-else>
    <h1>All Sport</h1>
    <ul>
      <li v-for="sport of sports[0].sports" :key="sport.idSport">
        {{ sport.strSport }}
      </li>
    </ul>
    <button @click="$fetch">Refresh</button>
  </div>
</template>

<script>
export default {
  middleware: ["authenticated"],
  data() {
    return {
      sports: [],
    };
  },

  async fetch() {
    const allsport = await fetch(process.env.allSportsUrl).then(
      (x) => x.json()
      // console.log(this.sports)
    );
    this.sports = this.sports.concat(allsport);
    console.log(this.sports[0].sports);
  },
};
</script>
