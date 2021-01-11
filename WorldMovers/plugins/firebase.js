import firebase from "firebase/app";
import "firebase/database";

const firebaseConfig = {
  apiKey: "AIzaSyDB1xhh-BhrEsau8vKWLw6NU7JiiBaw3Hk",
  authDomain: "world-movers.firebaseapp.com",
  databaseURL: "https://world-movers-default-rtdb.firebaseio.com",
  projectId: "world-movers",
  storageBucket: "world-movers.appspot.com",
  messagingSenderId: "1013579290366",
  appId: "1:1013579290366:web:e954e1f71e5e41a552f7af",
  measurementId: "G-6M2ENGS6W3",
};

const app = firebase.apps.length
  ? firebase.app()
  : firebase.initializeApp(firebaseConfig);

export const db = app.database();
