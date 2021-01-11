<template>
    <div class="d-inline-block">
        <label :for="editable ? imgId : ''" :class="{ 'jwt-img-wrap': true, 'jwt-img-editable': editable }">
            <input v-if="editable" type="file" :id="imgId" name="file" accept="image/x-png,image/jpeg" @change="onImgUpload" />
            <img v-if="blobUrl" :class="imgClass" :src="blobUrl" @contextmenu="consumeEvent" />
            <img v-else-if="placeholderImgName" :class="imgClass" :src="require(`@/assets/${placeholderImgName}`)" />
            <div v-else :class="['d-inline-block', imgClass]"></div>
            <img v-if="processing" class="spinner" src="@/assets/loading.gif" alt="Loading..." />
        </label>
    </div>
</template>
    
<script src="./jwt-img.js"></script>
<style scoped lang="scss" rel="stylesheet/scss">
@import './jwt-img.scss';
</style>