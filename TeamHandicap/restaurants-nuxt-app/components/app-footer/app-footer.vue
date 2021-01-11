<template>
    <footer class="footer">
      <nav>
        <nuxt-link class="nav-link" to="/team">Team</nuxt-link>
        |
        <nuxt-link class="nav-link" to="/privacy-policy">Privacy Policy</nuxt-link>
        |
        <nuxt-link class="nav-link" to="/terms-and-conditions">Ts &amp; Cs</nuxt-link>
         |
        <nuxt-link class="nav-link" to="/">Home</nuxt-link>
      </nav>
    </footer>
</template>

<script>
export default {
  name: 'AppFooter'
}
</script>

<style scoped lang="scss" rel="stylesheet/scss">
@import './app-footer.scss';
</style>