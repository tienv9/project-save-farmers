<template>
  <ion-page>
    <div class="login-container">
      <ion-card>
        <ion-card-header>
          <ion-card-title class="centered-title">Login</ion-card-title>
        </ion-card-header>

        <ion-card-content>
          <ion-item>
            <ion-label position="floating" class="field-title">Email</ion-label>
            <ion-input v-model="email" type="text" placeholder="Enter your Email"></ion-input>
          </ion-item>
          <ion-item>
            <ion-label position="floating" class="field-title">Password</ion-label>
            <ion-input v-model="password" type="password" placeholder="Enter your Password"></ion-input>
          </ion-item>
          <ion-item lines="none">
            <ion-checkbox slot="start" v-model="rememberMe"></ion-checkbox>
            <ion-label>Remember me?</ion-label>
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

      <ion-card class="demo-card">
        <ion-card-header>
          <ion-card-title class="centered-title">Try the App</ion-card-title>
        </ion-card-header>
        <ion-card-content class="demo-content">
          <p class="demo-description">Explore Save Farmers instantly with a pre-made demo account — no sign-up required.</p>
          <ion-button expand="block" class="demo-button" @click="handleDemoLogin" :disabled="demoLoading">
            <ion-spinner v-if="demoLoading" name="crescent" class="demo-spinner"></ion-spinner>
            <span v-else>Use Demo Account</span>
          </ion-button>
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
  IonCheckbox,
  IonSpinner,
} from "@ionic/vue";
import { ref } from "vue";
import axios from "axios";
import { API_BASE_URL } from "@/config/api";

const email = ref("");
const password = ref("");
const rememberMe = ref(false);
const demoLoading = ref(false);

const storeSession = (data: any) => {
  sessionStorage.setItem('AccessToken', data.accessToken);
  sessionStorage.setItem('Id', data.id);
  sessionStorage.setItem('FirstName', data.firstName);
  sessionStorage.setItem('LastName', data.lastName);
  sessionStorage.setItem('Email', data.email);
  sessionStorage.setItem('Role', data.role);
  axios.defaults.headers.common['Authorization'] = `Bearer ${data.accessToken}`;
};

const handleLogin = async () => {
  try {
    const response = await axios.post(`${API_BASE_URL}/api/login`, {
      email: email.value,
      password: password.value
    });
    if (response.status === 200) {
      if (rememberMe.value) {
        localStorage.setItem('RefreshToken', response.data.refreshToken);
      }
      storeSession(response.data);
      window.location.href = '/Home';
    }
  } catch (error: any) {
    if (error.response) {
      alert(error.response.data.title);
    } else if (error.request) {
      alert('No response from server. Please try again.');
    } else {
      alert('An unexpected error occurred.');
    }
  }
};

const handleDemoLogin = async () => {
  demoLoading.value = true;
  try {
    const response = await axios.post(`${API_BASE_URL}/api/login`, {
      email: 'Demo@gmail.com',
      password: 'demouser123',
    });
    if (response.status === 200) {
      storeSession(response.data);
      window.location.href = '/Home';
    }
  } catch (error: any) {
    if (error.response) {
      alert(error.response.data.title ?? 'Demo login failed. Please try again.');
    } else if (error.request) {
      alert('No response from server. Please try again.');
    } else {
      alert('An unexpected error occurred.');
    }
  } finally {
    demoLoading.value = false;
  }
};
</script>

<style scoped>
.login-container {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  align-items: center;
  gap: 16px;
  min-height: 100%;
  padding: 16px;
  box-sizing: border-box;
}

.demo-card {
  max-width: 320px;
  width: 100%;
}

.demo-content {
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 16px;
  text-align: center;
}

.demo-description {
  color: var(--ion-color-medium);
  font-size: 0.95rem;
  line-height: 1.5;
  margin: 0;
}

.demo-button {
  width: 100%;
  margin-top: 8px;
}

.demo-spinner {
  width: 20px;
  height: 20px;
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
