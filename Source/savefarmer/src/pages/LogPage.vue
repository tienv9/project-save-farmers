<template>
  <ion-page>
    <div class="login-container">
      <ion-card>
        <ion-card-header>
          <ion-card-title class="centered-title">Login</ion-card-title>
        </ion-card-header>

        <ion-card-content>
          <ion-item>
            <ion-label position="floating" class="field-title"
              >Username</ion-label
            >
            <ion-input
              v-model="email"
              type="text"
              placeholder="Email or Username"
            ></ion-input>
          </ion-item>
          <ion-item>
            <ion-label position="floating" class="field-title"
              >Password</ion-label
            >
            <ion-input
              v-model="password"
              type="text"
              placeholder="password"
            ></ion-input>
          </ion-item>

          <ion-button expand="block" class="login-button" @click="handleLogin">Login</ion-button>
          <div class="misc">
            <a href="/reset-password" class="link">Forgot your password?</a>
            <p>
              Don't have an account? <a href="/SignUp" class="link">Sign Up</a>
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
} from "@ionic/vue";
import { ref } from "vue";
import axios from "axios";

const email = ref("");
const password = ref("");

const handleLogin = async () => {
  try {
    const response = await axios.post('https://localhost:7170/api/login', {
      email: email.value,
      password: password.value
    });
    if (response.status === 200) {
      // Fixed string concatenation and missing parenthesis
      alert('Login successful! Your ID is: ' + response.data.id + "\n" + 
            'Your name is: ' + response.data.firstName + ' ' + response.data.lastName + "\n" +
            'Your email is: ' + response.data.email + "\n" + 
            'Your role is: ' + response.data.role);
      window.location.href = '/Profile';
    }
  } catch (error) {
    console.error('Login error:', error);
    alert('Login failed. Please check your credentials.');
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
