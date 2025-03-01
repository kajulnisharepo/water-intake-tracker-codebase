import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import './assets/tailwind.css'
import axios from 'axios'

// Set base URL for axios
axios.defaults.baseURL = 'http://localhost:5004/api'

const app = createApp(App)

app.use(router)

app.mount('#app')
