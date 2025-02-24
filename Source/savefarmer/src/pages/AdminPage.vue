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
              <h3>Users Statistics</h3>
              <canvas id="usersChart"></canvas>
            </div>

            <div class="admin-stats">
              <h3>Transactions Statistics</h3>
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


onMounted(() => {
  const usersCtx = document.getElementById('usersChart') as HTMLCanvasElement;
  new Chart(usersCtx, {
    type: 'bar',
    data: {
      labels: ['Active Users', 'New Users', 'Inactive Users'],
      datasets: [
        {
          label: 'Users Data',
          data: [120, 45, 30],
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
      labels: ['Completed (200)', 'Pending (50)', 'Failed (15)'],
      datasets: [
        {
          label: 'Transactions Data',
          data: [200, 50, 15],
          backgroundColor: ['#4caf50', '#ff9800', '#f44336'],
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
