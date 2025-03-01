<template>
  <div class="min-h-screen flex items-center justify-center bg-light-background dark:bg-dark-background py-12 px-4 sm:px-6 lg:px-8">
    <div class="max-w-md w-full space-y-8">
      <div>
        <h2 class="mt-6 text-center text-3xl font-extrabold text-light-text dark:text-dark-text">
          Sign in to your account
        </h2>
      </div>
      <form class="mt-8 space-y-6" @submit.prevent="handleLogin">
        <input type="hidden" name="remember" value="true" />
        <div class="rounded-md shadow-sm -space-y-px">
          <div>
            <label for="username-or-email" class="sr-only">Username or Email</label>
            <input id="username-or-email" name="username-or-email" type="text" required
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-light-accent1 dark:border-dark-accent1 placeholder-light-text dark:placeholder-dark-text text-light-text dark:text-dark-text rounded-t-md focus:outline-none focus:ring-light-primary dark:focus:ring-dark-primary focus:border-light-primary dark:focus:border-dark-primary focus:z-10 sm:text-sm bg-light-background dark:bg-dark-background"
              placeholder="Username or Email" v-model="loginForm.usernameOrEmail" />
          </div>
          <div>
            <label for="password" class="sr-only">Password</label>
            <input id="password" name="password" type="password" required
              class="appearance-none rounded-none relative block w-full px-3 py-2 border border-light-accent1 dark:border-dark-accent1 placeholder-light-text dark:placeholder-dark-text text-light-text dark:text-dark-text rounded-b-md focus:outline-none focus:ring-light-primary dark:focus:ring-dark-primary focus:border-light-primary dark:focus:border-dark-primary focus:z-10 sm:text-sm bg-light-background dark:bg-dark-background"
              placeholder="Password" v-model="loginForm.password" />
          </div>
        </div>

        <div>
          <button type="submit"
            class="group relative w-full flex justify-center py-2 px-4 border border-transparent text-sm font-medium rounded-md text-white bg-light-primary dark:bg-dark-primary hover:bg-light-secondary dark:hover:bg-dark-secondary focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-light-primary dark:focus:ring-dark-primary transition-colors duration-200">
            Sign in
          </button>
        </div>
      </form>
      <div class="text-center">
        <router-link to="/register" class="font-medium text-light-primary dark:text-dark-primary hover:text-light-secondary dark:hover:text-dark-secondary transition-colors duration-200">
          Don't have an account? Sign up
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
  name: 'LoginPage',
  setup() {
    const router = useRouter();
    const loginForm = ref({
      usernameOrEmail: '',
      password: '',
    });

    const handleLogin = async () => {
      try {
        const response = await axios.post('http://localhost:5004/api/auth/login', loginForm.value);
        if (response.data.isSuccess) {
          // Store the token in localStorage or a state management store
          localStorage.setItem('token', response.data.data);
          // Redirect to dashboard
          router.push('/dashboard');
        } else {
          // Handle login error
          console.error('Login failed:', response.data.message);
        }
      } catch (error) {
        console.error('Login error:', error);
      }
    };

    return {
      loginForm,
      handleLogin,
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
