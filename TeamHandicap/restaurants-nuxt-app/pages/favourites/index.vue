<template>
    <div class="container">
        <div class="row">
            <div class="col-12">
                <h1>Favourites</h1>
            </div>

            <div v-if="favourites && favourites.length" class="col-12">
                <ul class="fav-list">
                    <li v-for="(favourite, index) in favourites" :key="'favourite' + favourite.id">
                        <div class="card">
                            <img v-if="favourite.restaurantThumbnail" class="card-img" :src="favourite.restaurantThumbnail" />
                            <img v-else class="card-img" src="@/assets/restaurant.png" />
                            <h3 class="my-0 py-10px">{{ favourite.restaurantName }}</h3>
                            {{ favourite.restaurantAddress }}<br/>
                            {{ favourite.restaurantContact }}
                            <nuxt-link :to="'/restaurant/' + favourite.restaurantId">
                                <button type="button" class="btn primary btn-top">
                                    Details
                                </button>
                            </nuxt-link>
                            <button type="button" class="btn primary btn-bottom" @click="deleteFavourite(index)">
                                Delete
                            </button>
                        </div>
                    </li>
                </ul>
            </div>
            <div v-else class="col-12">
                <em>You don't have any favourites yet.</em>
            </div>
        </div>
    </div>
</template>

<script src="./favourites.js"></script>
<style scoped lang="scss" rel="stylesheet/scss">
@import './favourites.scss';
</style>