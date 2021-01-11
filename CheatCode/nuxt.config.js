import colors from 'vuetify/es5/util/colors'

export default {
  // Target (https://go.nuxtjs.dev/config-target)
  target: 'server',

  // Global page headers (https://go.nuxtjs.dev/config-head)
  head: {
    titleTemplate: '%s - gavin-nuxt-submission',
    title: 'gavin-nuxt-submission',
    meta: [
      { charset: 'utf-8' },
      { name: 'viewport', content: 'width=device-width, initial-scale=1' },
      { hid: 'description', name: 'description', content: '' },
    ],
    link: [{ rel: 'icon', type: 'image/x-icon', href: '/favicon.ico' }],
  },

  // Global CSS (https://go.nuxtjs.dev/config-css)
  css: [],

  // Plugins to run before rendering page (https://go.nuxtjs.dev/config-plugins)
  plugins: ['~/plugins/axios', '~/plugins/utils', '~plugins/notifications'],

  // Auto import components (https://go.nuxtjs.dev/config-components)
  components: true,

  // Modules for dev and build (recommended) (https://go.nuxtjs.dev/config-modules)
  buildModules: [
    // https://go.nuxtjs.dev/eslint
    '@nuxtjs/eslint-module',
    // https://go.nuxtjs.dev/stylelint
    '@nuxtjs/stylelint-module',
    // https://go.nuxtjs.dev/vuetify
    '@nuxtjs/vuetify',
  ],

  // Modules (https://go.nuxtjs.dev/config-modules)
  modules: [
    // https://go.nuxtjs.dev/axios
    '@nuxtjs/axios',
    // https://go.nuxtjs.dev/content
    '@nuxt/content',
    // https://github.com/nuxt-community/proxy-module
    '@nuxtjs/proxy',
    [
      '@nuxtjs/firebase',
      {
        config: {
          apiKey: 'AIzaSyAf_IoGaOsvG8l6xk0BCRhOWOCyB7r5yc0',
          authDomain: 'ragingriver-submission.firebaseapp.com',
          databaseURL:
            'https://ragingriver-submission-default-rtdb.firebaseio.com',
          projectId: 'ragingriver-submission',
          storageBucket: 'ragingriver-submission.appspot.com',
          messagingSenderId: '985411325530',
          appId: '1:985411325530:web:65cffad67dff571f541263',
          measurementId: 'G-J36HZ2HQZN',
        },
        services: {
          auth: {
            persistence: 'local', // default
            initialize: {
              onAuthStateChangedAction: 'auth/onAuthStateChanged',
              subscribeManually: false,
            },
            ssr: true, // default
          },
          database: true,
          firestore: true,
          functions: {
            location: 'us-central1',
          },
        },
      },
    ],
  ],
  pwa: {
    meta: false,
    icon: false,
    workbox: {
      importScripts: ['/firebase-auth-sw.js'],
      dev: false,
    },
  },
  env: {
    API_KEY: '8MLowowfneV8ZuMHkU1hi5sj7gJKR6fbKneXbpLw',
  },
  // Axios module configuration (https://go.nuxtjs.dev/config-axios)
  axios: {
    proxy: true, // Can be also an object with default options
  },

  proxy: {
    '/api/': {
      target: 'https://api.nasa.gov',
      pathRewrite: { '^/api/': '' },
    },
    '/api2/': {
      target: 'https://solartextures.b-cdn.net',
      pathRewrite: { '^/api/': '' },
    },
    '/exoplanet/': {
      target: 'https://exoplanetarchive.ipac.caltech.edu',
      pathRewrite: { '^/api/': '' },
    },
    '/images/': {
      target: 'https://images-api.nasa.gov',
      pathRewrite: { '^/images/': '' },
    },
  },
  // Content module configuration (https://go.nuxtjs.dev/config-content)
  content: {},

  // Vuetify module configuration (https://go.nuxtjs.dev/config-vuetify)
  vuetify: {
    customVariables: ['~/assets/variables.scss'],
    theme: {
      dark: false,
      themes: {
        dark: {
          primary: colors.blue.darken2,
          accent: colors.grey.darken3,
          secondary: colors.amber.darken3,
          info: colors.teal.lighten1,
          warning: colors.amber.base,
          error: colors.deepOrange.accent4,
          success: colors.green.accent3,
        },
      },
    },
  },

  // Build Configuration (https://go.nuxtjs.dev/config-build)
  build: {},
}
