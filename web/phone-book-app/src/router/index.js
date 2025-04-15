import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import ContactList from "@/views/ContactList.vue";
import ContactForm from "@/views/ContactForm.vue";
import ReportView from "@/views/ReportView.vue";
import ReportDetailView from "@/views/ReportDetailView.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: ContactList,
    },
    {
      path: '/reports',
      name: 'reports',
      component: ReportView,
    },
    {
      path: '/reports/:id',
      name: 'report-detail',
      component: ReportDetailView
    },
    {
      path: '/contact/form',
      name: 'contact.form',
      component: ContactForm,
    },
    {
      path: '/contact/form/:id',
      name: 'contact.edit',
      component: ContactForm,
      props: true,
    },
  ],
})

export default router
