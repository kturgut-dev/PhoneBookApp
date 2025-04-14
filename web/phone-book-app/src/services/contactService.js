import axios from 'axios'

const API = 'http://localhost:5000/gateway/contact/contact'

export function getContacts() {
  return axios.get(API)
}

export function getContactById(id) {
  return axios.get(`${API}/${id}`)
}

export function createContact(data) {
  return axios.post(API, data)
}

export function updateContact(id, data) {
  return axios.put(`${API}/${id}`, data)
}

export function deleteContact(id) {
  return axios.delete(`${API}/${id}`)
}
