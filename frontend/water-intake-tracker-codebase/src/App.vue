<template>
  <div class="min-h-screen bg-light dark:bg-dark text-light dark:text-dark transition-colors duration-300">
    <div class="container mx-auto px-4 py-8">
      <div class="flex justify-end mb-4">
        <ThemeToggle />
      </div>
      <div class="relative py-3 sm:max-w-xl sm:mx-auto">
        <div class="absolute inset-0 bg-gradient-to-r from-cyan-400 to-light-blue-500 shadow-lg transform -skew-y-6 sm:skew-y-0 sm:-rotate-6 sm:rounded-3xl"></div>
        <div class="relative px-4 py-10 bg-white dark:bg-gray-800 shadow-lg sm:rounded-3xl sm:p-20">
          <div class="max-w-md mx-auto">
            <h1 class="text-3xl font-extrabold text-gray-900 dark:text-white mb-6 text-center">Fitness Tracker</h1>
            <RegistrationForm v-if="!registrationComplete" @registration-complete="onRegistrationComplete" />
            <ProfileConfirmation v-else :user="user" />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import RegistrationForm from './components/user/registration/RegistrationForm.vue'
import ProfileConfirmation from './components/user/profile/ProfileConfirmation.vue'
import ThemeToggle from './components/ThemeToggle.vue'

export default {
  name: 'App',
  components: {
    RegistrationForm,
    ProfileConfirmation,
    ThemeToggle
  },
  data() {
    return {
      registrationComplete: false,
      user: null
    }
  },
  methods: {
    onRegistrationComplete(userData) {
      this.user = userData;
      this.registrationComplete = true;
    }
  }
}
</script>

<style>
/* Any custom styles can be added here */
</style>
