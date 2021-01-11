<template>
    <TileSelect v-if="countryId" key="stateSelect" title="Choose your desired state" 
      :dataPath="'Zomato/States?countryId=' + countryId" :hasImg="false" tag="state" />
</template>

<script src="./select-state.js"></script>