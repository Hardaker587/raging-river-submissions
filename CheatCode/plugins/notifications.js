export default ({ app, store }, inject) => {
  inject('notifications', {
    showMessage({ content = '', color = '' }) {
      store.dispatch('notifications/notification', { content, color })
    },
  })
}
