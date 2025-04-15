import axios from 'axios'

const API = 'http://localhost:5000/gateway/report/report'

export function createReport(name) {
  return axios.post(API, { name })
}

export function getReports() {
  return axios.get(API)
}

export function getReportStatus(id) {
  return axios.get(`${API}/${id}/status`)
}
