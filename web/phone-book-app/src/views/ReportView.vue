<script setup>
import {ref, onMounted} from 'vue'
import {createReport, getReports, getReportStatus} from '@/services/reportService'
import { useRouter } from 'vue-router'


const router = useRouter()

const reports = ref([])
const reportName = ref('')

async function requestReport() {
  if (!reportName.value) return
  const response = await createReport(reportName.value)
  reportName.value = ''
  await fetchReports()
}

async function fetchReports() {
  const response = await getReports()
  reports.value = response.data.data
}

onMounted(fetchReports)
</script>

<template>
  <div class="container mt-4">
    <h4>Rapor Listesi</h4>

    <div class="d-flex mb-3">
      <input v-model="reportName" class="form-control me-2" placeholder="Rapor Adı Girin"/>
      <button class="btn btn-primary" @click="requestReport">Rapor Oluştur</button>
    </div>

    <table class="table table-bordered">
      <thead>
      <tr>
        <th>Ad</th>
        <th>Tarih</th>
        <th>Durum</th>
        <th>#</th>
      </tr>
      </thead>
      <tbody>
      <tr v-for="report in reports" :key="report.id">
        <td>{{ report.name }}</td>
        <td>{{ new Date(report.requestedAt).toLocaleString() }}</td>
        <td>{{ report.status }}</td>
        <td>
          <button class="btn btn-primary" @click="router.push(`/report/${item.id}`)">Detay</button>
        </td>
      </tr>
      </tbody>
    </table>
  </div>
</template>
