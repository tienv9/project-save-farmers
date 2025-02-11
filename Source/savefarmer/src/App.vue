<template>
  <ion-app>
    <ion-split-pane content-id="main-content">
      <!-- Side Menu -->
      <ion-menu content-id="main-content" type="reveal">
        <ion-content>
          <ion-list id="inbox-list">
            <ion-list-header>Button list</ion-list-header>

            <ion-menu-toggle aria-hidden="true" :auto-hide="false" v-for="(p, i) in appPages" :key="i">
              <ion-item @click="selectedIndex = i" router-direction="root" :router-link="p.url" lines="none" :detail="false" class="hydrated" :class="{ selected: selectedIndex === i }">
                <ion-icon slot="start" :ios="p.iosIcon" :md="p.mdIcon"></ion-icon>
                <ion-label>{{ p.title }}</ion-label>
              </ion-item>
            </ion-menu-toggle>
          </ion-list>
        </ion-content>
      </ion-menu>

      <!-- Main Content -->
      <ion-content id="main-content">
        <ion-header :translucent="true">
          <ion-toolbar>
            <ion-buttons slot="start">
              <ion-menu-button></ion-menu-button>
            </ion-buttons>
            <ion-title>My Farmer</ion-title>
            <ion-buttons slot="primary">
            <ion-button fill="outline" @click="openModal"> 
              Create Post <ion-icon size="large" :icon="addOutline"></ion-icon>
            </ion-button>
            </ion-buttons>

            
            <ion-buttons shape="round" slot="end" @click="checkAuth">
              <ion-icon size="large" :icon="bagCheckOutline"></ion-icon>
            </ion-buttons>
            <ion-buttons shape="round" slot="end" @click="checkUser">
              <ion-icon size="large" :icon="personCircleOutline"></ion-icon>
            </ion-buttons>
            <ion-buttons shape="round" slot="end" @click="logOut">
              <ion-icon size="large" :icon="logOutOutline"></ion-icon>
            </ion-buttons>
          </ion-toolbar>
        </ion-header>

        <ion-router-outlet id="main-content"></ion-router-outlet>
      </ion-content>
    </ion-split-pane>
    <CreatePostModal :isOpen="isModalOpen" @update:isOpen="isModalOpen = $event" />

    <ion-toast
      :is-open="showToast"
      message="You need to be logged in to create a post."
      duration="2000"
      color="danger"
      position="top"
      @did-dismiss="showToast = false"
    />


  </ion-app>
</template>

<script setup lang="ts">
import {
  IonApp,
  IonContent,
  IonIcon,
  IonItem,
  IonLabel,
  IonList,
  IonListHeader,
  IonMenu,
  IonMenuToggle,
  IonRouterOutlet,
  IonSplitPane,
  IonTitle,
  IonToolbar,
  IonHeader,
  IonButtons,
  IonMenuButton,
  IonButton,
  IonToast,
} from '@ionic/vue';
import { ref } from 'vue';
import {
  logInOutline,
  logInSharp,
  personCircleOutline,
  personCircleSharp,
  heartOutline,
  heartSharp,
  archiveOutline,
  archiveSharp,
  trashOutline,
  trashSharp,
  homeOutline,
  homeSharp,
  bagCheckOutline,
  logOutOutline,
  addOutline,
} from 'ionicons/icons';

import CreatePostModal from '@/components/CreatePost.vue';

const checkAuth = () => {
  const token = sessionStorage.getItem('AccessToken');
  if (token != null || token != undefined) {
    alert('You are login');
  } else {
    alert('You are not login');
  }
};

const checkUser = () => {
  const id = sessionStorage.getItem('Id');
  if (id != null || id != undefined) {
    alert("Your user ID is: " + sessionStorage.getItem('Id'));
  } else {
    alert("No ID found");
  }
};

const logOut = () => {
  sessionStorage.clear();
  localStorage.clear();
  window.location.reload();
  window.location.href = '/Home';
};


  const isModalOpen = ref(false);
  const showToast = ref(false);

  const openModal = () => {
  const token = sessionStorage.getItem('AccessToken');
  if (token) {
    isModalOpen.value = true; 
  } else {
    showToast.value = true;
  }
};


const selectedIndex = ref(0);
// Temporary and can be moved later
const appPages = [
{
    title: 'Home',
    url: '/Home',
    iosIcon: homeOutline,
    mdIcon: homeSharp,
  },
  {
    title: 'Login',
    url: '/Login',
    iosIcon: logInOutline,
    mdIcon: logInSharp,
  },
  {
    title: 'Profile',
    url: '/Profile',
    iosIcon: personCircleOutline,
    mdIcon: personCircleSharp,
  },
  {
    title: 'database',
    url: '/database',
    iosIcon: personCircleOutline,
    mdIcon: personCircleSharp,
  },
  {
    title: 'Sign Up',
    url: '/SignUp',
    iosIcon: heartOutline,
    mdIcon: heartSharp,
  },
  {
    title: 'About',
    url: '/About',
    iosIcon: archiveOutline,
    mdIcon: archiveSharp,
  },
  // {
  //   title: 'Trash',
  //   url: '/Trash',
  //   iosIcon: trashOutline,
  //   mdIcon: trashSharp,
  // },
  {
    title: 'Admin',
    url: '/AdminPage',
    iosIcon: trashOutline,
    mdIcon: trashSharp,
  }
  
];

const path = window.location.pathname.split('/')[1];
if (path !== undefined) {
  selectedIndex.value = appPages.findIndex((page) => page.title.toLowerCase() === path.toLowerCase());
}
</script>

<style scoped>

.PostButton {
  background: antiquewhite;
  color: red;
}

ion-menu ion-content {
  --background: var(--ion-item-background, var(--ion-background-color, #fff));
}

ion-split-pane {
  --max-width: 100vw;
  --max-height: 100vh;
}

ion-header {
  z-index: 10;
  position: relative;
}

ion-menu {
  --width: 250px;
}

ion-menu-button {
  display: block; /* Show the button by default */
}

ion-menu.md ion-item.selected {
  --background: rgba(var(--ion-color-primary-rgb), 0.14);
}

ion-menu.md ion-item ion-icon {
  color: #616e7e;
}

ion-menu.ios ion-content {
  --padding-bottom: 20px;
}
</style>
