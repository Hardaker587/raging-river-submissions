<template>
<div>
  <div>
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
  </div>
  <div>
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
  </div>
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

  const JSON5 = require('json5')

  export default {
    
     asyncData() {
      
      //const post = await $http.$get(`https://api.nuxtjs.dev/posts/${params.id}`)
      //return { post }

      var malformedDirtyJson = `{'total': 926, 'items': [{'ncic': None, 'eyes': None, 'remarks': None, 'height_max': None, 'weight': None, 'dates_of_birth_used': None, 'eyes_raw': None, 'weight_max': None, 'scars_and_marks': None, 'weight_min': None, 'details': '

The FBIâ€™s San Francisco Field Office, in conjunction with the San Francisco Police Department,\xa0is seeking the publicâ€™s assistance in identifying the person(s) responsible for the September 17, 2020, arson at St. Gregory the Illuminator Armenian Apostolic Church located at 51 Commonwealth Avenue in San Francisco, California.\xa0 The unknown perpetrator(s) set fire to the churchâ€™s administration building, which housed offices, a library, and a Sunday school.\xa0 The building sustained significant fire, smoke, and water damage. \xa0No one was injured.\xa0
\r\n

\xa0
', 'description': 'Arson at St. Gregory the Illuminator Armenian Apostolic Church\r\nSan Francisco, California\r\nSeptember 17, 2020', 'field_offices': ['sanfrancisco'], 'locations': None, 'publication': '2020-12-07T07:20:00', 'possible_countries': None, 'nationality': None, 'place_of_birth': None, 'coordinates': [], 'age_min': None, 'complexion': None, 'reward_max': 0, 'age_max': None, 'title': 'CHURCH ARSON', 'subjects': ['Seeking Information'], 'images': [{'original': 'https://www.fbi.gov/wanted/seeking-info/church-arson/@@images/image', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/church-arson/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/church-arson/@@images/image/large', 'caption': None}, {'original': 'https://www.fbi.gov/wanted/seeking-info/church-arson/stgregoryschurchinterior1.jpg', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/church-arson/stgregoryschurchinterior1.jpg/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/church-arson/stgregoryschurchinterior1.jpg/@@images/image/large', 'caption': ''}, {'original': 'https://www.fbi.gov/wanted/seeking-info/church-arson/stgregoryschurchinterior2.jpg', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/church-arson/stgregoryschurchinterior2.jpg/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/church-arson/stgregoryschurchinterior2.jpg/@@images/image/large', 'caption': ''}, {'original': 'https://www.fbi.gov/wanted/seeking-info/church-arson/stgregoryschurchinterior3.jpg', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/church-arson/stgregoryschurchinterior3.jpg/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/church-arson/stgregoryschurchinterior3.jpg/@@images/image/large', 'caption': ''}, {'original': 'https://www.fbi.gov/wanted/seeking-info/church-arson/stgregoryschurchinterior4.jpg', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/church-arson/stgregoryschurchinterior4.jpg/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/church-arson/stgregoryschurchinterior4.jpg/@@images/image/large', 'caption': ''}, {'original': 'https://www.fbi.gov/wanted/seeking-info/church-arson/stgregoryschurchinterior5.jpg', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/church-arson/stgregoryschurchinterior5.jpg/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/church-arson/stgregoryschurchinterior5.jpg/@@images/image/large', 'caption': ''}, {'original': 'https://www.fbi.gov/wanted/seeking-info/church-arson/stgregoryschurch2.jpg', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/church-arson/stgregoryschurch2.jpg/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/church-arson/stgregoryschurch2.jpg/@@images/image/large', 'caption': ''}, {'original': 'https://www.fbi.gov/wanted/seeking-info/church-arson/stgregoryschurch3.jpg', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/church-arson/stgregoryschurch3.jpg/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/church-arson/stgregoryschurch3.jpg/@@images/image/large', 'caption': ''}], 'additional_information': None, 'modified': '2020-12-25T23:51:08+00:00', 'reward_min': 0, 'build': None, 'race_raw': None, 'height_min': None, 'age_range': None, 'suspects': None, 'race': None, 'caution': None, 'sex': None, 'uid': 'ebf860f8987c4493adee22c639b34f4e', 'path': '/wanted/seeking-info/church-arson', 'hair': None, 'aliases': None, 'languages': None, 'hair_raw': None, 'status': 'na', 'warning_message': None, 'possible_states': None, 'occupations': None, 'files': [{'name': 'English', 'url': 'https://www.fbi.gov/wanted/seeking-info/church-arson/download.pdf'}], 'person_classification': 'Victim', 'reward_text': 'The FBI is offering a reward of up to $50,000 for information leading to the identification, arrest, and conviction of the individual(s) responsible for this crime.', 'url': 'https://www.fbi.gov/wanted/seeking-info/church-arson', 'legat_names': None, '@id': 'https://api.fbi.gov/@wanted-person/ebf860f8987c4493adee22c639b34f4e'}, {'ncic': None, 'eyes': None, 'remarks': None, 'height_max': None, 'weight': None, 'dates_of_birth_used': None, 'eyes_raw': None, 'weight_max': None, 'scars_and_marks': None, 'weight_min': None, 'details': '

On December 25, 2020, at approximately 5:30 a.m. Central Time, a large explosion occurred on 2nd Ave N near a downtown Nashville, Tennessee, business.\xa0 The explosion has been linked to a recreational vehicle (RV).\xa0 The Federal Bureau of Investigation (FBI), the Metro Nashville Police Department, and the Bureau of\xa0Alcohol, Tobacco, Firearms\xa0and Explosives (ATF) are currently looking for information concerning the operator or owner of this RV, which arrived in the area at approximately 1:22 a.m. Central Time.\xa0 In particular, individuals are being sought who were in the area of downtown Nashville around 1:00 a.m. Central Time.
\r\n

\xa0
', 'description': 'Nashville, Tennessee\r\nDecember 25, 2020', 'field_offices': ['memphis'], 'locations': None, 'publication': '2020-12-25T15:59:00', 'possible_countries': None, 'nationality': None, 'place_of_birth': None, 'coordinates': [], 'age_min': None, 'complexion': None, 'reward_max': 0, 'age_max': None, 'title': 'NASHVILLE EXPLOSION', 'subjects': ['Seeking Information', 'Case of the Week'], 'images': [{'original': 'https://www.fbi.gov/wanted/seeking-info/nashville-explosion/@@images/image', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/nashville-explosion/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/nashville-explosion/@@images/image/large', 'caption': None}], 'additional_information': None, 'modified': '2020-12-25T23:50:49+00:00', 'reward_min': 0, 'build': None, 'race_raw': None, 'height_min': None, 'age_range': None, 'suspects': None, 'race': None, 'caution': None, 'sex': None, 'uid': '6fcdd1e1dc2f4e24adef5f7a3ca77e98', 'path': '/wanted/seeking-info/nashville-explosion', 'hair': None, 'aliases': None, 'languages': None, 'hair_raw': None, 'status': 'na', 'warning_message': None, 'possible_states': None, 'occupations': None, 'files': [{'name': 'English', 'url': 'https://www.fbi.gov/wanted/seeking-info/nashville-explosion/download.pdf'}], 'person_classification': 'Main', 'reward_text': None, 'url': 'https://www.fbi.gov/wanted/seeking-info/nashville-explosion', 'legat_names': None, '@id': 'https://api.fbi.gov/@wanted-person/6fcdd1e1dc2f4e24adef5f7a3ca77e98'}, {'ncic': None, 'eyes': 'brown', 'remarks': '

Harris has previously resided in Durham, North Carolina.
\r\n

\xa0
', 'height_max': 73, 'weight': '184 pounds', 'dates_of_birth_used': ['October 16, 1994', 'March 11, 1996'], 'eyes_raw': 'Brown', 'weight_max': 184, 'scars_and_marks': 'Harris has tattoos on his neck and a tattoo over his right eye.', 'weight_min': 184, 'details': "

The FBI's Charlotte Field Office is assisting the Durham County Sheriff's Office in North Carolina with their search for Jerry Lamont Harris.
\r\n

Harris is wanted for his alleged involvement in the shooting of a Durham County Sheriff's Deputy on November 14, 2020, at approximately 10:15 a.m. The deputy was off-duty traveling in their own vehicle when a silver sedan with unknown occupants fired several shots into the deputy's car. The deputy was taken to a local hospital for treatment of non-life-threatening injuries. Investigation revealed the shooters to be Jerry Lamont Harris and an accomplice, who is currently in custody.
\r\n

On November 14, 2020, Harris was charged with assault with a deadly weapon inflicting serious injury, conspiracy to commit murder, and attempted first-degree murder by the State of North Carolina, Durham County, in the General Court of Justice, District Court Division, and a state warrant was issued for his arrest.
\r\n

\xa0
\r\n

\xa0
\r\n

\xa0
", 'description': 'Assault With a Deadly Weapon Inflicting Serious Injury; Conspiracy to Commit Murder; Attempted First-Degree Murder', 'field_offices': ['charlotte'], 'locations': None, 'publication': '2020-12-22T13:09:00', 'possible_countries': None, 'nationality': None, 'place_of_birth': None, 'coordinates': [], 'age_min': None, 'complexion': None, 'reward_max': 0, 'age_max': None, 'title': 'JERRY LAMONT HARRIS', 'subjects': ['Law Enforcement Assistance'], 'images': [{'original': 'https://www.fbi.gov/wanted/law-enforcement-assistance/jerry-lamont-harris/@@images/image', 'thumb': 'https://www.fbi.gov/wanted/law-enforcement-assistance/jerry-lamont-harris/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/law-enforcement-assistance/jerry-lamont-harris/@@images/image/large', 'caption': None}, {'original': 'https://www.fbi.gov/wanted/law-enforcement-assistance/jerry-lamont-harris/harris2.jpg', 'thumb': 'https://www.fbi.gov/wanted/law-enforcement-assistance/jerry-lamont-harris/harris2.jpg/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/law-enforcement-assistance/jerry-lamont-harris/harris2.jpg/@@images/image/large', 'caption': ''}], 'additional_information': None, 'modified': '2020-12-22T20:46:12+00:00', 'reward_min': 0, 'build': None, 'race_raw': 'Black', 'height_min': 73, 'age_range': None, 'suspects': None, 'race': 'black', 'caution': None, 'sex': 'Male', 'uid': '54f41dff5f644fdb9bc7c351b8a93ccb', 'path': '/wanted/law-enforcement-assistance/jerry-lamont-harris', 'hair': 'black', 'aliases': ['"JROCC"', 'Jerry Lamont Harris, Jr.', 'Jaquan Harris', 'Jaquan Lamond Harris', 'Jerry Harris', 'Jerry L. Harris', 'Jerry Lamount Harris'], 'languages': None, 'hair_raw': 'Black', 'status': 'na', 'warning_message': None, 'possible_states': None, 'occupations': None, 'files': [{'name': 'English', 'url': 'https://www.fbi.gov/wanted/law-enforcement-assistance/jerry-lamont-harris/download.pdf'}], 'person_classification': 'Main', 'reward_text': 'The FBI is offering a reward of up to $5,000 for information leading to the arrest of Jerry Lamont Harris.', 'url': 'https://www.fbi.gov/wanted/law-enforcement-assistance/jerry-lamont-harris', 'legat_names': None, '@id': 'https://api.fbi.gov/@wanted-person/54f41dff5f644fdb9bc7c351b8a93ccb'}, {'ncic': None, 'eyes': 'blue', 'remarks': '

Michaela Garecht was last seen wearing a white t-shirt with the word "Metro" across the front and pictures of people on the midsection. She had on denim pants rolled above her knees, black shoes, and wore three-inch pearl or white colored earrings which resembled feathers.
', 'height_max': 56, 'weight': '75 pounds (at time of disappearance)', 'dates_of_birth_used': ['January 24, 1979'], 'eyes_raw': 'Blue', 'weight_max': 75, 'scars_and_marks': None, 'weight_min': 75, 'details': '

Michaela Joy Garecht was nine-years-old when she was abducted by an unknown male assailant in the parking lot of the Rainbow Market in Hayward, California, on the morning of November 19, 1988. She was attempting to retrieve her friend\'s scooter that the abductor had moved closer to his vehicle while the girls were inside the market when she was grabbed by the assailant and pulled into a car. Garecht has not been seen or heard from since this date.
\r\n

\xa0
\r\n

At the time of the abduction, the suspect was described as being between 18 and 24 years old with a slender build. He was approximately 6\'0" and 180 pounds with dirty blond, shoulder-length hair. He had a pockmarked or pimpled face. He was driving an older model, full-sized four-door sedan, possibly gold or tan in color, with damage to the front bumper.
\r\n

\xa0
\r\n

An individual has been charged by the Alameda County District Attorney\'s Office for the murder of Michaela Garecht and is awaiting trial.\xa0\xa0The FBI and the Hayward Police Department continue to seek information from the public that would assist in locating\xa0Michaela.
\r\n

\xa0
', 'description': 'November 19, 1988\r\nHayward, California', 'field_offices': ['sanfrancisco'], 'locations': None, 'publication': '2010-09-10T09:20:00', 'possible_countries': None, 'nationality': None, 'place_of_birth': None, 'coordinates': [], 'age_min': None, 'complexion': None, 'reward_max': 0, 'age_max': None, 'title': 'MICHAELA JOY GARECHT', 'subjects': ['Kidnappings and Missing Persons'], 'images': [{'original': 'https://www.fbi.gov/wanted/kidnap/michaela-joy-garecht/@@images/image', 'thumb': 'https://www.fbi.gov/wanted/kidnap/michaela-joy-garecht/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/kidnap/michaela-joy-garecht/@@images/image/large', 'caption': None}, {'original': 'https://www.fbi.gov/wanted/kidnap/michaela-joy-garecht/garecht_mj2.jpg', 'thumb': 'https://www.fbi.gov/wanted/kidnap/michaela-joy-garecht/garecht_mj2.jpg/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/kidnap/michaela-joy-garecht/garecht_mj2.jpg/@@images/image/large', 'caption': ''}, {'original': 'https://www.fbi.gov/wanted/kidnap/michaela-joy-garecht/garecht_mj3.jpg', 'thumb': 'https://www.fbi.gov/wanted/kidnap/michaela-joy-garecht/garecht_mj3.jpg/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/kidnap/michaela-joy-garecht/garecht_mj3.jpg/@@images/image/large', 'caption': ''}, {'original': 'https://www.fbi.gov/wanted/kidnap/michaela-joy-garecht/garecht_mjsuspect.jpg', 'thumb': 'https://www.fbi.gov/wanted/kidnap/michaela-joy-garecht/garecht_mjsuspect.jpg/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/kidnap/michaela-joy-garecht/garecht_mjsuspect.jpg/@@images/image/large', 'caption': ''}, {'original': 'https://www.fbi.gov/wanted/kidnap/michaela-joy-garecht/garecht_mjsuspect2.jpg', 'thumb': 'https://www.fbi.gov/wanted/kidnap/michaela-joy-garecht/garecht_mjsuspect2.jpg/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/kidnap/michaela-joy-garecht/garecht_mjsuspect2.jpg/@@images/image/large', 'caption': ''}], 'additional_information': None, 'modified': '2020-12-21T20:42:02+00:00', 'reward_min': 0, 'build': None, 'race_raw': 'White', 'height_min': 56, 'age_range': None, 'suspects': None, 'race': 'white', 'caution': None, 'sex': 'Female', 'uid': '5e8732802f7e519b6ce13882e8fab0fd', 'path': '/wanted/kidnap/michaela-joy-garecht', 'hair': 'blond', 'aliases': None, 'languages': None, 'hair_raw': 'Blonde', 'status': 'na', 'warning_message': None, 'possible_states': None, 'occupations': None, 'files': [{'name': 'English', 'url': 'https://www.fbi.gov/wanted/kidnap/michaela-joy-garecht/download.pdf'}], 'person_classification': 'Main', 'reward_text': None, 'url': 'https://www.fbi.gov/wanted/kidnap/michaela-joy-garecht', 'legat_names': None, '@id': 'https://api.fbi.gov/@wanted-person/5e8732802f7e519b6ce13882e8fab0fd'}, {'ncic': None, 'eyes': 'blue', 'remarks': '

Linda Stoltzfoos was a member of the Amish community. She was last seen wearing a tan dress, white apron, and black head covering.
', 'height_max': 70, 'weight': 'Approximately 125 pounds', 'dates_of_birth_used': ['November 18, 2001'], 'eyes_raw': 'Blue', 'weight_max': 125, 'scars_and_marks': None, 'weight_min': 125, 'details': "

The Federal Bureau of Investigation's Philadelphia Field Office and the East Lampeter Township Police Department in Pennsylvania are seeking the public's assistance in locating Linda Stoltzfoos.\xa0 Linda has been missing since Father's Day, Sunday, June 21, 2020, when she didn't return home after a church service.\xa0 She was last observed at a farm on Stumptown Road, between the intersection of Beechdale Road and Gibbons Road in Bird-in-Hand, Lancaster County, Pennsylvania.
\r\n

An individual has been charged by the Lancaster County District Attorney's Office for the kidnapping and murder of Linda Stoltzfoos and is awaiting trial. The FBI and the East Lampeter Township Police Department continue to seek information from the public that would assist in locating Linda.
\r\n

\xa0
", 'description': 'June 21, 2020\r\nLancaster County, Pennsylvania', 'field_offices': ['philadelphia'], 'locations': None, 'publication': '2020-06-29T12:49:00', 'possible_countries': None, 'nationality': None, 'place_of_birth': None, 'coordinates': [], 'age_min': None, 'complexion': None, 'reward_max': 0, 'age_max': None, 'title': 'LINDA STOLTZFOOS', 'subjects': ['Kidnappings and Missing Persons'], 'images': [{'original': 'https://www.fbi.gov/wanted/kidnap/linda-stoltzfoos/@@images/image', 'thumb': 'https://www.fbi.gov/wanted/kidnap/linda-stoltzfoos/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/kidnap/linda-stoltzfoos/@@images/image/large', 'caption': None}], 'additional_information': None, 'modified': '2020-12-21T20:08:27+00:00', 'reward_min': 0, 'build': None, 'race_raw': 'White', 'height_min': 70, 'age_range': None, 'suspects': None, 'race': 'white', 'caution': None, 'sex': 'Female', 'uid': 'e2e6dee530314e8db3c141c142766f01', 'path': '/wanted/kidnap/linda-stoltzfoos', 'hair': 'brown', 'aliases': None, 'languages': None, 'hair_raw': 'Brown', 'status': 'na', 'warning_message': None, 'possible_states': None, 'occupations': None, 'files': [{'name': 'English', 'url': 'https://www.fbi.gov/wanted/kidnap/linda-stoltzfoos/download.pdf'}], 'person_classification': 'Victim', 'reward_text': 'The FBI is offering a reward of up to $10,000 for information leading to the recovery of Linda Stoltzfoos and the conviction of the subject(s) responsible for her disappearance.', 'url': 'https://www.fbi.gov/wanted/kidnap/linda-stoltzfoos', 'legat_names': None, '@id': 'https://api.fbi.gov/@wanted-person/e2e6dee530314e8db3c141c142766f01'}, {'ncic': 'W416164431', 'eyes': 'brown', 'remarks': None, 'height_max': 69, 'weight': '140 pounds', 'dates_of_birth_used': ['September 3, 1988'], 'eyes_raw': 'Brown', 'weight_max': 140, 'scars_and_marks': None, 'weight_min': 140, 'details': None, 'description': 'Possession of a Controlled Substance, Possession with Intent to Distribute Controlled Substances, and Possession of Firearm in Furtherance of Drug Trafficking', 'field_offices': ['sanjuan'], 'locations': None, 'publication': '2019-03-26T14:01:00', 'possible_countries': None, 'nationality': 'Natera-Abreu has dual citizenship in the Dominican Republic and the United States.', 'place_of_birth': 'Dominican Republic', 'coordinates': [], 'age_min': None, 'complexion': None, 'reward_max': 0, 'age_max': None, 'title': 'VLADIMIR NATERA-ABREU', 'subjects': ['Criminal Enterprise Investigations'], 'images': [{'original': 'https://www.fbi.gov/wanted/cei/vladimir-natera-abreu/@@images/image', 'thumb': 'https://www.fbi.gov/wanted/cei/vladimir-natera-abreu/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/cei/vladimir-natera-abreu/@@images/image/large', 'caption': None}], 'additional_information': None, 'modified': '2020-12-21T15:51:34+00:00', 'reward_min': 0, 'build': None, 'race_raw': 'White (Hispanic)', 'height_min': 69, 'age_range': None, 'suspects': None, 'race': 'hispanic', 'caution': '

On February 20, 2019, 75 subjects of the LAS FARC drug-trafficking organization were indicted for drug trafficking and firearms charges. From approximately 2007, members of LAS FARC have been allegedly involved in the large scale distribution of cocaine, crack cocaine, heroin, and marijuana in the Barrio Obrero area of San Juan, Puerto Rico. LAS FARC maintains control over their organization through the use of alleged violence. Natera-Abreu was a leader in the organization and is currently believed to be in Santo Domingo, Dominican Republic or San Juan, Puerto Rico.
\r\n

An arrest warrant was issued on February 20, 2019, by the United States District Court, Judicial District of Puerto Rico, after Natera-Abreu was charged federally with possession of a controlled substance, possession with intent to distribute controlled substances, and possession of firearm in furtherance of drug trafficking.
', 'sex': 'Male', 'uid': '1d4b58c92576494e8582e4a1983fb960', 'path': '/wanted/cei/vladimir-natera-abreu', 'hair': 'brown', 'aliases': ['Vladi', 'Flako'], 'languages': ['Spanish'], 'hair_raw': 'Brown', 'status': 'captured', 'warning_message': None, 'possible_states': None, 'occupations': None, 'files': [{'name': 'English', 'url': 'https://www.fbi.gov/wanted/cei/vladimir-natera-abreu/download.pdf'}], 'person_classification': 'Main', 'reward_text': None, 'url': 'https://www.fbi.gov/wanted/cei/vladimir-natera-abreu', 'legat_names': None, '@id': 'https://api.fbi.gov/@wanted-person/1d4b58c92576494e8582e4a1983fb960'}, {'ncic': None, 'eyes': None, 'remarks': None, 'height_max': None, 'weight': None, 'dates_of_birth_used': None, 'eyes_raw': None, 'weight_max': None, 'scars_and_marks': None, 'weight_min': None, 'details': "

The Federal Bureau of Investigation's Los Angeles Field Office's Art Crime Team in California is seeking the public's assistance with information regarding the theft of a 1710 Amati violin from a residence in the Los Feliz area of Los Angeles on December 8, 2020.
\r\n

The violin's measurements are as follows:
\r\n

Length of back - 35.3 centimeters
\r\n

Upper bouts - 16.8 centimeters
\r\n

Middle bouts - 11.2 centimeters
\r\n

Lower bouts - 20.4 centimeters
", 'description': 'Los Angeles, California\r\nDecember 8, 2020', 'field_offices': ['losangeles'], 'locations': None, 'publication': '2020-12-17T14:05:00', 'possible_countries': None, 'nationality': None, 'place_of_birth': None, 'coordinates': [], 'age_min': None, 'complexion': None, 'reward_max': 0, 'age_max': None, 'title': 'STOLEN 1710 AMATI VIOLIN', 'subjects': ['Seeking Information'], 'images': [{'original': 'https://www.fbi.gov/wanted/seeking-info/stolen-violin/@@images/image', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/stolen-violin/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/stolen-violin/@@images/image/large', 'caption': None}, {'original': 'https://www.fbi.gov/wanted/seeking-info/stolen-violin/l42905back.jpg', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/stolen-violin/l42905back.jpg/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/stolen-violin/l42905back.jpg/@@images/image/large', 'caption': ''}, {'original': 'https://www.fbi.gov/wanted/seeking-info/stolen-violin/l42905head.jpg', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/stolen-violin/l42905head.jpg/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/stolen-violin/l42905head.jpg/@@images/image/large', 'caption': ''}, {'original': 'https://www.fbi.gov/wanted/seeking-info/stolen-violin/42905_label.jpg', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/stolen-violin/42905_label.jpg/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/stolen-violin/42905_label.jpg/@@images/image/large', 'caption': ''}, {'original': 'https://www.fbi.gov/wanted/seeking-info/stolen-violin/l42905treb.jpg', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/stolen-violin/l42905treb.jpg/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/stolen-violin/l42905treb.jpg/@@images/image/large', 'caption': ''}], 'additional_information': None, 'modified': '2020-12-18T16:52:25+00:00', 'reward_min': 0, 'build': None, 'race_raw': None, 'height_min': None, 'age_range': None, 'suspects': None, 'race': None, 'caution': None, 'sex': None, 'uid': '6591210f65564be59a619b67d1d8e4a6', 'path': '/wanted/seeking-info/stolen-violin', 'hair': None, 'aliases': None, 'languages': None, 'hair_raw': None, 'status': 'na', 'warning_message': None, 'possible_states': None, 'occupations': None, 'files': [{'name': 'English', 'url': 'https://www.fbi.gov/wanted/seeking-info/stolen-violin/download.pdf'}], 'person_classification': 'Main', 'reward_text': None, 'url': 'https://www.fbi.gov/wanted/seeking-info/stolen-violin', 'legat_names': None, '@id': 'https://api.fbi.gov/@wanted-person/6591210f65564be59a619b67d1d8e4a6'}, {'ncic': None, 'eyes': 'brown', 'remarks': None, 'height_max': 70, 'weight': '180 pounds', 'dates_of_birth_used': ['October 25, 1984'], 'eyes_raw': 'Brown', 'weight_max': 180, 'scars_and_marks': None, 'weight_min': 180, 'details': "

The Federal Bureau of Investigation's Albuquerque Field Office is asking for the public's assistance in identifying the person(s) responsible for the homicide of Donnie Wade Barney.
\r\n

\xa0
\r\n

On August 19, 2017, Barney's body was discovered inside a hogan - a traditional Navajo hut of logs and earth - on Shadow Farm Road in Rehoboth, New Mexico. An autopsy indicated Barney died from stab wounds to his torso.
", 'description': 'Homicide Victim\r\nRehoboth, New Mexico\r\nAugust 19, 2017', 'field_offices': ['albuquerque'], 'locations': None, 'publication': '2018-08-01T13:12:00', 'possible_countries': None, 'nationality': None, 'place_of_birth': None, 'coordinates': [], 'age_min': None, 'complexion': None, 'reward_max': 0, 'age_max': None, 'title': 'DONNIE WADE BARNEY', 'subjects': ['Seeking Information'], 'images': [{'original': 'https://www.fbi.gov/wanted/seeking-info/donnie-wade-barney/@@images/image', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/donnie-wade-barney/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/donnie-wade-barney/@@images/image/large', 'caption': 'Photograph taken in 2016'}], 'additional_information': None, 'modified': '2020-12-18T16:34:00+00:00', 'reward_min': 0, 'build': None, 'race_raw': 'Native American', 'height_min': 70, 'age_range': None, 'suspects': None, 'race': 'native', 'caution': None, 'sex': 'Male', 'uid': '464b182870d54a15999b68117bda9912', 'path': '/wanted/seeking-info/donnie-wade-barney', 'hair': 'black', 'aliases': None, 'languages': None, 'hair_raw': 'Black', 'status': 'na', 'warning_message': None, 'possible_states': None, 'occupations': None, 'files': [{'name': 'English', 'url': 'https://www.fbi.gov/wanted/seeking-info/donnie-wade-barney/download.pdf'}, {'name': 'DINÃ‰ BIZAAD Kâ€™EHGO', 'url': 'https://www.fbi.gov/wanted/seeking-info/donnie-wade-barney/barney-navajo-12-4-2020.pdf/@@download/file/Barney Navajo 12-4-2020.pdf'}], 'person_classification': 'Victim', 'reward_text': 'The FBI is offering a reward of up to $1,000 for information leading to the arrest and conviction of the person or persons responsible for the death of Donnie Wade Barney.', 'url': 'https://www.fbi.gov/wanted/seeking-info/donnie-wade-barney', 'legat_names': None, '@id': 'https://api.fbi.gov/@wanted-person/464b182870d54a15999b68117bda9912'}, {'ncic': 'W791663302', 'eyes': 'brown', 'remarks': '

Onica may have ties to Atlanta, Georgia; Las Vegas, Nevada; and New York, New York.
', 'height_max': 72, 'weight': '200 pounds', 'dates_of_birth_used': [' August 23, 1975'], 'eyes_raw': 'Brown', 'weight_max': 200, 'scars_and_marks': None, 'weight_min': 200, 'details': None, 'description': 'Conspiracy to Commit Access Device Fraud', 'field_offices': ['jacksonville'], 'locations': None, 'publication': '2020-09-03T08:00:00', 'possible_countries': None, 'nationality': 'Romanian', 'place_of_birth': None, 'coordinates': [], 'age_min': None, 'complexion': None, 'reward_max': 0, 'age_max': None, 'title': 'NELU ONICA', 'subjects': ['White-Collar Crime'], 'images': [{'original': 'https://www.fbi.gov/wanted/wcc/nelu-onica/@@images/image', 'thumb': 'https://www.fbi.gov/wanted/wcc/nelu-onica/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/wcc/nelu-onica/@@images/image/large', 'caption': None}], 'additional_information': None, 'modified': '2020-12-18T15:39:14+00:00', 'reward_min': 0, 'build': None, 'race_raw': 'White', 'height_min': 72, 'age_range': None, 'suspects': None, 'race': 'white', 'caution': '

Nelu Onica is wanted\xa0for\xa0his alleged involvement in a large Romanian ATM skimming ring based in Atlanta, Georgia. The group is\xa0\u200ballegedly\xa0responsible for the theft of over $1.2 million dollars\u200b. They allegedly\xa0conducted their skimming and â€œcash-outâ€ operations throughout the country, to include\xa0Jacksonville, Florida; Atlanta, Georgia; New Orleans, Louisiana; New York, New York; Memphis, Tennessee; Charlotte, North Carolina; and Mobile, Alabama.
\r\n

\xa0
\r\n

On August 20, 2020, a federal arrest warrant was issued for Onica after he was charged with conspiracy to commit access device fraud by the United States District Court for the Middle District of Florida.
\r\n

\xa0
', 'sex': 'Male', 'uid': '4cc6edfd4940480fac2c73300f8b3dec', 'path': '/wanted/wcc/nelu-onica', 'hair': 'black', 'aliases': ['Nelu Stoijanov', 'Brandt Aksel'], 'languages': None, 'hair_raw': 'Black', 'status': 'na', 'warning_message': None, 'possible_states': None, 'occupations': None, 'files': [{'name': 'English', 'url': 'https://www.fbi.gov/wanted/wcc/nelu-onica/download.pdf'}], 'person_classification': 'Main', 'reward_text': None, 'url': 'https://www.fbi.gov/wanted/wcc/nelu-onica', 'legat_names': None, '@id': 'https://api.fbi.gov/@wanted-person/4cc6edfd4940480fac2c73300f8b3dec'}, {'ncic': None, 'eyes': 'brown', 'remarks': None, 'height_max': None, 'weight': None, 'dates_of_birth_used': ['January 1, 1981'], 'eyes_raw': 'Brown', 'weight_max': None, 'scars_and_marks': None, 'weight_min': None, 'details': None, 'description': 'Conspiracy to Commit Interstate Harassment; Unlawful Conspiracy to Transfer Means of Identification', 'field_offices': ['washingtondc'], 'locations': None, 'publication': '2020-12-17T08:13:00', 'possible_countries': None, 'nationality': 'Chinese', 'place_of_birth': 'Hangzhou, Zhejiang Province, China', 'coordinates': [], 'age_min': None, 'complexion': None, 'reward_max': 0, 'age_max': None, 'title': 'XINJIANG JIN', 'subjects': ['Counterintelligence'], 'images': [{'original': 'https://www.fbi.gov/wanted/counterintelligence/xinjiang-jin/@@images/image', 'thumb': 'https://www.fbi.gov/wanted/counterintelligence/xinjiang-jin/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/counterintelligence/xinjiang-jin/@@images/image/large', 'caption': None}, {'original': 'https://www.fbi.gov/wanted/counterintelligence/xinjiang-jin/jin2.jpg', 'thumb': 'https://www.fbi.gov/wanted/counterintelligence/xinjiang-jin/jin2.jpg/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/counterintelligence/xinjiang-jin/jin2.jpg/@@images/image/large', 'caption': ''}, {'original': 'https://www.fbi.gov/wanted/counterintelligence/xinjiang-jin/jin3.jpg', 'thumb': 'https://www.fbi.gov/wanted/counterintelligence/xinjiang-jin/jin3.jpg/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/counterintelligence/xinjiang-jin/jin3.jpg/@@images/image/large', 'caption': ''}], 'additional_information': None, 'modified': '2020-12-18T13:20:15+00:00', 'reward_min': 0, 'build': 'Medium', 'race_raw': 'Asian', 'height_min': None, 'age_range': None, 'suspects': None, 'race': 'asian', 'caution': '

Xinjiang Jin is wanted for his alleged role in an unlawful conspiracy to commit interstate harassment and an unlawful conspiracy to transfer means of identification when he allegedly engaged in unlawful activity to terminate and/or make accessible information about the communication accounts of persons in the United States at the behest of the Chinese governmentâ€™s intelligence and security services in the United States and China between January of 2019 and November of 2020.\xa0 A federal arrest warrant was issued for Jin on November 19, 2020, in the United States District Court, Eastern District of New York, Brooklyn, New York, after Jin was charged with conspiracy to commit interstate harassment and unlawful conspiracy to transfer means of identification.
\r\n

\xa0
', 'sex': 'Male', 'uid': '653eb7b9f63f4e0983d808f112f99868', 'path': '/wanted/counterintelligence/xinjiang-jin', 'hair': 'black', 'aliases': ['Jin Xinjiang', 'Julien Jin'], 'languages': ['Chinese'], 'hair_raw': 'Black', 'status': 'na', 'warning_message': None, 'possible_states': None, 'occupations': ['Software Engineer'], 'files': [{'name': 'English', 'url': 'https://www.fbi.gov/wanted/counterintelligence/xinjiang-jin/download.pdf'}], 'person_classification': 'Main', 'reward_text': None, 'url': 'https://www.fbi.gov/wanted/counterintelligence/xinjiang-jin', 'legat_names': None, '@id': 'https://api.fbi.gov/@wanted-person/653eb7b9f63f4e0983d808f112f99868'}, {'ncic': None, 'eyes': 'brown', 'remarks': "

Burns' last residence was in\xa0Berkeley Lake, Georgia.\xa0\xa0The vehicle he was driving was found abandoned in Dunwoody, Georgia.
", 'height_max': 74, 'weight': '240 pounds', 'dates_of_birth_used': ['December 11, 1982'], 'eyes_raw': 'Brown', 'weight_max': 240, 'scars_and_marks': 'Burns has a tattoo on his left forearm of three black triangles interlaced.', 'weight_min': 240, 'details': None, 'description': 'Mail Fraud', 'field_offices': ['atlanta'], 'locations': None, 'publication': '2020-12-09T09:56:00', 'possible_countries': None, 'nationality': 'American', 'place_of_birth': 'Wayne, Pennsylvania', 'coordinates': [], 'age_min': None, 'complexion': None, 'reward_max': 0, 'age_max': None, 'title': 'CHRISTOPHER W. BURNS', 'subjects': ['White-Collar Crime'], 'images': [{'original': 'https://www.fbi.gov/wanted/wcc/christopher-w-burns/@@images/image', 'thumb': 'https://www.fbi.gov/wanted/wcc/christopher-w-burns/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/wcc/christopher-w-burns/@@images/image/large', 'caption': None}, {'original': 'https://www.fbi.gov/wanted/wcc/christopher-w-burns/burns2.jpg', 'thumb': 'https://www.fbi.gov/wanted/wcc/christopher-w-burns/burns2.jpg/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/wcc/christopher-w-burns/burns2.jpg/@@images/image/large', 'caption': ''}], 'additional_information': None, 'modified': '2020-12-17T18:43:36+00:00', 'reward_min': 0, 'build': None, 'race_raw': 'White', 'height_min': 74, 'age_range': None, 'suspects': None, 'race': 'white', 'caution': '

Christopher W. Burns is wanted for his alleged involvement in a mail fraud scheme in Georgia.\xa0 It is alleged that Burns defrauded a number of victims out of hundreds of thousands of dollars. As part of his scheme, Burns allegedly falsely told victims that he was investing their money in a â€œpeer\xa0to peerâ€ lending program in which loans were backed by collateral. In reality, the collateral promised by Burns either did not exist at all or was worth substantially less than Burns represented.\xa0 He has not been seen since he left his home on September 24, 2020, one day before he was supposed to turn over documents related to his businesses to the Securities and Exchange Commission.\xa0 A federal arrest warrant was issued for Burns on October 23, 2020, in the United States District Court, Northern District of Georgia, Atlanta, Georgia, after he was charged with mail fraud.
\r\n

\xa0
', 'sex': 'Male', 'uid': '7b5d931ebb03419b8ddaa43a80de62a3', 'path': '/wanted/wcc/christopher-w-burns', 'hair': 'brown', 'aliases': None, 'languages': None, 'hair_raw': 'Brown', 'status': 'na', 'warning_message': None, 'possible_states': None, 'occupations': ['Registered Investment Advisor'], 'files': [{'name': 'English', 'url': 'https://www.fbi.gov/wanted/wcc/christopher-w-burns/download.pdf'}], 'person_classification': 'Main', 'reward_text': None, 'url': 'https://www.fbi.gov/wanted/wcc/christopher-w-burns', 'legat_names': None, '@id': 'https://api.fbi.gov/@wanted-person/7b5d931ebb03419b8ddaa43a80de62a3'}, {'ncic': None, 'eyes': 'brown', 'remarks': '

Amber Aiaz was last seen wearing a black shirt, a black vest, fitted black pants with white writing, and light-colored shoes.
', 'height_max': 69, 'weight': '180 pounds', 'dates_of_birth_used': None, 'eyes_raw': 'Brown', 'weight_max': 180, 'scars_and_marks': None, 'weight_min': 180, 'details': '

Amber Aiaz and her daughter, Melissa Fu, were last seen on Friday, November 22, 2019, at approximately 6:00 p.m. at their residence located in the area of Michelson Drive and University Drive in Irvine, California. There are suspicious circumstances surrounding their disappearance, and two people seen in the vicinity of their residence near the time of their disappearance are being sought for questioning.
\r\n

The unknown individuals are possibly associated with a black Cadillac, unknown model. They are described as follows:
\r\n

A Chinese female in her 40s, approximately 5\'8" with an average build, and black hair worn in a bun.
\r\n

A Chinese male in his 40s, approximately 5\'10", weighing 190 pounds, with an average build, and short black hair.
', 'description': 'November 22, 2019\r\nIrvine, California', 'field_offices': ['losangeles'], 'locations': None, 'publication': '2020-12-02T11:21:00', 'possible_countries': None, 'nationality': None, 'place_of_birth': None, 'coordinates': [], 'age_min': 34, 'complexion': None, 'reward_max': 0, 'age_max': 34, 'title': 'AMBER AIAZ', 'subjects': ['Kidnappings and Missing Persons'], 'images': [{'original': 'https://www.fbi.gov/wanted/kidnap/amber-aiaz/@@images/image', 'thumb': 'https://www.fbi.gov/wanted/kidnap/amber-aiaz/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/kidnap/amber-aiaz/@@images/image/large', 'caption': 'Amber Aiaz'}, {'original': 'https://www.fbi.gov/wanted/kidnap/amber-aiaz/fu.png', 'thumb': 'https://www.fbi.gov/wanted/kidnap/amber-aiaz/fu.png/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/kidnap/amber-aiaz/fu.png/@@images/image/large', 'caption': 'Melissa Fu'}], 'additional_information': None, 'modified': '2020-12-17T15:13:47+00:00', 'reward_min': 0, 'build': None, 'race_raw': 'Asian', 'height_min': 69, 'age_range': '34 years old (at time of disappearance)', 'suspects': None, 'race': 'asian', 'caution': None, 'sex': 'Female', 'uid': '917daef377654aedac2b1479f4082b6f', 'path': '/wanted/kidnap/amber-aiaz', 'hair': 'black', 'aliases': ['Mei Yi Wu'], 'languages': None, 'hair_raw': 'Black', 'status': 'na', 'warning_message': None, 'possible_states': None, 'occupations': None, 'files': [{'name': 'English', 'url': 'https://www.fbi.gov/wanted/kidnap/amber-aiaz/download.pdf'}], 'person_classification': 'Main', 'reward_text': None, 'url': 'https://www.fbi.gov/wanted/kidnap/amber-aiaz', 'legat_names': None, '@id': 'https://api.fbi.gov/@wanted-person/917daef377654aedac2b1479f4082b6f'}, {'ncic': None, 'eyes': 'brown', 'remarks': '

Fu was last seen wearing a black tracksuit.
', 'height_max': 71, 'weight': '200 pounds', 'dates_of_birth_used': None, 'eyes_raw': 'Brown', 'weight_max': 200, 'scars_and_marks': None, 'weight_min': 200, 'details': '

Melissa Fu and her mother, Amber Aiaz, were last seen on Friday, November 22, 2019, at approximately 6:00 p.m. at their residence located in the area of Michelson Drive and University Drive in Irvine, California. There are suspicious circumstances surrounding their disappearance, and two people seen in the vicinity of their residence near the time of their disappearance are being sought for questioning.
\r\n

The unknown individuals are possibly associated with a black Cadillac, unknown model. They are described as follows:
\r\n

A Chinese female in her 40s, approximately 5\'8" with an average build, and black hair worn in a bun.
\r\n

A Chinese male in his 40s, approximately 5\'10", weighing 190 pounds, with an average build, and short black hair.
', 'description': 'November 22, 2019\r\nIrvine, California', 'field_offices': ['losangeles'], 'locations': None, 'publication': '2020-12-02T11:21:00', 'possible_countries': None, 'nationality': None, 'place_of_birth': None, 'coordinates': [], 'age_min': 13, 'complexion': None, 'reward_max': 0, 'age_max': 13, 'title': 'MELISSA FU', 'subjects': ['Kidnappings and Missing Persons'], 'images': [{'original': 'https://www.fbi.gov/wanted/kidnap/melissa-fu/@@images/image', 'thumb': 'https://www.fbi.gov/wanted/kidnap/melissa-fu/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/kidnap/melissa-fu/@@images/image/large', 'caption': 'Melissa Fu'}, {'original': 'https://www.fbi.gov/wanted/kidnap/melissa-fu/aiaz.png', 'thumb': 'https://www.fbi.gov/wanted/kidnap/melissa-fu/aiaz.png/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/kidnap/melissa-fu/aiaz.png/@@images/image/large', 'caption': 'Amber Aiaz'}], 'additional_information': None, 'modified': '2020-12-17T15:13:24+00:00', 'reward_min': 0, 'build': None, 'race_raw': 'Asian', 'height_min': 71, 'age_range': '13 years old (at time of disappearance)', 'suspects': None, 'race': 'asian', 'caution': None, 'sex': 'Female', 'uid': '9552a3c624834e47ab4b27b489ffab70', 'path': '/wanted/kidnap/melissa-fu', 'hair': 'brown', 'aliases': None, 'languages': None, 'hair_raw': 'Dark brown', 'status': 'na', 'warning_message': None, 'possible_states': None, 'occupations': None, 'files': [{'name': 'English', 'url': 'https://www.fbi.gov/wanted/kidnap/melissa-fu/download.pdf'}], 'person_classification': 'Main', 'reward_text': None, 'url': 'https://www.fbi.gov/wanted/kidnap/melissa-fu', 'legat_names': None, '@id': 'https://api.fbi.gov/@wanted-person/9552a3c624834e47ab4b27b489ffab70'}, {'ncic': None, 'eyes': None, 'remarks': None, 'height_max': None, 'weight': None, 'dates_of_birth_used': None, 'eyes_raw': None, 'weight_max': None, 'scars_and_marks': None, 'weight_min': None, 'details': "

The Federal Bureau of Investigation's Albuquerque Field Office and the Navajo Nation Division of Public Safety in New Mexico are asking for the public's assistance in identifying the person(s) responsible for the homicide of Keith Travis Nastacio .
\r\n

\xa0
\r\n

On July 15, 2019, Nastacio's body was found in the trunk of a light-colored Dodge Avenger SXT that was discovered on fire off of Pipeline Road, in an isolated area north of Church Rock, New Mexico, on the Navajo Nation reservation. Nastacio, of Zuni, New Mexico, was 51 years old at the time of his death.
", 'description': 'Homicide Victim\r\nChurch Rock, New Mexico\r\nJuly 15, 2019', 'field_offices': ['albuquerque'], 'locations': None, 'publication': '2019-10-23T13:30:00', 'possible_countries': None, 'nationality': None, 'place_of_birth': None, 'coordinates': [], 'age_min': None, 'complexion': None, 'reward_max': 0, 'age_max': None, 'title': 'KEITH TRAVIS NASTACIO', 'subjects': ['Seeking Information'], 'images': [{'original': 'https://www.fbi.gov/wanted/seeking-info/keith-travis-nastacio/@@images/image', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/keith-travis-nastacio/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/keith-travis-nastacio/@@images/image/large', 'caption': None}, {'original': 'https://www.fbi.gov/wanted/seeking-info/keith-travis-nastacio/car.png', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/keith-travis-nastacio/car.png/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/keith-travis-nastacio/car.png/@@images/image/large', 'caption': 'Photograph of the light-colored Dodge Avenger SXT before the incident'}], 'additional_information': None, 'modified': '2020-12-16T17:54:01+00:00', 'reward_min': 0, 'build': None, 'race_raw': None, 'height_min': None, 'age_range': None, 'suspects': None, 'race': None, 'caution': None, 'sex': None, 'uid': 'be56b23cd0714908b80a398051725c04', 'path': '/wanted/seeking-info/keith-travis-nastacio', 'hair': None, 'aliases': None, 'languages': None, 'hair_raw': None, 'status': 'na', 'warning_message': None, 'possible_states': None, 'occupations': None, 'files': [{'name': 'English', 'url': 'https://www.fbi.gov/wanted/seeking-info/keith-travis-nastacio/download.pdf'}, {'name': 'DINÃ‰ BIZAAD Kâ€™EHGO', 'url': 'https://www.fbi.gov/wanted/seeking-info/keith-travis-nastacio/travis-navajo-12-16-2020.pdf/@@download/file/Travis Navajo 12-16-2020.pdf'}], 'person_classification': 'Main', 'reward_text': 'The FBI is offering a reward of up to $5,000 for information leading to the arrest and conviction of the person(s) responsible for the death of Keith Travis Nastacio.', 'url': 'https://www.fbi.gov/wanted/seeking-info/keith-travis-nastacio', 'legat_names': None, '@id': 'https://api.fbi.gov/@wanted-person/be56b23cd0714908b80a398051725c04'}, {'ncic': None, 'eyes': None, 'remarks': None, 'height_max': None, 'weight': None, 'dates_of_birth_used': None, 'eyes_raw': None, 'weight_max': None, 'scars_and_marks': None, 'weight_min': None, 'details': '

On September 5, 2020, residents along the 200 block of Briggs Street in Emporia, Virginia, were awakened close to 2:50 a.m. by the sound of multiple gunshots. Responding officers from the Emporia Police Department located 14-year-old K-Ron Surratt, who had been shot and died on scene.
\r\n

\xa0
\r\n

The Emporia Police Department is aware of ongoing conflicts between rival gang sects in the city of Emporia, which has resulted in retaliatory gunfire on numerous occasions. Investigators do not believe K-Ron was involved in gang activity, but are cognizant that he may have been a victim of random gunfire between rival gang members. Investigators have learned a black male, approximately 25 years old or younger, and a black car may have been involved.
\r\n

\xa0
\r\n

This case is being investigated by the FBIâ€™s Richmond Area Violent Enterprise (RAVE) Task Force and the Emporia Police Department.
', 'description': 'Homicide Victim\r\nEmporia, Virginia\r\nSeptember 5, 2020', 'field_offices': ['richmond'], 'locations': None, 'publication': '2020-10-08T08:29:00', 'possible_countries': None, 'nationality': None, 'place_of_birth': None, 'coordinates': [], 'age_min': None, 'complexion': None, 'reward_max': 0, 'age_max': None, 'title': 'K-RON SURRATT', 'subjects': [], 'images': [{'original': 'https://www.fbi.gov/wanted/seeking-info/k-ron-surratt/@@images/image', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/k-ron-surratt/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/k-ron-surratt/@@images/image/large', 'caption': None}], 'additional_information': None, 'modified': '2020-12-16T17:19:33+00:00', 'reward_min': 0, 'build': None, 'race_raw': None, 'height_min': None, 'age_range': None, 'suspects': None, 'race': None, 'caution': None, 'sex': None, 'uid': 'f0432ca9bd9e431580d12b9457ac7ec9', 'path': '/wanted/seeking-info/k-ron-surratt', 'hair': None, 'aliases': None, 'languages': None, 'hair_raw': None, 'status': 'na', 'warning_message': None, 'possible_states': None, 'occupations': None, 'files': [{'name': 'English', 'url': 'https://www.fbi.gov/wanted/seeking-info/k-ron-surratt/download.pdf'}], 'person_classification': 'Main', 'reward_text': 'The FBI is offering a reward of up to $10,000 for information that leads to the arrest and conviction of the person(s) responsible for K-Ron Surrattâ€™s death.', 'url': 'https://www.fbi.gov/wanted/seeking-info/k-ron-surratt', 'legat_names': None, '@id': 'https://api.fbi.gov/@wanted-person/f0432ca9bd9e431580d12b9457ac7ec9'}, {'ncic': None, 'eyes': 'brown', 'remarks': '

Clothing included the following: Tattered blue jeans; a flannel shirt; and either tennis shoes or work boots.
', 'height_max': 72, 'weight': 'Approximately 170 pounds', 'dates_of_birth_used': None, 'eyes_raw': 'Brown', 'weight_max': 170, 'scars_and_marks': 'The victim had a major scar on his knee and a full beard when last seen.', 'weight_min': 170, 'details': "

Jefferson County Sheriffâ€™s Office in Colorado is seeking assistance from the public to locate Mitchell Todd Hein. Hein visited family in Jefferson County, Colorado, in December of 1982 and abruptly left in January or February of 1983 without saying goodbye to anyone. He was carrying his clothes and belongings in a black trash bag. According to a friend, Hein showed up in Clinton, Oklahoma, and then in early March 1983, Hein hitched a ride with the friend's father to California. They stopped for the night in Indio, California. Hein left the hotel room and has not been seen or heard from since. It was reported that Hein had thrown away his driver's license and social security card and may have had no form of identification on him.
", 'description': 'Indio, California\r\nFebruary 1, 1983', 'field_offices': None, 'locations': None, 'publication': '2020-12-10T13:40:00', 'possible_countries': None, 'nationality': None, 'place_of_birth': None, 'coordinates': [], 'age_min': 22, 'complexion': None, 'reward_max': 0, 'age_max': 22, 'title': 'MITCHELL TODD HEIN - INDIO, CALIFORNIA', 'subjects': [], 'images': [{'original': 'https://www.fbi.gov/wanted/vicap/missing-persons/mitchell-todd-hein/@@images/image', 'thumb': 'https://www.fbi.gov/wanted/vicap/missing-persons/mitchell-todd-hein/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/vicap/missing-persons/mitchell-todd-hein/@@images/image/large', 'caption': None}], 'additional_information': None, 'modified': '2020-12-10T20:19:07+00:00', 'reward_min': 0, 'build': None, 'race_raw': 'White', 'height_min': 70, 'age_range': 'Approximately 22 years old', 'suspects': None, 'race': 'white', 'caution': None, 'sex': 'Male', 'uid': 'b241a3d5007b4abcba4a085ea95831a1', 'path': '/wanted/vicap/missing-persons/mitchell-todd-hein', 'hair': 'brown', 'aliases': None, 'languages': None, 'hair_raw': 'Brown/auburn and naturally curly', 'status': 'na', 'warning_message': None, 'possible_states': None, 'occupations': None, 'files': [{'name': 'English', 'url': 'https://www.fbi.gov/wanted/vicap/missing-persons/mitchell-todd-hein/vicap-alert-mitchell-hein-12-1-2020.pdf'}], 'person_classification': 'Main', 'reward_text': None, 'url': 'https://www.fbi.gov/wanted/vicap/missing-persons/mitchell-todd-hein', 'legat_names': None, '@id': 'https://api.fbi.gov/@wanted-person/b241a3d5007b4abcba4a085ea95831a1'}, {'ncic': None, 'eyes': None, 'remarks': None, 'height_max': None, 'weight': None, 'dates_of_birth_used': None, 'eyes_raw': None, 'weight_max': None, 'scars_and_marks': None, 'weight_min': None, 'details': "

On\xa0December 1, 2017, at approximately 7:00 pm, deputies with the Park County Sheriff's Office were dispatched to a house fire located at 3763 County Road 43 in Bailey, Colorado. It was reported in\xa0a 9-1-1 call that people were inside the residence causing damage. At least one male was on the property. After the fire was extinguished at the residence, Maggie Long's remains were discovered by fire rescue personnel. The El Paso County Coroner's Office later ruled her death a homicide. Long was 17 years old at the time of her death. Investigative efforts at the scene revealed a physical altercation took place between\xa0Long and her assailants before the fire started. The suspects stole a Beretta handgun, an AK-47-style rifle, 2,000 rounds of ammunition, a green safe, and jade figurines.
\r\n

\xa0
", 'description': 'Homicide Victim\r\nBailey, Colorado\r\nDecember 1, 2017', 'field_offices': ['denver'], 'locations': None, 'publication': '2019-11-22T07:45:00', 'possible_countries': None, 'nationality': None, 'place_of_birth': None, 'coordinates': [], 'age_min': None, 'complexion': None, 'reward_max': 0, 'age_max': None, 'title': 'MAGGIE LONG', 'subjects': ['Seeking Information'], 'images': [{'original': 'https://www.fbi.gov/wanted/seeking-info/maggie-long/@@images/image', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/maggie-long/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/maggie-long/@@images/image/large', 'caption': 'Maggie Long - Victim'}, {'original': 'https://www.fbi.gov/wanted/seeking-info/maggie-long/sketch-1-maggie-long.png', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/maggie-long/sketch-1-maggie-long.png/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/maggie-long/sketch-1-maggie-long.png/@@images/image/large', 'caption': 'Composite sketch of suspect 1'}, {'original': 'https://www.fbi.gov/wanted/seeking-info/maggie-long/sketch-2-maggie-long.png', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/maggie-long/sketch-2-maggie-long.png/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/maggie-long/sketch-2-maggie-long.png/@@images/image/large', 'caption': 'Composite sketch of suspect 2'}, {'original': 'https://www.fbi.gov/wanted/seeking-info/maggie-long/sketch-3-maggie-long.png', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/maggie-long/sketch-3-maggie-long.png/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/maggie-long/sketch-3-maggie-long.png/@@images/image/large', 'caption': 'Composite sketch of suspect 3'}, {'original': 'https://www.fbi.gov/wanted/seeking-info/maggie-long/maggie-long-pic-2.png', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/maggie-long/maggie-long-pic-2.png/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/maggie-long/maggie-long-pic-2.png/@@images/image/large', 'caption': 'Maggie Long - Victim'}, {'original': 'https://www.fbi.gov/wanted/seeking-info/maggie-long/maggie-long-pic-3.png', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/maggie-long/maggie-long-pic-3.png/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/maggie-long/maggie-long-pic-3.png/@@images/image/large', 'caption': 'Maggie Long - Victim'}, {'original': 'https://www.fbi.gov/wanted/seeking-info/maggie-long/maggie-long-pic-5.png', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/maggie-long/maggie-long-pic-5.png/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/maggie-long/maggie-long-pic-5.png/@@images/image/large', 'caption': 'Maggie Long - Victim'}], 'additional_information': None, 'modified': '2020-12-10T13:33:56+00:00', 'reward_min': 0, 'build': None, 'race_raw': None, 'height_min': None, 'age_range': None, 'suspects': None, 'race': None, 'caution': None, 'sex': None, 'uid': 'a7fe130271704e1686f5c6e0a2441a36', 'path': '/wanted/seeking-info/maggie-long', 'hair': None, 'aliases': None, 'languages': None, 'hair_raw': None, 'status': 'na', 'warning_message': None, 'possible_states': None, 'occupations': None, 'files': [{'name': 'English', 'url': 'https://www.fbi.gov/wanted/seeking-info/maggie-long/download.pdf'}], 'person_classification': 'Victim', 'reward_text': 'The FBI is offering a reward of up to $20,000 for information leading to the arrest and conviction of the individuals responsible for the death of Maggie Long. Additional reward money may be available.', 'url': 'https://www.fbi.gov/wanted/seeking-info/maggie-long', 'legat_names': None, '@id': 'https://api.fbi.gov/@wanted-person/a7fe130271704e1686f5c6e0a2441a36'}, {'ncic': None, 'eyes': 'brown', 'remarks': None, 'height_max': 69, 'weight': '280 pounds', 'dates_of_birth_used': ['July 4, 1967'], 'eyes_raw': 'Brown', 'weight_max': 280, 'scars_and_marks': None, 'weight_min': 280, 'details': "

The Federal Bureau of Investigation's Albuquerque Field Office is asking for the public's assistance in identifying the person(s) responsible for the homicide of Alvin Yazzie, Jr.
\r\n

\xa0
\r\n

On July 15, 2017, Yazzie's body was discovered approximately three miles north of the Chapter House in Sanostee, New Mexico. An autopsy indicated Yazzie had suffered multiple blunt and sharp force injuries to his head.
\r\n

\xa0
\r\n

Yazzie was last seen in the company of an unidentified Native American man with whom he had a fight in a nearby residence. The man followed Yazzie outside and down a dirt road.
", 'description': 'Homicide Victim\r\nSanostee, New Mexico\r\nJuly 15, 2017', 'field_offices': ['albuquerque'], 'locations': None, 'publication': '2018-12-19T10:04:00', 'possible_countries': None, 'nationality': None, 'place_of_birth': None, 'coordinates': [], 'age_min': None, 'complexion': None, 'reward_max': 0, 'age_max': None, 'title': 'ALVIN YAZZIE, JR.', 'subjects': ['Seeking Information'], 'images': [{'original': 'https://www.fbi.gov/wanted/seeking-info/alvin-yazzie-jr/@@images/image', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/alvin-yazzie-jr/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/alvin-yazzie-jr/@@images/image/large', 'caption': None}], 'additional_information': None, 'modified': '2020-12-08T19:06:23+00:00', 'reward_min': 0, 'build': None, 'race_raw': 'Native American', 'height_min': 69, 'age_range': None, 'suspects': None, 'race': 'native', 'caution': None, 'sex': 'Male', 'uid': '9ffda1b300c4486fb6bdf25d4d57de0f', 'path': '/wanted/seeking-info/alvin-yazzie-jr', 'hair': 'black', 'aliases': None, 'languages': None, 'hair_raw': 'Black', 'status': 'na', 'warning_message': None, 'possible_states': None, 'occupations': None, 'files': [{'name': 'English', 'url': 'https://www.fbi.gov/wanted/seeking-info/alvin-yazzie-jr/download.pdf'}, {'name': 'DINÃ‰ BIZAAD Kâ€™EHGO', 'url': 'https://www.fbi.gov/wanted/seeking-info/alvin-yazzie-jr/yazzie-navajo-12-8-2020.pdf/@@download/file/Yazzie Navajo 12-8-2020.pdf'}], 'person_classification': 'Main', 'reward_text': 'The FBI is offering a reward of up to $1,000 for information leading to the arrest and conviction of the person(s) responsible for the death of Alvin Yazzie, Jr.', 'url': 'https://www.fbi.gov/wanted/seeking-info/alvin-yazzie-jr', 'legat_names': None, '@id': 'https://api.fbi.gov/@wanted-person/9ffda1b300c4486fb6bdf25d4d57de0f'}, {'ncic': None, 'eyes': 'brown', 'remarks': '

Tallman was found wearing pants, socks with "Girls Rule" embroidered on them, and shoes.
', 'height_max': 68, 'weight': '158 pounds', 'dates_of_birth_used': ['October 21, 1974'], 'eyes_raw': 'Brown', 'weight_max': 158, 'scars_and_marks': None, 'weight_min': 158, 'details': "

The Federal Bureau of Investigation's Albuquerque Field Office is asking for the public's assistance in identifying the person(s) responsible for the homicide of Tyrone Tytis Tallman.
\r\n

\xa0
\r\n

On July 17, 2018, Tallman's body was discovered in a canal in Nenahnezad, New Mexico. A preliminary autopsy indicated Tallman had suffered multiple stab wounds, broken bones, and trauma to his skull.
\r\n

\xa0
\r\n

It is believed that Tallman was last seen alive on July 9, 2018.
", 'description': 'Homicide Victim\r\nNenahnezad, New Mexico\r\nJuly 17, 2018', 'field_offices': ['albuquerque'], 'locations': None, 'publication': '2018-08-17T08:36:00', 'possible_countries': None, 'nationality': None, 'place_of_birth': None, 'coordinates': [], 'age_min': None, 'complexion': None, 'reward_max': 0, 'age_max': None, 'title': 'TYRONE TYTIS TALLMAN', 'subjects': ['Seeking Information'], 'images': [{'original': 'https://www.fbi.gov/wanted/seeking-info/tyrone-tytis-tallman/@@images/image', 'thumb': 'https://www.fbi.gov/wanted/seeking-info/tyrone-tytis-tallman/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/seeking-info/tyrone-tytis-tallman/@@images/image/large', 'caption': 'Photograph taken in 2016'}], 'additional_information': None, 'modified': '2020-12-08T18:30:49+00:00', 'reward_min': 0, 'build': None, 'race_raw': 'Native American', 'height_min': 68, 'age_range': None, 'suspects': None, 'race': 'native', 'caution': None, 'sex': 'Male', 'uid': '21b3d93cf21645cfb7eca37862dfa57c', 'path': '/wanted/seeking-info/tyrone-tytis-tallman', 'hair': 'black', 'aliases': None, 'languages': None, 'hair_raw': 'Black', 'status': 'na', 'warning_message': None, 'possible_states': None, 'occupations': None, 'files': [{'name': 'English', 'url': 'https://www.fbi.gov/wanted/seeking-info/tyrone-tytis-tallman/download.pdf'}, {'name': 'DINÃ‰ BIZAAD Kâ€™EHGO', 'url': 'https://www.fbi.gov/wanted/seeking-info/tyrone-tytis-tallman/tallman-navajo-12-8-2020.pdf/@@download/file/Tallman Navajo 12-8-2020.pdf'}], 'person_classification': 'Victim', 'reward_text': 'The FBI is offering a reward of up to $1,000 for information leading to the arrest and conviction of the person(s) responsible for the death of Tyrone Tytis Tallman.', 'url': 'https://www.fbi.gov/wanted/seeking-info/tyrone-tytis-tallman', 'legat_names': None, '@id': 'https://api.fbi.gov/@wanted-person/21b3d93cf21645cfb7eca37862dfa57c'}, {'ncic': None, 'eyes': 'brown', 'remarks': '

Cayedito is of Navajo and Italian descent. At the time of her disappearance, she wore glasses. She was known to wear a silver chain with a small turquoise cross pendant.
', 'height_max': 55, 'weight': '55 pounds (at the time of her disappearance)', 'dates_of_birth_used': ['December 25, 1976'], 'eyes_raw': 'Brown', 'weight_max': 55, 'scars_and_marks': 'Cayedito has freckles, pierced ears, a scar on her knee, and a scar on her lip. She has moles on her back, right cheek, nose, left and right hands, and her right ankle.', 'weight_min': 55, 'details': '

Anthonette Cayedito was last seen inside her familyâ€™s residence in Gallup, New Mexico, on April 6, 1986.\xa0 She was last seen wearing a pink nightgown.
', 'description': 'April 6, 1986\r\nGallup, New Mexico', 'field_offices': ['albuquerque'], 'locations': None, 'publication': '2014-07-01T07:00:00', 'possible_countries': None, 'nationality': 'American', 'place_of_birth': 'New Mexico', 'coordinates': [], 'age_min': None, 'complexion': None, 'reward_max': 0, 'age_max': None, 'title': 'ANTHONETTE CHRISTINE CAYEDITO', 'subjects': ['Kidnappings and Missing Persons'], 'images': [{'original': 'https://www.fbi.gov/wanted/kidnap/anthonette-christine-cayedito/@@images/image', 'thumb': 'https://www.fbi.gov/wanted/kidnap/anthonette-christine-cayedito/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/kidnap/anthonette-christine-cayedito/@@images/image/large', 'caption': 'Photograph taken in 1986'}, {'original': 'https://www.fbi.gov/wanted/kidnap/anthonette-christine-cayedito/cayedito-2.jpg', 'thumb': 'https://www.fbi.gov/wanted/kidnap/anthonette-christine-cayedito/cayedito-2.jpg/@@images/image/thumb', 'large': 'https://www.fbi.gov/wanted/kidnap/anthonette-christine-cayedito/cayedito-2.jpg/@@images/image/large', 'caption': 'Photograph age-progressed to 36 years'}], 'additional_information': None, 'modified': '2020-12-08T18:09:25+00:00', 'reward_min': 0, 'build': None, 'race_raw': 'Biracial (Native American and White)', 'height_min': 55, 'age_range': None, 'suspects': None, 'race': 'native', 'caution': None, 'sex': 'Female', 'uid': '5342f633-76b9-4b46-bed9-32599702b86d', 'path': '/wanted/kidnap/anthonette-christine-cayedito', 'hair': 'brown', 'aliases': None, 'languages': None, 'hair_raw': 'Brown', 'status': 'na', 'warning_message': None, 'possible_states': None, 'occupations': None, 'files': [{'name': 'English', 'url': 'https://www.fbi.gov/wanted/kidnap/anthonette-christine-cayedito/download.pdf'}, {'name': 'DINÃ‰ BIZAAD Kâ€™EHGO', 'url': 'https://www.fbi.gov/wanted/kidnap/anthonette-christine-cayedito/cayedito-navajo-12-8-2020.pdf/@@download/file/Cayedito Navajo 12-8-2020.pdf'}], 'person_classification': 'Main', 'reward_text': None, 'url': 'https://www.fbi.gov/wanted/kidnap/anthonette-christine-cayedito', 'legat_names': None, '@id': 'https://api.fbi.gov/@wanted-person/5342f633-76b9-4b46-bed9-32599702b86d'}], 'page': 1}`;

      var sanitizedTheInvalidFBIJson = malformedDirtyJson.replace(new RegExp("None", "g"), "null");
      sanitizedTheInvalidFBIJson = sanitizedTheInvalidFBIJson.replace(new RegExp("\n", "g"), " ");
      sanitizedTheInvalidFBIJson = sanitizedTheInvalidFBIJson.replace(new RegExp("\r", "g"), " ");
      
      sanitizedTheInvalidFBIJson = sanitizedTheInvalidFBIJson.replace(new RegExp("(?<=[a-z])['](?=s)", "g"), "");
      sanitizedTheInvalidFBIJson = sanitizedTheInvalidFBIJson.replace(new RegExp("(?<=[0-9])['](?=[0-9])", "g"), "");
      //sanitizedTheInvalidFBIJson = sanitizedTheInvalidFBIJson.replace(new RegExp("d's", "g"), "ds");
      //sanitizedTheInvalidFBIJson = sanitizedTheInvalidFBIJson.replace(new RegExp("I's", "g"), "Is");



      var jsonObject = new JSON5.parse(
        sanitizedTheInvalidFBIJson
      );

      var eyeColour = [];
      var hairColour = [];
      var weightMax = [];
      var sex = [];

      var items = jsonObject["items"];
      var itemCount = items.length;
      var results = [];

      var greenEyes = 0;
      var blueEyes = 0;
      var brownEyes = 0;

      var sexMale = 0;
      var sexFemale = 0;

      var j = 0;
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

      return {
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