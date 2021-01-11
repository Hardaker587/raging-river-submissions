export default {
  updateCurrentPlanet(state, information) {
    state.currentPlanet = information
  },
  dumpPlanet(state) {
    state.currentPlanet = []
  },
  fetchPlanetFromDB(state, planets) {
    state.planetsFromDB = planets
  },
  comments(state, mediaId, comment) {
    console.log(state.comments)
    console.log(mediaId)
    if (state.comments.some((c) => c === mediaId)) {
      state.comments.splice(state.comments.indexOf(mediaId), 1)
      state.comments.push(mediaId)
    } else if (mediaId !== null) {
      state.comments.push(mediaId)
    }
  },
  allcomments(state, comments) {
    state.allComments = comments
  },
}
