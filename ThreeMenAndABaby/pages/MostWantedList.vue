<template>
<div>
  <v-col>
    <p>{{ error }}</p>
    <v-card
      class="mx-auto text-center"
      color="darkblue"
      dark
      max-width="600"
    >
      <v-card-text>
        <v-sheet color="rgba(0, 0, 200, .12)">
          <v-sparkline
            :labels="eyeLabels"
            :value="eyeValues"
            color="rgba(255, 255, 255, .7)"
            height="100"
            padding="24"
            stroke-linecap="round"
            smooth
          >
            <template v-slot:label="item">
              {{ item.value }}
            </template>
          </v-sparkline>
        </v-sheet>
      </v-card-text>

      <v-card-text>
        <div class="display-1 font-weight-thin">
          Eye colour stats:
        </div>
      </v-card-text>

      <v-divider></v-divider>

      <v-card-actions class="justify-center">
        <v-btn
          block
          text
        >

        </v-btn>
      </v-card-actions>
    </v-card>
  </v-col>
  <v-col>
    <v-card
      class="mx-auto text-center"
      color="darkblue"
      dark
      max-width="600"
    >
      <v-card-text>
        <v-sheet color="rgba(0, 0, 200, .12)">
          <v-sparkline
            :labels="sexLabels"
            :value="sexValues"
            color="rgba(255, 255, 255, .7)"
            height="100"
            padding="24"
            stroke-linecap="round"
            smooth
          >
            <template v-slot:label="item">
              {{ item.value }}
            </template>
          </v-sparkline>
        </v-sheet>
      </v-card-text>

      <v-card-text>
        <div class="display-1 font-weight-thin">
          Gender stats:
        </div>
      </v-card-text>

      <v-divider></v-divider>

      <v-card-actions class="justify-center">
        <v-btn
          block
          text
        >

        </v-btn>
      </v-card-actions>
    </v-card>
  </v-col>
  <div>
    <v-treeview
      rounded
      hoverable
      activatable
      :items="items">
    </v-treeview>
    </div>
  </div>
</template>

<script>

  const JSON5 = require('json5');
  const axios = require('axios');

  export default {
    data(){
      return{
        eyeColour: [],
        hairColour: [],
        weightMax: [],
        sex: [],

        items: [],
        results: [],

        error: {},

        eyeValues: [],
        eyeLabels: [],
        greenEyes: 0,
        blueEyes: 0,
        brownEyes: 0,

        sexMale: 0,
        sexFemale: 0,
        sexValues: [],
        sexLabels: [],
        results: []
      }
    },
     async asyncData() {
      
      var errorMessage;
      var malformedDirtyJson;
      await axios.get(`https://api.fbi.gov/wanted/v1/list`).then((result)=>{malformedDirtyJson = JSON5.stringify(result.data);}).catch((error)=> {errorMessage = error;});
      //await axios.get(`https://api.fbi.gov/wanted/v1/list`).then((result)=>{malformedDirtyJson = JSON5.stringify(result.data);});
      if(!malformedDirtyJson) {return;}
      console.log(malformedDirtyJson);
      
      var sanitizedTheInvalidFBIJson = malformedDirtyJson.replace(new RegExp("None", "g"), "null");
      sanitizedTheInvalidFBIJson = sanitizedTheInvalidFBIJson.replace(new RegExp("\n", "g"), " ");
      sanitizedTheInvalidFBIJson = sanitizedTheInvalidFBIJson.replace(new RegExp("\r", "g"), " ");
      
      sanitizedTheInvalidFBIJson = sanitizedTheInvalidFBIJson.replace(new RegExp("(?<=[a-z])['](?=s)", "g"), "");
      sanitizedTheInvalidFBIJson = sanitizedTheInvalidFBIJson.replace(new RegExp("(?<=[0-9])['](?=[0-9])", "g"), "");
      

      var jsonObject = new JSON5.parse(
        sanitizedTheInvalidFBIJson
      );

      let eyeColour = [];
      let hairColour = [];
      let weightMax = [];
      let sex = [];

      let items = jsonObject["items"];
      let itemCount = items.length;
      
      let results = [];

      let greenEyes = 0;
      let blueEyes = 0;
      let brownEyes = 0;

      let sexMale = 0;
      let sexFemale = 0;

      let j = 0;
      for(var i = 0; i < itemCount; i++){
        var thisItem = items[i];
        var thisResult = {};
        thisResult["name"]  = thisItem["title"];
        thisResult["id"] = j++;

        switch(thisItem["eyes"])
        {
          case 'blue':
              blueEyes++;
              break;
          case 'green':
              greenEyes++;
              break;
          case 'brown':
              brownEyes++;
              break;
        }

        switch(thisItem["sex"])
        {
          case 'Male':
              sexMale++;
              break;
          case 'Female':
              sexFemale++;
              break;
        }

        var kids =
        [
          {name: "Eye-colour: " + thisItem["eyes"], id: j++},
          {name: "Hair-colour: " + thisItem["hair"], id: j++},
          {name: "Weight-max: " + thisItem["weight_max"], id: j++},
          {name: "Height-max: "+ thisItem["height_max"], id: j++},
          {name: "Sex: " + thisItem["sex"], id: j++},
          {name: "Description: " + thisItem["description"], id: j++},
          {name: "Publication: " + thisItem["publication"], id: j++},
          {name: "Location: " + thisItem["locations"], id: j++}
        ];

        thisResult["children"] = kids;

        results.push(thisResult);
      }

      let eyeLabels = [
        'blue',
        'green',
        'brown'
      ]; 

      let eyeValues = [
        blueEyes,
        greenEyes,
        brownEyes
      ];

      return {
        
        error: errorMessage,
        items: results,
        eyeLabels: [
          'blue',
          'green',
          'brown'
        ],
        eyeValues: [
          blueEyes,
          greenEyes,
          brownEyes
        ],
        sexLabels: [
          'male',
          'female'
        ],
        sexValues:[
          sexMale,
          sexFemale
        ]
        
      };
    }
  }
</script>