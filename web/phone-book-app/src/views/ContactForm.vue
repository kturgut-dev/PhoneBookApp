<script setup>
import { ref, onMounted } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import {
  createContact,
  getContactById,
  updateContact
} from '@/services/contactService'
import {
  getContactInfos,
  createContactInfo,
  deleteContactInfo
} from '@/services/contactInfoService'

const form = ref({
  id: null,
  name: '',
  surname: '',
  company: '',
  contactInfos: []
})

const newInfo = ref({
  infoType: 0,
  title: '',
  content: ''
})

const route = useRoute()
const router = useRouter()
const id = route.params.id

onMounted(async () => {
  if (id) {
    const response = await getContactById(id)
    form.value = response.data.data

    const infos = await getContactInfos(id)
    form.value.contactInfos = infos.data.data
  }
})

async function submit() {
  if (id) await updateContact(id, form.value)
  else await createContact(form.value)
  router.push('/')
}

async function addInfo() {
  if (!form.value.id) {
    alert('Önce kişiyi kaydedin.')
    return
  }

  const data = {
    contactId: form.value.id,
    infoType: Number(newInfo.value.infoType),
    title: newInfo.value.title,
    content: newInfo.value.content
  }

  await createContactInfo(data)
  const infos = await getContactInfos(form.value.id)
  form.value.contactInfos = infos.data.data

  newInfo.value = { infoType: 0, title: '', content: '' }
}

async function removeInfo(id) {
  await deleteContactInfo(id)
  const infos = await getContactInfos(form.value.id)
  form.value.contactInfos = infos.data.data
}
</script>

<template>
  <div class="container mt-4">
    <h4>{{ id ? 'Kişi Güncelle' : 'Kişi Ekle' }}</h4>
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

    <div v-if="id" class="mt-5">
      <h5>İletişim Bilgileri</h5>

      <form class="row g-3" @submit.prevent="addInfo">
        <div class="col-md-3">
          <select v-model="newInfo.infoType" class="form-select">
            <option value="0">PhoneNumber</option>
            <option value="1">Email</option>
            <option value="2">Location</option>
            <option value="3">Anniversary</option>
          </select>
        </div>
        <div class="col-md-3">
          <input v-model="newInfo.title" class="form-control" placeholder="Başlık" />
        </div>
        <div class="col-md-4">
          <input v-model="newInfo.content" class="form-control" placeholder="İçerik" />
        </div>
        <div class="col-md-2">
          <button type="submit" class="btn btn-success w-100">Ekle</button>
        </div>
      </form>

      <ul class="list-group mt-3">
        <li v-for="info in form.contactInfos" :key="info.id" class="list-group-item d-flex justify-content-between align-items-center">
          <div>
            <strong>{{ info.infoType }}</strong>: {{ info.title }} - {{ info.content }}
          </div>
          <button @click="removeInfo(info.id)" class="btn btn-sm btn-danger">Sil</button>
        </li>
      </ul>
    </div>
  </div>
</template>
