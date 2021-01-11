<template>
  <div class="container">
    <div class="row">
      <div class="col-12">
        <h1 v-if="cityId">
          Restaurants in {{ city.name }},
          {{ city.state ? city.state : city.country }}
        </h1>
        <h1 v-else>Restaurants near you</h1>
      </div>
    </div>
    <!-- <v-container fluid>
      <v-row align="center">
        <v-col class="d-flex" cols="12" sm="6">
          <v-select v-model="selectedCategory" :items="categories" label="Categories" item-text="name" item-value="id" return-object single-line outlined></v-select>
        </v-col>
        <v-col class="d-flex" cols="12" sm="6">
          <v-select v-model="selectedCuisine" :items="cuisines" label="cuisines" item-text="name" item-value="id" return-object single-line outlined></v-select>
        </v-col>
      </v-row>
    </v-container> -->
    <div class="row py-20px">
      <div class="col-12 col-sm-6">
        <div class="form-input-wrap">
          <label for="categories" class="form-input-label"> Categories </label>
          <select
            id="categories"
            name="categories"
            class="form-input"
            @change="categoryChanged"
          >
            <option value="-1">Any</option>
            <option
              v-for="category in categories"
              :key="'category' + category.id"
              :value="category.id"
            >
              {{ category.name }}
            </option>
          </select>
        </div>
      </div>
      <div class="col-12 col-sm-6">
        <div class="form-input-wrap">
          <label for="cuisines" class="form-input-label"> Cuisine </label>
          <select
            id="cuisines"
            name="cuisines"
            class="form-input"
            @change="cuisineChanged"
          >
            <option value="-1">Any</option>
            <option
              v-for="cuisine in cuisines"
              :key="'cuisine' + cuisine.id"
              :value="cuisine.id"
            >
              {{ cuisine.name }}
            </option>
          </select>
        </div>
      </div>
    </div>

    <div class="row">
      <div
        v-for="(restaurant, index) in restaurants.results"
        :key="'restaurant' + restaurant.id"
        class="col-12 col-sm-6 col-md-4 col-lg-3 pb-15px"
      >
        <div class="restaurant-card">
          <img
            v-if="restaurant.thumb"
            class="featured-img"
            :src="restaurant.thumb"
          />
          <img v-else class="featured-img" src="@/assets/restaurant.png" />
          <h3 class="title">
            {{ restaurant.name }}
            <span
              class="rating"
              :style="{
                backgroundColor: '#' + restaurant.user_rating.rating_color,
              }"
              >{{ restaurant.user_rating.aggregate_rating }}</span
            >
          </h3>
          <p class="locality">
            Near <em>{{ restaurant.location.locality }}</em>
          </p>
          <div class="card-btn-wrap">
            <nuxt-link :to="'/restaurant/' + restaurant.id">
              <button class="btn btn-left">Details</button>
            </nuxt-link>
            <button class="btn btn-right" @click="setFavourite(index)">
              <img
                v-if="!restaurant.isFavourite"
                class="fav-img"
                src="@/assets/add-favourite.png"
              />
              <img v-else class="fav-img" src="@/assets/red-heart.png" />
            </button>
          </div>
          <span v-if="restaurant.cuisines" class="card-label">{{
            restaurant.cuisines
          }}</span>
        </div>
      </div>
    </div>

    <div class="row">
      <div v-if="pageCount > 1" class="col-12 pt-30px text-right">
        <Paginator
          :pageIndex="curPageIndex"
          :pageCount="pageCount"
          :windowSize="5"
        />
      </div>
    </div>
  </div>
</template>

<script src="./restaurants.js"></script>
<style scoped lang="scss" rel="stylesheet/scss">
@import "./restaurants.scss";
</style>