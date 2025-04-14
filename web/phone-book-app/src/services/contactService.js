import axios from 'axios'

const API = 'http://localhost:5000/gateway/contact/api/contact'

export function getContacts() {
  return axios.get(API)
}
