<script setup>
import { onMounted, ref } from 'vue'
import { getContacts, deleteContact } from '@/services/contactService'
import { useRouter } from 'vue-router'

const contacts = ref([])
const router = useRouter()

async function fetchContacts() {
  const response = await getContacts()
  contacts.value = response.data.data
}

async function removeContact(id) {
  await deleteContact(id)
  await fetchContacts()
}

function goToCreate() {
  router.push('/create')
}

onMounted(fetchContacts)
</script>

<template>
  <div class="container mt-4">
    <div class="d-flex justify-content-between align-items-center">
      <h4>Kisi Listesi</h4>
      <button class="btn btn-success" @click="goToCreate">Kisi Ekle</button>
    </div>

    <div class="row mt-3">
      <div class="col-md-4" v-for="item in contacts" :key="item.id">
        <div class="card mb-3 p-2">
          <h6>{{ item.name }} {{ item.surname }}</h6>
          <p>{{ item.company }}</p>
          <button class="btn btn-sm btn-primary me-2" @click="router.push(`/contact/form/${item.id}`)">Güncelle</button>
          <button class="btn btn-sm btn-danger" @click="removeContact(item.id)">Sil</button>
        </div>
      </div>
    </div>
  </div>
</template>
