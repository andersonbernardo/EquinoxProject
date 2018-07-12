const functions = require('firebase-functions');
const admin = require('firebase-admin');
admin.initializeApp();

 exports.sendNotification = functions.database.ref('/notification/{userId}').onCreate((change, context) => {
   const userId = context.params.userId;   
   
   console.log('We have a new follower UID:', userId, 'for user:', userId);

   // Get the list of device notification tokens.
   const getDeviceTokensPromise = admin.database()
       .ref(`/users/${userId}/notificationTokens`).once('value'); 
       
    const getPayload = admin.database().ref(`/notification/${userId}/payload`).once('value'); 

   // The snapshot to the user's tokens.
   let tokensSnapshot;

   // The array containing all the user's tokens.
   let tokens;

   return Promise.all([getDeviceTokensPromise,getPayload]).then(results => {
     tokensSnapshot = results[0];
     const _payload = results[1];    

     // Check if there are any device tokens.
     if (!tokensSnapshot.hasChildren()) {
       return console.log('There are no notification tokens to send to.');
     }
     
     console.log('There are', tokensSnapshot.numChildren(), 'tokens to send notifications to.');     

     // Notification details.
     const payload = {
       notification: _payload.val()
     };
     // Listing all tokens as an array.
     tokens = Object.keys(tokensSnapshot.val());
     // Send notifications to all tokens.
     return admin.messaging().sendToDevice(tokens, payload);
   }).then((response) => {
     // For each message check if there was an error.
     const tokensToRemove = [];
     response.results.forEach((result, index) => {
       const error = result.error;
       if (error) {
         console.error('Failure sending notification to', tokens[index], error);
         // Cleanup the tokens who are not registered anymore.
         if (error.code === 'messaging/invalid-registration-token' ||
             error.code === 'messaging/registration-token-not-registered') {
           tokensToRemove.push(tokensSnapshot.ref.child(tokens[index]).remove());
         }
       }
       else
       {
            admin.database().ref(`/notification/${userId}`).remove(); 
       }
     });
     return Promise.all(tokensToRemove);
   });
 });    