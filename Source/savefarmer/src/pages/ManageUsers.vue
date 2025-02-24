<template>
    <ion-page>
      <ion-content class="scrollable-content">
        <div class="manage-users-container">
          <ion-card class="manage-users-card">
            <ion-card-header>
              <ion-card-title>Manage Users</ion-card-title>
            </ion-card-header>
  
            <ion-card-content>
              <ion-list>
                <ion-item v-for="user in users" :key="user.id">
                  <ion-label>
                    <h2>{{ user.name }}</h2>
                    <p>{{ user.email }}</p>
                  </ion-label>
                  <ion-button color="danger" @click="removeUser(user.id)">Remove</ion-button>
                </ion-item>
              </ion-list>
            </ion-card-content>
  
            <ion-button expand="block" @click="goBack">Back to Admin</ion-button>
          </ion-card>
        </div>
      </ion-content>
    </ion-page>
  </template>
  
  <script lang="ts" setup>
  import { IonCard, IonCardHeader, IonCardTitle, IonCardContent, IonButton, IonPage, IonContent, IonList, IonItem, IonLabel } from '@ionic/vue';
  import { ref } from 'vue';
  import { useRouter } from 'vue-router';
  
  const router = useRouter();
  
  const users = ref([
    { id: 1, name: "John Doe", email: "john@example.com" },
    { id: 2, name: "Jane Smith", email: "jane@example.com" },
    { id: 3, name: "Alice Johnson", email: "alice@example.com" }
  ]);
  
  const removeUser = (id: number) => {
    users.value = users.value.filter(user => user.id !== id);
  };
  
  const goBack = () => {
    router.push('/AdminPage');
  };
  </script>
  
  <style scoped>
  .manage-users-container {
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    padding: 70px 20px 20px;
    background: linear-gradient(to bottom, #1e1e1e, #121212);
    box-sizing: border-box;
  }
  
  .manage-users-card {
    width: 100%;
    max-width: 400px;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.8);
    border-radius: 12px;
    overflow: hidden;
    background: #2a2a2a;
    color: #e0e0e0;
  }
  
  ion-content {
    --background: #121212;
  }
  </style>
  