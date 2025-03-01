<template>
  <div class="min-h-screen flex items-center justify-center bg-light-background dark:bg-dark-background py-12 px-4 sm:px-6 lg:px-8">
    <div class="max-w-md w-full space-y-8">
      <div>
        <h2 class="mt-6 text-center text-3xl font-extrabold text-light-text dark:text-dark-text">
          {{ registrationData.message }}
        </h2>
      </div>
      <div class="mt-8 space-y-6">
        <div class="rounded-md bg-light-accent1 dark:bg-dark-accent1 shadow-sm -space-y-px p-4">
          <p class="text-lg font-medium text-light-text dark:text-dark-text">Welcome, {{ registrationData.name }}!</p>
          <p class="text-sm text-light-text dark:text-dark-text opacity-80">Your account has been created successfully.</p>
          <div class="mt-4">
            <p class="text-sm text-light-text dark:text-dark-text opacity-80">Username: {{ registrationData.username }}</p>
            <p class="text-sm text-light-text dark:text-dark-text opacity-80">Email: {{ registrationData.email }}</p>
            <p class="text-sm text-light-text dark:text-dark-text opacity-80">BMI: {{ registrationData.bmi.toFixed(2) }}</p>
          </div>
        </div>
        <div>
          <button @click="goToDashboard"
            class="group relative w-full flex justify-center py-2 px-4 border border-transparent text-sm font-medium rounded-md text-white bg-light-primary dark:bg-dark-primary hover:bg-light-secondary dark:hover:bg-dark-secondary focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-light-primary dark:focus:ring-dark-primary transition-colors duration-200">
            Continue to Dashboard
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { ref, onMounted } from 'vue';
import { useRouter, useRoute } from 'vue-router';

export default {
  name: 'ConfirmationPage',
  setup() {
    const router = useRouter();
    const route = useRoute();
    const registrationData = ref({});

    onMounted(() => {
      if (route.params.registrationData) {
        registrationData.value = route.params.registrationData;
      } else {
        // If no registration data is available, redirect to the registration page
        router.push('/register');
      }
    });

    const goToDashboard = () => {
      router.push('/dashboard');
    };

    return {
      registrationData,
      goToDashboard,
    };
  },
};
</script>

<style scoped>
@media (max-width: 640px) {
  .max-w-md {
    width: 90%;
  }
}
</style>
