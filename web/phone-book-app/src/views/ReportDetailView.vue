<script setup>
import { ref, onMounted } from 'vue'
import { useRoute } from 'vue-router'
import { getReportById } from '@/services/reportService'

const report = ref(null)
const route = useRoute()
const id = route.params.id

onMounted(async () => {
  const response = await getReportById(id)
  report.value = response.data.data
})
</script>

<template>
  <div class="container mt-4">
    <h4>Rapor Detayları</h4>

    <div v-if="report">
      <p><strong>Ad:</strong> {{ report.name }}</p>
      <p><strong>İstek Tarihi:</strong> {{ new Date(report.requestedAt).toLocaleString() }}</p>
      <p><strong>Durum:</strong> {{ report.status }}</p>

      <hr />
      <h5>Konum Bazlı Bilgiler</h5>
      <table class="table table-bordered mt-2">
        <thead>
        <tr>
          <th>Konum</th>
          <th>Kişi Sayısı</th>
          <th>Telefon Sayısı</th>
        </tr>
        </thead>
        <tbody>
        <tr v-for="detail in report.details" :key="detail.id">
          <td>{{ detail.location }}</td>
          <td>{{ detail.personCount }}</td>
          <td>{{ detail.phoneNumberCount }}</td>
        </tr>
        </tbody>
      </table>
    </div>

    <div v-else>
      <p>Yükleniyor...</p>
    </div>
  </div>
</template>
