<script setup>
import { onMounted, ref } from 'vue'
import { useRoute } from 'vue-router'
import axios from 'axios'

const route = useRoute()
const reportId = route.params.id
const details = ref([])

async function fetchDetails() {
  const response = await axios.get(`http://localhost:5000/gateway/report/report/${reportId}`)
  details.value = response.data.data.reportDetails
}

onMounted(fetchDetails)
</script>

<template>
  <div class="container mt-4">
    <h4>Rapor Detayı</h4>

    <table class="table table-striped mt-3">
      <thead>
      <tr>
        <th>Konum</th>
        <th>Kişi Sayısı</th>
        <th>Telefon Sayısı</th>
      </tr>
      </thead>
      <tbody>
      <tr v-for="item in details" :key="item.id">
        <td>{{ item.location }}</td>
        <td>{{ item.personCount }}</td>
        <td>{{ item.phoneNumberCount }}</td>
      </tr>
      </tbody>
    </table>
  </div>
</template>
