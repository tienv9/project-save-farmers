import { createRouter, createWebHistory } from '@ionic/vue-router';
import { RouteRecordRaw } from 'vue-router';

const routes: Array<RouteRecordRaw> = [
  {
    path: '',
    redirect: '/Login'
  },
  {
    path: '/Login',
    component: () => import ('@/pages/LogPage.vue')
  },
  {
    path: '/Profile',
    component: () => import ('@/pages/Profile.vue')
  },
  {
    path: '/:id',
    component: () => import ('@/pages/FolderPage.vue')
  },
  {
    path: '/database',
    component: () => import ('@/pages/database.vue')
  }

]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes
})

export default router
