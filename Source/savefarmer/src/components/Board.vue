<template>
  <ion-page>
    <ion-content>
    <div class="board">
      <ion-card v-for="(post, index) in posts" :key="index" class="board-card">
        <ion-card-header>
          <ion-card-title>
            <img :src="getCropIcon(post.crop_type)" alt="Crop Icon" class="crop-icon" />
            {{ post.title }}
          </ion-card-title>
        </ion-card-header>
        <ion-card-content>
          <!-- first line -->
          <div class="info-header">
            <span><strong>Price:</strong></span>
            <span><strong>Produce:</strong></span>
            <span><strong>Location:</strong></span>
            <span><strong>Contact:</strong></span>
          </div>
          <!-- second line -->
          <div class="info-details">
            <span>${{ post.price }}</span>
            <span>{{ post.crop_type }}</span>
            <span>{{ post.vendor_name }}</span>
            <span>{{ formatContact(post.contact) }}</span>
          </div>
          <!-- third line -->
          <div class="info-2details">
            <span class="date-column">
              <div>Date Listed:</div>
              <div>{{ post.date }}</div>
            </span>
            <span>{{ post.amount }}</span>
            <span>{{ post.location }}</span>
            <span>{{ post.email }}</span>
          </div>
          <p class="expiry-date"><strong>Expires:</strong> {{ post.expiry_date }}</p>
        </ion-card-content>
      </ion-card>
    </div>
  </ion-content>
  </ion-page>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { IonCardTitle, IonCardHeader, IonCard, IonPage, IonCardContent, IonContent } from '@ionic/vue';
import cornIcon from '@/images/icons/corn.png';
import tomatoIcon from '@/images/icons/tomato.png';
import wheatIcon from '@/images/icons/wheat.png';
import carrotIcon from '@/images/icons/carrot.png';
import cropIcon from '@/images/icons/crop.png';
import potatoIcon from '@/images/icons/potato.png';

interface Post {
  title: string;
  price: number;
  crop_type: string;
  amount: number;
  location: string;
  contact: string;
  extra_info: string;
  date: string;
  expiry_date: string;
  email: string;
  vendor_name: string;
}

const posts = ref<Post[]>([
  {
    title: 'Fresh Potatoes for Sale. Organic and Locally Grown.',
    price: 100,
    crop_type: 'Potato',
    amount: 100,
    location: 'Spokane, WA, USA',
    contact: '8496554654',
    vendor_name: 'Red Barn Farms',
    email: 'nowhere@somewhere.com',
    extra_info: 'Extra Info',
    date: '2021-09-01',
    expiry_date: '2021-09-30',
  },  
  {
    title: 'Carrots for Sale. Fresh and Organic.',
    price: 200,
    crop_type: 'Carrot',
    amount: 200,
    location: 'Seattle, WA, USA',
    contact: '2156548231',
    vendor_name: 'Blue Barn Farms',
    email: 'somewhere@nowhere.com',
    extra_info: 'Extra Info 2',
    date: '2021-09-02',
    expiry_date: '2021-09-29',
  },
  {
    title: 'Rotten Tomatoes for Sale. Cheap and Expired.',
    price: 10,
    crop_type: 'Tomato',
    amount: 200,
    location: 'Seattle, WA, USA',
    contact: '2424548231',
    vendor_name: 'Brown Barn Farms',
    email: 'somewhere2@nowhere.com',
    extra_info: 'Extra Info 2',
    date: '2021-09-02',
    expiry_date: '2021-09-29',
  },
  {
    title: 'Unripe Corn for Sale. Fresh and Raw.',
    price: 900,
    crop_type: 'Corn',
    amount: 1,
    location: 'Seattle, WA, USA',
    contact: '9999999999',
    vendor_name: 'Yellow Barn Farms',
    email: 'nowhere2@nowhere.com',
    extra_info: 'Extra Info 2',
    date: '2021-09-02',
    expiry_date: '2021-09-29',
  },
]);

function formatContact(contact: string): string {
  return contact.replace(/(\d{3})(\d{3})(\d{4})/, '$1-$2-$3');
}

//icon from https://www.flaticon.com/ and need to put in Attribution
//would be better if they all from the same pack but should work for now
function getCropIcon(cropType: string): string {
  switch (cropType.toLowerCase()) {
    case 'corn':
      return cornIcon;
    case 'tomato':
      return tomatoIcon;
    case 'wheat':
      return wheatIcon;
    case 'carrot':
      return carrotIcon;
    case 'potato':
      return potatoIcon;
    default:
      return cropIcon;
  }
}


</script>


<style scoped>


.board {
  display: flex;
  flex-direction: column;
  gap: 0px; /* need remove top and bottom padding and use gap for distance between card*/
  padding: 15px;
}

.board-card {
  width: 100%;
  font-family:'Courier New', Courier, monospace;
}

.info-header {
  display: flex;
  font-weight: bold;
  font-size: 1.5rem;
}
.info-details {
  display: flex;
  font-size: 1.3rem;
}

.info-2details {
  display: flex;
  font-size: 1rem;
}

.info-header span,
.info-2details span,
.info-details span {
  flex: 1;
  flex-direction: column;
  text-align: left; 
}

.date-column {
  display: flex;
  flex-direction: column; /* Stack "Date Listed" and date vertically */
  text-align: left; /* Align text to the left */
  line-height: 1; /* Reduce line height */
}

.date-column div:first-child {
  font-weight: bold; 
  font-size: 0.9rem;
}

.expiry-date {
  margin-top: auto; /* Push the expiration date to the bottom */
  text-align: right; /* Align the expiration date to the right */
  font-size: 0.8rem;
  font-weight: bold;
}

.crop-icon {
  width: 1.5rem; /* Adjust width to match text size */
  height: auto; /* Maintain aspect ratio */
  vertical-align: middle; /* Align with text vertically */
  margin-right: 8px; /* Space between image and text */
}

/* Add padding on top of ion-content to avoid content overlapping the header */
ion-content {
  --padding-top: 50px; /* Adjust based on the header height */
}


</style>
