
export const state = () => ({
  userName: ''
})

export const mutations = {
  setUsername (state, name) {
    state.userName = name
  }
}

export const getters = {
  getUserName (state) {
    return state.userName
  }
}
