<template>
  <div class="min-h-screen bg-light-background dark:bg-dark-background">
    <header class="bg-light-accent1 dark:bg-dark-accent1 shadow">
      <div class="max-w-7xl mx-auto py-6 px-4 sm:px-6 lg:px-8 flex justify-between items-center">
        <h1 class="text-3xl font-bold text-light-text dark:text-dark-text">Dashboard</h1>
        <div class="flex items-center">
          <span class="text-light-text dark:text-dark-text mr-4">Welcome, {{ username }}</span>
          <button @click="logout" class="bg-light-error dark:bg-dark-error hover:bg-light-secondary dark:hover:bg-dark-secondary text-white font-bold py-2 px-4 rounded transition-colors duration-200">
            Logout
          </button>
        </div>
      </div>
    </header>
    <main class="max-w-7xl mx-auto py-6 sm:px-6 lg:px-8">
      <div class="px-4 py-6 sm:px-0">
        <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
          <div class="bg-white dark:bg-gray-800 overflow-hidden shadow rounded-lg">
            <div class="px-4 py-5 sm:p-6">
              <h3 class="text-lg leading-6 font-medium text-light-text dark:text-dark-text">
                Fitness Goals
              </h3>
              <div class="mt-5">
                <div class="flex items-center">
                  <input type="checkbox" id="goal1" class="form-checkbox h-5 w-5 text-light-primary dark:text-dark-primary" />
                  <label for="goal1" class="ml-2 block text-sm text-light-text dark:text-dark-text">
                    Exercise for 30 minutes daily
                  </label>
                </div>
                <div class="flex items-center mt-2">
                  <input type="checkbox" id="goal2" class="form-checkbox h-5 w-5 text-light-primary dark:text-dark-primary" />
                  <label for="goal2" class="ml-2 block text-sm text-light-text dark:text-dark-text">
                    Drink 8 glasses of water
                  </label>
                </div>
                <div class="flex items-center mt-2">
                  <input type="checkbox" id="goal3" class="form-checkbox h-5 w-5 text-light-primary dark:text-dark-primary" />
                  <label for="goal3" class="ml-2 block text-sm text-light-text dark:text-dark-text">
                    Get 8 hours of sleep
                  </label>
                </div>
              </div>
            </div>
          </div>
          <div class="bg-white dark:bg-gray-800 overflow-hidden shadow rounded-lg">
            <div class="px-4 py-5 sm:p-6">
              <h3 class="text-lg leading-6 font-medium text-light-text dark:text-dark-text">
                Today's Activity
              </h3>
              <div class="mt-5">
                <div class="flex justify-between items-center">
                  <span class="text-sm text-light-text dark:text-dark-text">Steps</span>
                  <span class="text-sm font-medium text-light-primary dark:text-dark-primary">5,000 / 10,000</span>
                </div>
                <div class="mt-2 h-2 bg-gray-200 rounded-full">
                  <div class="h-2 bg-light-primary dark:bg-dark-primary rounded-full" style="width: 50%"></div>
                </div>
                <div class="flex justify-between items-center mt-4">
                  <span class="text-sm text-light-text dark:text-dark-text">Calories Burned</span>
                  <span class="text-sm font-medium text-light-primary dark:text-dark-primary">250 kcal</span>
                </div>
                <div class="flex justify-between items-center mt-4">
                  <span class="text-sm text-light-text dark:text-dark-text">Active Time</span>
                  <span class="text-sm font-medium text-light-primary dark:text-dark-primary">45 minutes</span>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </main>
  </div>
</template>

<script>
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';

export default {
  name: 'DashboardPage',
  setup() {
    const router = useRouter();
    const username = ref('');

    onMounted(() => {
      // In a real application, you would fetch the user's data from an API
      // For now, we'll just use the stored username or a default value
      username.value = localStorage.getItem('username') || 'User';
    });

    const logout = () => {
      // Clear the stored token and any other user data
      localStorage.removeItem('token');
      localStorage.removeItem('username');
      // Redirect to the login page
      router.push('/login');
    };

    return {
      username,
      logout,
    };
  },
};
</script>
