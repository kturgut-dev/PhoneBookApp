import axios from 'axios'

const API = 'http://localhost:5000/gateway/contact/contact'

export function getContacts() {
  return axios.get(API)
}

export function getContactById(id) {
  return axios.get(`${API}/${id}`)
}


export function createContact(data) {
  return axios.post('http://localhost:5000/gateway/contact/contact', data, {
    headers: {
      'Content-Type': 'application/json'
    }
  });
}



export function updateContact(id,data) {
  data.Id = id;
  return axios.put('http://localhost:5000/gateway/contact/contact', data, {
    headers: {
      'Content-Type': 'application/json'
    }
  });
}


export function deleteContact(id) {
  return axios.delete(`${API}/${id}`)
}
