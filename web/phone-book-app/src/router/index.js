import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import ContactList from "@/views/ContactList.vue";
import ContactForm from "@/views/ContactForm.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: ContactList,
    },
    {
      path: '/contact/form',
      name: 'contact.form',
      component: ContactForm,
    },
  ],
})

export default router
