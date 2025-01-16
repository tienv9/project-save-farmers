<template>
  <ion-modal :is-open="isOpen" @ionModalDidDismiss="handleClose">
    <ion-header>
      <ion-toolbar>
        <ion-title>New Post</ion-title>
        <ion-buttons slot="end">
          <ion-button @click="handleClose">Close</ion-button>
        </ion-buttons>
      </ion-toolbar>
    </ion-header>
    <ion-content class="ion-padding">
      <p>
        Lorem ipsum dolor sit amet consectetur adipisicing elit. Magni illum quidem recusandae ducimus quos
        reprehenderit. Veniam, molestias quos, dolorum consequuntur nisi deserunt omnis id illo sit cum qui. Eaque,
        dicta.
      </p>
    </ion-content>
  </ion-modal>
</template>

<script lang="ts" setup>
import { IonModal, IonHeader, IonToolbar, IonButtons, IonButton, IonTitle, IonContent } from '@ionic/vue';
import { ref, defineProps } from 'vue';

// Props to control modal open state from parent component
const props = defineProps({
  isOpen: {
    type: Boolean,
    required: true
  }
});

// Emit event to the parent component to close the modal
const emit = defineEmits(['update:isOpen']);

const handleClose = () => {
  emit('update:isOpen', false);
};
</script>
