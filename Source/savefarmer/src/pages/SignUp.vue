<template>
    <ion-page>
      <div class="login-container">
        <ion-card>
          <ion-card-header>
            <ion-card-title class="centered-title">Create your account</ion-card-title>
          </ion-card-header>
  
          <ion-card-content>
            <ion-item>
              <ion-label position="floating" class="field-title"
                >First name</ion-label
              >
              <ion-input type="text" placeholder="Email or Username" v-model="firstname"></ion-input>
            </ion-item>
            <ion-item>
              <ion-label position="floating" class="field-title"
                >Last name</ion-label
              >
              <ion-input type="text" placeholder="Email or Username" v-model="lastname"></ion-input>
            </ion-item>
            <!-- <ion-item>
              <ion-label position="floating" class="field-title"
                >Username</ion-label
              >
              <ion-input type="text" placeholder="Email or Username" v-model="username"></ion-input>
            </ion-item> -->
            <ion-item>
              <ion-label position="floating" class="field-title"
                >Farmer or Buyer</ion-label>
              <!-- <ion-input type="text" placeholder="Email or Username" v-model="email" required></ion-input> -->
                <ion-select type="text" placeholder="Someone" v-model="role">
                  <ion-select-option value="farmer">Farmer</ion-select-option>
                  <ion-select-option value="buyer">Buyer</ion-select-option>
                </ion-select>
            </ion-item>
            <ion-item>
              <ion-label position="floating" class="field-title"
                >Email</ion-label
              >
              <ion-input type="text" placeholder="Email or Username" v-model="email"></ion-input>
            </ion-item>
            <ion-item>
              <ion-label position="floating" class="field-title"
                >Password</ion-label
              >
              <ion-input type="password" placeholder="Enter your password" v-model="password"></ion-input>
            </ion-item>
            
            <!-- href="/Login" -->
            <ion-button expand="block" class="login-button" @click="handleLogin">Create Account <ion-icon color="white" icon="arrow-forward-outline"></ion-icon></ion-button>
            <div class="misc">
              <p>
                Already have an account? <a href="/Login" class="link">Log in</a>
              </p>
            </div>
          </ion-card-content>
        </ion-card>
      </div>
    </ion-page>
  </template>
  
  <script lang="ts" setup>
  import {
    IonButton,
    IonCard,
    IonCardContent,
    IonCardHeader,
    IonCardTitle,
    IonPage,
    IonItem,
    IonLabel,
    IonInput,
    IonIcon,
  } from "@ionic/vue";  
  
  import {arrowForwardOutline} from 'ionicons/icons';
  import { addIcons } from "ionicons";

  addIcons({
    "arrow-forward-outline": arrowForwardOutline,
  });

  import { ref } from "vue";
  import axios from "axios";

  const firstname = ref("");
  const lastname = ref("");
  // const username = ref("");
  const role = ref("");
  const email = ref("");
  const password = ref("");

  const handleLogin = async () => {
    try {
      const response = await axios.post('https://localhost:7170/api/register', {
        firstname: firstname.value,
        lastname: lastname.value,
        // username: username.value,
        role: role.value,
        email: email.value,
        password: password.value
      });
      if (response.status === 200) {
        // Fixed string concatenation and missing parenthesis
        // 'Your username is: ' + response.data.username + "\n" +
        alert('Signup successful! Your ID is: ' + response.data.id + "\n" + 
              'Your name is: ' + response.data.firstName + ' ' + response.data.lastName + "\n" +
              'Your email is: ' + response.data.email + "\n" + 
              'Your role is: ' + response.data.role);
        window.location.href = '/SignUp';
      }
    } catch (error) {
      console.error('Signup error:', error);
      alert('Signup failed. Please check your inputs.');
    }
  };

  </script>
  
  <style scoped>
  .login-container {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100%;
    padding: 16px;
    box-sizing: border-box;
  }
  
  .centered-title {
    text-align: center;
    font-size: 1.5rem;
    font-weight: bold;
  }
  
  .login-button,
  .signup-button {
    margin-top: 16px;
  }
  
  .field-title {
    margin-bottom: 12px;
  }
  
  .misc {
    margin-top: 16px;
    text-align: center;
  }
  .link {
    text-decoration: none;
  }
  </style>
  