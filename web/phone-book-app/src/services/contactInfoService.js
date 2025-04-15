import axios from 'axios'

const API = 'http://localhost:5000/gateway/contact/contactInfo'

export function getContactInfos(contactId) {
  return axios.get(`${API}/list/${contactId}`)
}

export function createContactInfo(data) {
  return axios.post(API, data, {
    headers: {
      'Content-Type': 'application/json'
    }
  })
}

export function updateContactInfo(id, data) {
  data.id = id
  return axios.put(API, data, {
    headers: {
      'Content-Type': 'application/json'
    }
  })
}

export function deleteContactInfo(id) {
  return axios.delete(`${API}/${id}`)
}
