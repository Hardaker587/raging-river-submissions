<template>
  <v-row justify="center" align="center">
    <v-col cols="12" sm="8" md="6">
      <div class="text-center">
        <logo />
        <vuetify-logo />
      </div>
      <v-card>
        <v-card-title class="headline">
          Internal Raging River Competition
        </v-card-title>
        <v-card-text>
<p>
Rules:


	
The competition will run for 14 days from date of commencement:
<ul>	
  <li>Participation is not mandatory</li>
	<li>Must use Nuxt</li>
	<li>Must have authentication</li>
	<li>Must use VueX</li>
	<li>Must make use of Axios to fetch data</li>
	<li>Make use of the Vue lifecycle: https://v3.vuejs.org/api/options-lifecycle-hooks.html#beforemount</li>
</ul>
</p>
<p>
  Guidelines:

  <ul>
    <li>Make use of Components + Props to pass data</li>
  	<li>Data api will be provided</li>
  	<li>Using data from api provided construct a functional front end</li>
  	<li>Do not make a todo or list application, create something functional and engaging</li>
  	<li>Make use of methods to better manipulate your components</li>
  	<li>Try to keep your components as simple as possible, if they can be reused at a later stage, rather chain them to build up your final component</li>
  	<li>If any env variables are required, it is best advised to place these in your nuxt.config file</li>
  	<li>Use your favourite version control host to keep track of your project</li>
  	<li>If you get stuck, don’t be afraid to “phone a friend”</li>
  	<li>If you would like to use linting such as Eslint, and prettier you can, this does come highly recommended</li>
  </ul>
</p>

<h4>Recommendations (these do not have to be followed these are rather what we found best):</h4>
<p>
  

  <ul>
    <li>Make use of Vuetify as a component base</li>
	  <li>Acquire modules from the Nuxt Module repository: https://modules.nuxtjs.org/</li>
	  <li>Style your components by scoping within the *.vue file rather than using global stylesheets</li>
	  <li>Try to clear out your console logs or anything you may use to debug your project</li>
	  <li>Make use of Visual Studio Code as this is one of the best free IDE’s for the job and comes with a lot of added plugins that will help</li>
  </ul>
</p>

<h4>Recommended CLI configuration(this can be anything you’d like):</h4>
<p>

  <ul>
    <li>Package manager: NPM</li>
  	<li>Programming Language: Either is fine, but Synapse uses JS now and will migrate to TS later on</li>
  	<li>UI Framework: We use Vuetify - you may use any you find yourself comfortable with</li>
  	<li>Nuxt.js Modules: Axios + PWA</li>
  	<li>Linting Tools: ESLint + Prettier + StyleLint</li>
  	<li>Testing Frameworks: This isn’t needed</li>
  	<li>Rendering mode: SSR</li>
  	<li>Deployment Target: Server</li>
  	<li>Development tools: jsconfig.json</li>
  	<li>Continuous integration</li>
  </ul>
</p>

<h4>You can skip this. Fun stuff:</h4>	
<p>
	
<ul>
  <li>Design the application however you want</li>
	<li>Use as much of the data to provide a fun and intuitive</li>
	<li>You can use whatever icons/images/colours etc you like to make it look appealing</li>
	<li>Create a team name and use that to name your project</li>


  Do nots:
  <li>If you make use of any browser storage, do not use methods that will clear any of the storage such as window.localStorage.clear(); This may impact other teams that might make use of the same facilities</li>
  <li>Rather make use of: window.localStorage.removeItem('name');</li>
  </ul>
</p>

<h4>Go through the rules again, use your imagination, creativity and go wild.</h4>
<p>

  <ul>
    <li>Three Men and a Baby: FBI data: https://www.fbi.gov/wanted/api </li>

    <li>Team Handicap Restaurants: https://developers.zomato.com/documentation</li>

    <li>The so called team: https://www.thecocktaildb.com/api.php</li>

    <li>World movers: SportsDB: https://www.thesportsdb.com/api.php </li>

    <li>npm run away: CocktailDB: https://www.thecocktaildb.com/api.php </li>

    <li>Gavin: NASA: https://api.nasa.gov/index.html </li>
  </ul>
</p>

<h4>Team members:</h4>
<p>

  <ul>
    <li>Three Men and a Baby - Werner, Ludwig, Demian, Danie</li>
    <li>Team Handicap - Freeg, Juan, Cory, Sello, Jerome</li>
    <li>The so called team - Kwena, Pitsi, Ravi, Sammy</li>
    <li>World movers - Phuti, Bongani, Kopano, Hannes, Thando</li>
    <li>npm run away - Raymond, Rex, Corne, Ruan</li>
  </ul>
</p>
        </v-card-text>
        <v-card-actions>
          <v-spacer />
          <v-btn color="primary" nuxt to="/MostWantedList"> Continue </v-btn>
        </v-card-actions>
      </v-card>
    </v-col>
  </v-row>
</template>

<script>
import Logo from '~/components/Logo.vue'
import VuetifyLogo from '~/components/VuetifyLogo.vue'

export default {
  components: {
    Logo,
    VuetifyLogo,
  },
}
</script>
