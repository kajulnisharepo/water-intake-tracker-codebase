<template>
  <div id="app" class="min-h-screen bg-light-background dark:bg-dark-background text-light-text dark:text-dark-text">
    <header class="bg-light-accent1 dark:bg-dark-accent1 shadow">
      <nav class="container mx-auto px-4 sm:px-6 py-4">
        <div class="flex flex-wrap justify-between items-center">
          <router-link to="/" class="text-2xl font-bold text-light-primary dark:text-dark-primary">Fitness Tracker</router-link>
          <div class="flex items-center space-x-4 mt-2 sm:mt-0">
            <ThemeToggle />
            <template v-if="!isAuthenticated">
              <router-link to="/login" class="text-light-primary dark:text-dark-primary hover:text-light-secondary dark:hover:text-dark-secondary transition-colors duration-200">Login</router-link>
              <router-link to="/register" class="text-light-primary dark:text-dark-primary hover:text-light-secondary dark:hover:text-dark-secondary transition-colors duration-200">Register</router-link>
            </template>
            <button v-else @click="logout" class="bg-light-secondary dark:bg-dark-secondary hover:bg-light-primary dark:hover:bg-dark-primary text-white font-bold py-2 px-4 rounded transition-colors duration-200">
              Logout
            </button>
          </div>
        </div>
      </nav>
    </header>

    <main class="container mx-auto px-4 sm:px-6 py-8">
      <router-view></router-view>
    </main>

    <footer class="bg-light-accent1 dark:bg-dark-accent1 py-4 mt-8">
      <div class="container mx-auto px-4 text-center text-light-text dark:text-dark-text">
        &copy; 2025 Fitness Tracker. All rights reserved.
      </div>
    </footer>
  </div>
</template>

<script>
import { computed } from 'vue';
import { useRouter } from 'vue-router';
import ThemeToggle from './components/ThemeToggle.vue';

export default {
  name: 'App',
  components: {
    ThemeToggle
  },
  setup() {
    const router = useRouter();
    const isAuthenticated = computed(() => !!localStorage.getItem('token'));

    const logout = () => {
      localStorage.removeItem('token');
      localStorage.removeItem('username');
      router.push('/login');
    };

    return {
      isAuthenticated,
      logout
    };
  }
};
</script>

<style>
@import './assets/tailwind.css';

/* Custom styles for mobile responsiveness */
@media (max-width: 640px) {
  .container {
    padding-left: 1rem;
    padding-right: 1rem;
  }
}

/* Smooth transitions for theme changes */
.transition-colors {
  transition-property: background-color, border-color, color, fill, stroke;
  transition-timing-function: cubic-bezier(0.4, 0, 0.2, 1);
  transition-duration: 200ms;
}

/* Any additional custom styles can be added here */
</style>
