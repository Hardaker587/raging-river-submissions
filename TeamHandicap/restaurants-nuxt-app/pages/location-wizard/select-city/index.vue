<template>
    <TileSelect v-if="dataPath" key="citySelect" title="Choose your desired city" 
      :dataPath="dataPath" :hasImg="false" tag="city" />
</template>

<script src="./select-city.js"></script>