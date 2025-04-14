<script setup>
import { onMounted, ref } from 'vue'
import { getContacts } from '@/services/contactService'

const contacts = ref([])

onMounted(async () => {
  const response = await getContacts()
  contacts.value = response.data.data
})
</script>

<template>
  <div class="container mt-4">
    <h4>Kişi Listesi</h4>
    <div class="row">
      <div class="col-md-4" v-for="item in contacts" :key="item.id">
        <div class="card mb-3 p-2">
          <h6>{{ item.name }} {{ item.surname }}</h6>
          <p>{{ item.company }}</p>
        </div>
      </div>
    </div>
  </div>
</template>
