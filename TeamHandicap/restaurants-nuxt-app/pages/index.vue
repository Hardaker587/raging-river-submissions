<template>
  <div class="container">
    <div class="row">
      <div class="col-12">
        <h1>
          Looking for the perfect place to wine &amp; dine?
        </h1>
      </div>

      <div class="col-12">
        <p>
          Either view a map of the restaurants near you
        </p>
      </div>

      <div class="col-12">
        <nuxt-link to="/map">
          <button type="button" class="btn primary">
            Go to map
          </button>
        </nuxt-link>
      </div>

      <div class="col-12">
        <p class="mb-2"><strong>OR</strong><br/></p>
        <p>
          You can use our location wizard to find all restaurants within a specific city
        </p>
      </div>
      <div class="col-12">
        <nuxt-link to="/location-wizard/select-country">
          <button type="button" class="btn primary">
            Go to Location wizard
          </button>
        </nuxt-link>
      </div>
    </div>
  </div>
</template>

<script>

export default {
  data() {
    return {
      longitude: undefined,
      latitude: undefined,
      radius: 5000
    }
  }
}
</script>

