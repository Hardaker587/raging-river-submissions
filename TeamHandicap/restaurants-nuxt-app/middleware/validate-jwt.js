export default function ({ store, redirect }) {
    if (!store.getters.hasValidJwt) {
        return redirect('/');
    }
  }