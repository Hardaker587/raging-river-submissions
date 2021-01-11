export default {
  getPlanet(state) {
    return state.currentPlanet
  },
  returnPlanetsFromDB(state) {
    return state.planetsFromDB
  },
  returnSpecificPlanet(state, planetName) {
    return state.planetsFromDB.filter((p) => p.name === planetName)
  },
  returnComments(state) {
    return state.comments
  },
  returnAllComments(state) {
    return state.allComments
  },
}
