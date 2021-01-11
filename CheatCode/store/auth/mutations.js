import initialState from './state'

export default {
  RESET_STORE: (state) => {
    Object.assign(state, initialState())
  },

  SET_AUTH_USER: (state, { authUser }) => {
    state.authUser = {
      uid: authUser.uid,
      email: authUser.email,
    }
  },
  ADMIN: (state, admin) => {
    state.admin = admin
  },
  USERS: (state, users) => {
    state.users = users
  },
}
