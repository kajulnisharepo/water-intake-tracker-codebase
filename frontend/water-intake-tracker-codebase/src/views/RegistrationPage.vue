<template>
  <div class="min-h-screen flex items-center justify-center bg-light-background dark:bg-dark-background py-12 px-4 sm:px-6 lg:px-8">
    <div class="max-w-md w-full space-y-8">
      <div>
        <h2 class="mt-6 text-center text-3xl font-extrabold text-light-text dark:text-dark-text">
          Create your account
        </h2>
      </div>
      <form class="mt-8 space-y-6" @submit.prevent="handleRegister">
        <input type="hidden" name="remember" value="true" />
        <div class="rounded-md shadow-sm -space-y-px">
          <div>
            <label for="name" class="sr-only">Name</label>
            <input id="name" name="name" type="text" required
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-light-accent1 dark:border-dark-accent1 placeholder-light-text dark:placeholder-dark-text text-light-text dark:text-dark-text rounded-t-md focus:outline-none focus:ring-light-primary dark:focus:ring-dark-primary focus:border-light-primary dark:focus:border-dark-primary focus:z-10 sm:text-sm bg-light-background dark:bg-dark-background"
              placeholder="Name" v-model="registrationForm.name" />
          </div>
          <div>
            <label for="username" class="sr-only">Username</label>
            <input id="username" name="username" type="text" required
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-light-accent1 dark:border-dark-accent1 placeholder-light-text dark:placeholder-dark-text text-light-text dark:text-dark-text focus:outline-none focus:ring-light-primary dark:focus:ring-dark-primary focus:border-light-primary dark:focus:border-dark-primary focus:z-10 sm:text-sm bg-light-background dark:bg-dark-background"
              placeholder="Username" v-model="registrationForm.username" />
          </div>
          <div>
            <label for="email" class="sr-only">Email</label>
            <input id="email" name="email" type="email" required
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-light-accent1 dark:border-dark-accent1 placeholder-light-text dark:placeholder-dark-text text-light-text dark:text-dark-text focus:outline-none focus:ring-light-primary dark:focus:ring-dark-primary focus:border-light-primary dark:focus:border-dark-primary focus:z-10 sm:text-sm bg-light-background dark:bg-dark-background"
              placeholder="Email" v-model="registrationForm.email" />
          </div>
          <div>
            <label for="password" class="sr-only">Password</label>
            <input id="password" name="password" type="password" required
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-light-accent1 dark:border-dark-accent1 placeholder-light-text dark:placeholder-dark-text text-light-text dark:text-dark-text focus:outline-none focus:ring-light-primary dark:focus:ring-dark-primary focus:border-light-primary dark:focus:border-dark-primary focus:z-10 sm:text-sm bg-light-background dark:bg-dark-background"
              placeholder="Password" v-model="registrationForm.password" />
          </div>
          <div>
            <label for="age" class="sr-only">Age</label>
            <input id="age" name="age" type="number" required
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-light-accent1 dark:border-dark-accent1 placeholder-light-text dark:placeholder-dark-text text-light-text dark:text-dark-text focus:outline-none focus:ring-light-primary dark:focus:ring-dark-primary focus:border-light-primary dark:focus:border-dark-primary focus:z-10 sm:text-sm bg-light-background dark:bg-dark-background"
              placeholder="Age" v-model="registrationForm.age" />
          </div>
          <div>
            <label for="weight" class="sr-only">Weight (kg)</label>
            <input id="weight" name="weight" type="number" step="0.1" required
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-light-accent1 dark:border-dark-accent1 placeholder-light-text dark:placeholder-dark-text text-light-text dark:text-dark-text focus:outline-none focus:ring-light-primary dark:focus:ring-dark-primary focus:border-light-primary dark:focus:border-dark-primary focus:z-10 sm:text-sm bg-light-background dark:bg-dark-background"
              placeholder="Weight (kg)" v-model="registrationForm.weight" />
          </div>
          <div>
            <label for="height" class="sr-only">Height (cm)</label>
            <input id="height" name="height" type="number" step="0.1" required
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-light-accent1 dark:border-dark-accent1 placeholder-light-text dark:placeholder-dark-text text-light-text dark:text-dark-text rounded-b-md focus:outline-none focus:ring-light-primary dark:focus:ring-dark-primary focus:border-light-primary dark:focus:border-dark-primary focus:z-10 sm:text-sm bg-light-background dark:bg-dark-background"
              placeholder="Height (cm)" v-model="registrationForm.height" />
          </div>
        </div>

        <div>
          <button type="submit"
            class="group relative w-full flex justify-center py-2 px-4 border border-transparent text-sm font-medium rounded-md text-white bg-light-primary dark:bg-dark-primary hover:bg-light-secondary dark:hover:bg-dark-secondary focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-light-primary dark:focus:ring-dark-primary transition-colors duration-200">
            Register
          </button>
        </div>
      </form>
      <div class="text-center">
        <router-link to="/login" class="font-medium text-light-primary dark:text-dark-primary hover:text-light-secondary dark:hover:text-dark-secondary transition-colors duration-200">
          Already have an account? Sign in
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
import { ref } from 'vue';
import { useRouter } from 'vue-router';
import axios from 'axios';

export default {
  name: 'RegistrationPage',
  setup() {
    const router = useRouter();
    const registrationForm = ref({
      name: '',
      username: '',
      email: '',
      password: '',
      age: null,
      weight: null,
      height: null,
    });

    const handleRegister = async () => {
      try {
        const response = await axios.post('http://localhost:5004/api/user/register', registrationForm.value);
        if (response.data.responseType === 'Success') {
          // Redirect to confirmation page
          router.push({
            name: 'Confirmation',
            params: { registrationData: response.data.data }
          });
        } else {
          // Handle registration error
          console.error('Registration failed:', response.data.message);
          // You might want to show this error message to the user
          alert(response.data.message);
        }
      } catch (error) {
        console.error('Registration error:', error);
        // You might want to show a generic error message to the user
        alert('An error occurred during registration. Please try again.');
      }
    };

    return {
      registrationForm,
      handleRegister,
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
