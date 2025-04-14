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


export function updateContact(data) {
  return axios.put('http://localhost:5000/gateway/contact/contact', {
    id: data.id,
    name: data.name,
    surname: data.surname,
    company: data.company,
    nickname: data.nickname,
    website: data.website,
    note: data.note
  }, {
    headers: {
      'Content-Type': 'application/json'
    }
  });
}


export function deleteContact(id) {
  return axios.delete(`${API}/${id}`)
}
