export default {
  notification(state, payload) {
    state.commit('showMessage', payload)
  },
}
