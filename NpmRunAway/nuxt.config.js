export default {
  // Global page headers (https://go.nuxtjs.dev/config-head)
  head: {
    title: 'CocktailDB NPM-RUN-AWAY',
    meta: [
      { charset: 'utf-8' },
      { name: 'viewport', content: 'width=device-width, initial-scale=1' },
      { hid: 'description', name: 'description', content: '' }
    ],
    link: [
      { rel: 'icon', type: 'image/x-icon', href: '/favicon.ico' }
    ]
  },

  // Global CSS (https://go.nuxtjs.dev/config-css)
  css: [
  ],

  // Plugins to run before rendering page (https://go.nuxtjs.dev/config-plugins)
  plugins: [
  ],

  // Auto import components (https://go.nuxtjs.dev/config-components)
  components: true,

  // Modules for dev and build (recommended) (https://go.nuxtjs.dev/config-modules)
  buildModules: [
    // https://go.nuxtjs.dev/typescript
    '@nuxt/typescript-build',
    '@nuxtjs/vuetify',
    '@nuxtjs/eslint-module',
    '@nuxtjs/pwa'
  ],

  // Modules (https://go.nuxtjs.dev/config-modules)
  modules: [
    '@nuxtjs/axios',
    '@nuxtjs/proxy',
    '@nuxtjs/toast'
  ],

  axios: {
    proxy: true
  },

  proxy: {
    '/api': {
      target: 'https://somegamestudios.com/NpmRunAway/',
      pathRewrite: {
        '^/api': '/'
      }
    },
    '/data': {
      target: 'https://www.thecocktaildb.com',
      pathRewrite: {
        '^/data': '/'
      }
    }
  },
  toast: {
    position: 'top-center',
    register: [ // Register custom toasts
      {
      }
    ]
  },
  // Build Configuration (https://go.nuxtjs.dev/config-build)
  build: {
  }
}
