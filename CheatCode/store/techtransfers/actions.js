export default {
  async techtransfers(state, type) {
    await this.$axios
      .$get(`/api/techtransfer/${type}/?api_key=${process.env.API_KEY}`)
      .then((r) => state.commit(type, r))
  },
}
