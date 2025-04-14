<script setup>
import { ref, onMounted } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { createContact, getContactById, updateContact } from '@/services/contactService'

const form = ref({ name: '', surname: '', company: '' })
const route = useRoute()
const router = useRouter()
const id = route.params.id

onMounted(async () => {
  if (id) {
    const response = await getContactById(id)
    form.value = response.data.data
  }
})

async function submit() {
  if (id) await updateContact(id, form.value)
  else await createContact(form.value)
  router.push('/')
}
</script>

<template>
  <div class="container mt-4">
    <h4>{{ id ? 'Kisi Güncelle' : 'Kisi Ekle' }}</h4>
    <form @submit.prevent="submit">
      <div class="mb-3">
        <label>Ad</label>
        <input v-model="form.name" class="form-control" required />
      </div>
      <div class="mb-3">
        <label>Soyad</label>
        <input v-model="form.surname" class="form-control" required />
      </div>
      <div class="mb-3">
        <label>Firma</label>
        <input v-model="form.company" class="form-control" />
      </div>
      <button class="btn btn-primary">Kaydet</button>
    </form>
  </div>
</template>


