<template>
    <div v-if="restaurant">
        <img v-if="restaurant.featured_image" class="featured-img" :src="restaurant.featured_image" />
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <h1 class="mb-0">{{ restaurant.name }}</h1>
                    <p v-if="restaurant.user_rating.votes" class="my-0 pb-20px">
                        Average rating of {{ restaurant.user_rating.aggregate_rating }} out of 5 from {{ restaurant.user_rating.votes }} ratings
                    </p>
                    <p v-else class="my-0 pb-20px">
                        <em>No ratings yet</em>
                    </p>
                    <p class="my-0 pb-20px">
                        <button type="button" class="btn primary" @click="setFavourite">
                            {{ restaurant.isFavourite ? 'Remove from favourites' : 'Add to favourites' }}
                        </button>
                    </p>
                    <div class="info-block">
                        <span class="label">Location</span>
                        {{ restaurant.location.address }}<br/>
                        <a target="_blank" :href="'https://www.google.com/maps/search/?api=1&query=' + restaurant.location.latitude + ',' + restaurant.location.longitude">View in maps</a>
                    </div>
                    <div class="info-block">
                        <span class="label">Operating hours</span>
                        {{ restaurant.timings }}
                    </div>
                    <div class="info-block">
                        <span class="label">Cost for two</span>
                        &plusmn;{{ restaurant.currency }} {{ restaurant.average_cost_for_two }}
                    </div>
                    <div class="info-block">
                        <span class="label">Phone number(s)</span>
                        {{ restaurant.phone_numbers }}
                    </div>
                    <div class="info-block">
                        <span class="label">Cuisines</span>
                        {{ restaurant.cuisines }}
                    </div>
                    <div class="info-block">
                        <span class="label">Highlights</span>
                        {{ restaurant.highlights.join(', ') }}
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script src="./restaurant.js"></script>
<style scoped lang="scss" rel="stylesheet/scss">
@import './restaurant.scss';
</style>