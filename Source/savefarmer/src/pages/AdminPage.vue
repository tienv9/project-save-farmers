<template>
  <ion-page>
    <ion-content class="scrollable-content">
      <div class="admin-container">
        <ion-card class="admin-card">
          <ion-card-header>
            <ion-card-title>Admin Dashboard</ion-card-title>
          </ion-card-header>

          <ion-card-content>
            <div class="admin-actions">
              <ion-button expand="block" @click="ManageUsers">Manage Users</ion-button>
              <ion-button expand="block" @click="viewTransactions">View Transactions</ion-button>
              <ion-button expand="block" @click="viewAppSettings">App Settings</ion-button>
            </div>

            <div class="admin-stats">
              <h3>Users</h3>
              <canvas id="usersChart"></canvas>
            </div>

            <div class="admin-stats">
              <h3>Posts</h3>
              <canvas id="transactionsChart"></canvas>
            </div>
          </ion-card-content>
        </ion-card>
      </div>
    </ion-content>
  </ion-page>
</template>

<script lang="ts" setup>
import { IonCard, IonCardHeader, IonCardTitle, IonCardContent, IonButton, IonPage, IonContent } from '@ionic/vue';
import { ref, onMounted } from 'vue';
import { Chart, registerables } from 'chart.js';
import ChartDataLabels from 'chartjs-plugin-datalabels';

Chart.register(...registerables, ChartDataLabels);

import { useRouter } from 'vue-router';

const router = useRouter();

function ManageUsers() {
  console.log('Navigating to Manage Users');
  router.push('/ManageUsers');
}

function viewTransactions() {
  console.log('Navigating to Transactions');
  router.push('/Transactions');
}

function viewAppSettings() {
  console.log('Navigating to App Settings');
  router.push('/AppSettings');
}


onMounted(async () => {

  // getting the access token from the session storage
  const acTo = checkUser();
  // console.log(acTo);
  axios.defaults.headers.common['Authorization'] = `Bearer ${acTo}`;

  // Fetching the user amount
  const userResponse = await axios.get('https://localhost:7170/api/GetAllUsers'); 
  const userAmount = userResponse.data.length;
  console.log(userAmount);

  // Fetching the post amount
  const postResponse = await axios.get('https://localhost:7170/api/posts/analytic');
  const postAmount = postResponse.data.length;
  console.log(postAmount);



  const usersCtx = document.getElementById('usersChart') as HTMLCanvasElement;
  new Chart(usersCtx, {
    type: 'bar',
    data: {
      labels: ['Active Users'],
      datasets: [
        {
          label: 'Users Data',
          data: [userAmount],
          backgroundColor: ['#4caf50', '#ff9800', '#f44336'],
        },
      ],
    },
    options: {
      responsive: true,
      plugins: {
        legend: {
          display: false,
        },
      },
      scales: {
        x: {
          ticks: { color: '#e0e0e0' },
        },
        y: {
          beginAtZero: true,
          ticks: { color: '#e0e0e0' },
        },
      },
    },
  });

  const transactionsCtx = document.getElementById('transactionsChart') as HTMLCanvasElement;
  new Chart(transactionsCtx, {
    type: 'pie',
    data: {
      labels: ['All','Active', 'Inactive', 'Expired'],
      datasets: [
        {
          label: 'Post Data',
          data: [postAmount, 0, 0, 0],
          backgroundColor: ['#4caf50', '#2196f3', '#f44336', '#ff9800'],
        },
      ],
    },
    options: {
      responsive: true,
      plugins: {
        legend: {
          display: true,
          labels: {
            font: {
              size: 14,
              weight: 'bold',
            },
          },
        },
        datalabels: {
          color: '#fff',
          font: {
            weight: 'bold',
          },
          formatter: () => '',
        },
      },
    },
  });
});

import axios from 'axios';


async function amountOfUsers() {
  try {

    // getting the access token from the session storage
    const acTo = await checkUser();
    console.log(acTo);
    axios.defaults.headers.common['Authorization'] = `Bearer ${acTo}`;


    const response = await axios.get('https://localhost:7170/api/GetAllUsers'); 
    return response.data.length;

  } catch (error: any) {

    // Handle errors appropriately
    console.error('Error fetching data:', error.message);
    throw error; // Re-throw to allow handling by the caller if necessary
  }
}





const checkUser = () => {
  const aT = sessionStorage.getItem('AccessToken');
  if (aT != null || aT != undefined) {
    return sessionStorage.getItem('AccessToken');
  } else {
    alert("No AccessToken found in session storage");
    const rT = localStorage.getItem('AccessToken');
    if (rT != null || rT != undefined) {
    return localStorage.getItem('AccessToken');
  } else {
    alert("No AccessToken found in local storage");
    
  }
  }
};



</script>

<style scoped>
.admin-container {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  padding: 70px 20px 20px;
  background: linear-gradient(to bottom, #1e1e1e, #121212);
  box-sizing: border-box;
}

.scrollable-content {
  height: 100%;
  overflow-y: auto;
}

.admin-card {
  width: 100%;
  max-width: 400px;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.8);
  border-radius: 12px;
  overflow: hidden;
  background: #2a2a2a;
  color: #e0e0e0;
}

.admin-actions {
  display: flex;
  flex-direction: column;
  gap: 15px;
}

.admin-stats {
  margin-top: 20px;
  text-align: center;
}

.admin-stats h3 {
  color: #4caf50;
  margin-bottom: 10px;
}

ion-content {
  --background: #121212;
}
</style>
