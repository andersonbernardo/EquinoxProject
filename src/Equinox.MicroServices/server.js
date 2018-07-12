const firebase = require('firebase');
require("firebase/firestore");
//const WebSocket = require('ws');




var config = {
  apiKey: "AIzaSyCJLPftgyMJNJWGKfJvZClZxQvoV4skDmA",
  authDomain: "magittrade.firebaseapp.com",
  databaseURL: "https://magittrade.firebaseio.com",
  projectId: "magittrade",
  storageBucket: "magittrade.appspot.com",
  messagingSenderId: "321694365619"
};
firebase.initializeApp(config);

// var payload = {
//   payload: {
//     title: 'o loco meu',
//     body: 'agora vai'
//   }
// };


let db = firebase.firestore();
const settings = {/* your settings... */ timestampsInSnapshots: true};
db.settings(settings);

let alertas = db.collection("alertas").doc("BTC").collection("notifications");

//  alertas.doc("usuario1").set({
//      valor:6700,     
//  });

//  alertas.doc("usuario2").set({
//    valor:6702   
//  });

 var observer = alertas.onSnapshot(docSnapshot => {
  docSnapshot.docs.map(doc => console.log(doc.data()));
 }, err => {
   console.log(`Encountered error: ${err}`);
 });

// var getDoc = alertas.get()
//     .then(doc => {
//       if (!doc.exists) {
//         console.log('No such document!');
//       } else {
//         console.log('Document data:', doc.data());
//       }
//     })
//     .catch(err => {
//       console.log('Error getting document', err);
//     });

// const alertasDocument = firebase.database().ref('/alerta/btc');

// const alertas = null;

// alertasDocument.on('value', function(snapshot) {
//     alertas = snapshot.val();
// });

// console.log(alertas)


// const w = new WebSocket('wss://api.bitfinex.com/ws/2')

// w.onmessage = function(msg){ 
//     let data = JSON.parse(msg.data);            
//     let status = data[1];    
//     let CHANNEL_ID = data[0];
    
//     if(status != 'hb' && Array.isArray(status)) {

//         console.log(status[6]);
//     }    
// };

// let msg = JSON.stringify({ 
//     event: 'subscribe', 
//     channel: 'ticker', 
//     symbol: 'tBTCUSD' 
// })

// w.onopen = function(){
//     w.send(msg);
// }

// var db = admin.database();
// var ref = db.ref("server/saving-data/fireblog/posts");

// // Attach an asynchronous callback to read the data at our posts reference
// ref.on("value", function(snapshot) {
//   console.log(snapshot.val());
// }, function (errorObject) {
//   console.log("The read failed: " + errorObject.code);
// });

