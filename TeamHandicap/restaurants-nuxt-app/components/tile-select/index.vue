<template>
  <div class="row">
      <div class="col-12">
        <h1>
            {{ title }}
        </h1>
      </div>

      <div v-for="option in options" :key="tag + option.id" class="col-12 col-sm-6 col-md-4 col-lg-3 pb-20px">
          <div class="option-card" @click="$nuxt.$emit('selected', { tag, option })">
              <img v-if="hasImg" class="card-img" :src="option.imgUrl" />
              <h3 class="card-title">{{ option.name }}</h3>
          </div>
      </div>
    </div>
</template>

<script src="./tile-select"></script>
<style scoped lang="scss" rel="stylesheet/scss">
@import './tile-select.scss';
</style>
