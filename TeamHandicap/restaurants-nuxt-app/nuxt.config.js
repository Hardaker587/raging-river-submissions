export default {
    watchQuery: true,

    // Global page headers (https://go.nuxtjs.dev/config-head)
    head: {
        title: 'Raging Restaurants',
        meta: [
            { charset: 'utf-8' },
            { name: 'viewport', content: 'width=device-width, initial-scale=1' },
            { hid: 'description', name: 'description', content: 'Looking for the perfect place to wine and dine? We can definately help!' },
            { property: 'og:title', content: 'Raging Restaurants' },
            { property: 'og:description', content: 'Looking for the perfect place to wine and dine? We can help!' },
            {  property: 'og:image', content: '/og-image.png' },
            { property: 'og:type', content: 'food' },
            { property: 'og:locale', content: 'en_GB' },
            { name: 'msapplication-TileColor', content: '#da532c' },
            { name: 'theme-color', content: '#ffffff' }
        ],
        link: [
            { rel: 'apple-touch-icon', sizes: '180x180', href: '/apple-touch-icon.png' },
            { rel: 'icon', type: 'image/png', sizes: '32x32', href: '/favicon-32x32.png' },
            { rel: 'icon', type: 'image/png', sizes: '16x16', href: '/favicon-16x16.png' },
            { rel: 'manifest', href: '/site.webmanifest' },
            { rel: 'mask-icon', href: '/safari-pinned-tab.svg', color: '#5bbad5' }
        ]
    },

  // Global CSS (https://go.nuxtjs.dev/config-css)
  css: [
    "leaflet/dist/leaflet.css"
  ],

  // Plugins to run before rendering page (https://go.nuxtjs.dev/config-plugins)
  plugins: [
    '~/plugins/apiClient.js',
    { src: '~/plugins/leaflet.js', ssr: false }, // It makes no sense to render a map on the server side :-/
    '~/plugins/vuetify.js',
    '~/plugins/openStreetMapClient.js',
  ],

    // Auto import components (https://go.nuxtjs.dev/config-components)
    components: true,

    // Modules for dev and build (recommended) (https://go.nuxtjs.dev/config-modules)
    buildModules: [
      '@nuxtjs/vuetify'
    ],

    // Modules (https://go.nuxtjs.dev/config-modules)
    modules: [
        // https://go.nuxtjs.dev/axios
        '@nuxtjs/axios',
        // https://go.nuxtjs.dev/pwa
        '@nuxtjs/pwa',
    ],

    // Axios module configuration (https://go.nuxtjs.dev/config-axios)
    axios: {},

    // Build Configuration (https://go.nuxtjs.dev/config-build)
    build: {},
    env: {
        // apiBaseUrl: process.env.BASE_URL || 'http://localhost:5000/api/'
        apiBaseUrl: process.env.BASE_URL || 'http://35.177.108.74/api/'
    }
}
