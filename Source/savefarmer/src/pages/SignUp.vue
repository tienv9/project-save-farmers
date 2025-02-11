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
              <ion-input type="text" placeholder="Enter your First name" v-model="firstName"></ion-input>
            </ion-item>
            <ion-item>
              <ion-label position="floating" class="field-title"
                >Last name</ion-label
              >
              <ion-input type="text" placeholder="Enter your Last name" v-model="lastName"></ion-input>
            </ion-item>
            <ion-item>
              <ion-label position="floating" class="field-title"
                >Account type</ion-label>
                <ion-select v-model="role">
                  <ion-select-option value="Buyer">Buyer</ion-select-option>
                  <ion-select-option value="Farmer">Farmer</ion-select-option>
                </ion-select>
            </ion-item>
            <ion-item>
              <ion-label position="floating" class="field-title"
                >Email</ion-label
              >
              <ion-input type="text" placeholder="Enter your Email" v-model="email"></ion-input>
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
    IonSelect,
    IonSelectOption
  } from "@ionic/vue";  
  
  import {arrowForwardOutline} from 'ionicons/icons';
  import { addIcons } from "ionicons";

  addIcons({
    "arrow-forward-outline": arrowForwardOutline,
  });

  import { ref } from "vue";
  import axios from "axios";

  const firstName = ref("");
  const lastName = ref("");
  const role = ref("Buyer")
  const email = ref("");
  const password = ref("");

  const handleLogin = async () => {
    try {
      const response = await axios.post('https://localhost:7170/api/register', {
        FirstName: firstName.value,
        LastName: lastName.value,
        Email: email.value,
        Password: password.value,
        Role: role.value
      });
      if (response.status === 200) {
        window.location.href = '/Login';
      }
    } catch (error : any) {
      if (error.response) {
        alert(error.response.data.title);
      } else if (error.request) {
        alert('No response from server. Please try again.');
      } else {
        alert('An unexpected error occurred.');
      }
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
  