export default {
  isLoggedIn: (state) => {
    try {
      return state.authUser.id !== null
    } catch {
      return false
    }
  },
  authUser: (state) => {
    return state.authUser
  },
  admin: (state) => {
    return state.admin
  },
}
