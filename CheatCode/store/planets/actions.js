export default {
  async fetchPlanet(state, planet) {
    await this.$axios
      .$get(`/images/search?q=${planet}`)
      .then((p) => state.commit('updateCurrentPlanet', p.collection))
  },
  dumpPlanet(state) {
    state.commit('dumpPlanet')
  },
  async fetchPlanetsFromDb(state) {
    const planetData = this.$fire.database.ref('planets')
    const fictionalPlanetData = this.$fire.database.ref('fictionalPlanets')
    try {
      const planets = []
      await planetData
        .orderByChild('name')
        .once('value', (r) => {
          r.forEach((planet) => {
            planets.push({
              key: planet.key,
              ...planet.val(),
            })
            return false
          })
        })
        .then(() => {
          fictionalPlanetData.orderByChild('name').once('value', (r) => {
            r.forEach((planet) => {
              planets.push({
                key: planet.key,
                ...planet.val(),
              })
              return false
            })
            state.commit('fetchPlanetFromDB', planets)
          })
        })
      return planets
    } catch (e) {
      alert(e)
    }
  },
  async writePlanetToDB(
    state,
    { name, isPlanet, additionalInformation, link, pageInformation }
  ) {
    const messageRef = this.$fire.database.ref('planets/' + this.$utils.guid())
    try {
      await messageRef
        .set({
          name,
          isPlanet,
          additionalInformation,
          link,
          pageInformation,
          created: new Date().toLocaleDateString(),
          edited: new Date().toLocaleDateString(),
        })
        .then(
          this.$notifications.showMessage({
            content: 'New planet successfully added',
            color: 'success',
          })
        )
    } catch (e) {
      alert(e)
      return false
    }
  },
  async writeFictionalPlanetToDB(
    state,
    {
      name,
      isPlanet,
      isFiction,
      fictionalType,
      texture,
      additionalInformation,
      link,
      pageInformation,
    }
  ) {
    const messageRef = this.$fire.database.ref(
      'fictionalPlanets/' + this.$utils.guid()
    )
    try {
      await messageRef
        .set({
          name,
          isPlanet,
          isFiction,
          fictionalType,
          texture,
          additionalInformation,
          link,
          pageInformation,
          created: new Date().toLocaleDateString(),
          edited: new Date().toLocaleDateString(),
        })
        .then(
          this.$notifications.showMessage({
            content: 'New planet successfully added',
            color: 'success',
          })
        )
    } catch (e) {
      alert(e)
      return false
    }
  },
  async writeComment(state, { mediaId, comment, mediaType, mediaLink }) {
    const message = this.$fire.database.ref(`comments/${mediaId}`)
    const commentData = this.$fire.database.ref(
      `comments/${mediaId}/${this.$utils.guid()}`
    )
    try {
      await message
        .set({
          mediaType,
          mediaLink,
        })
        .then(() => {
          commentData.set({
            ...this.getters['auth/authUser'],
            comment,
            created: new Date().toLocaleDateString(),
            edited: new Date().toLocaleDateString(),
          })
        })
        .then(
          this.$notifications.showMessage({
            content: 'New comment added',
            color: 'success',
          })
        )
    } catch (e) {
      console.log(e)
    }
  },
  async fetchComment(state, mediaId) {
    const media = this.$fire.database.ref(`comments/${mediaId}`)
    await media.orderByChild('created').once('value', (r) => {
      console.log(r.val())
      if (r.val() !== null) {
        state.commit('comments', { key: r.key, ...r.val() })
      }
    })
  },
  async fetchComments(state) {
    const media = this.$fire.database.ref(`comments`)
    const comments = []
    await media.orderByChild('created').once('value', (r) => {
      console.log(r.val())
      r.forEach((comment) => {
        comments.push({
          key: comment.key,
          ...comment.val(),
        })
        return false
      })
      state.commit('allcomments', comments)
    })
  },
}
