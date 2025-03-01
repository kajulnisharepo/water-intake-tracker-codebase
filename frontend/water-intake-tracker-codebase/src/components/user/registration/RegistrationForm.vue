<template>
  <div class="max-w-md mx-auto mt-10 bg-white dark:bg-gray-800 p-8 border border-gray-300 dark:border-gray-700 rounded-lg shadow-lg">
    <h2 class="text-2xl font-bold mb-6 text-center text-gray-800 dark:text-white">User Registration</h2>
    <form @submit.prevent="submitForm" class="space-y-4">
      <div>
        <label for="name" class="block text-sm font-medium text-gray-700 dark:text-gray-300">Name</label>
        <input type="text" id="name" v-model="form.name" required class="mt-1 block w-full rounded-md border-gray-300 dark:border-gray-600 shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50 dark:bg-gray-700 dark:text-white">
      </div>
      <div>
        <label for="age" class="block text-sm font-medium text-gray-700 dark:text-gray-300">Age</label>
        <input type="number" id="age" v-model="form.age" required min="1" max="120" class="mt-1 block w-full rounded-md border-gray-300 dark:border-gray-600 shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50 dark:bg-gray-700 dark:text-white">
      </div>
      <div>
        <label for="weight" class="block text-sm font-medium text-gray-700 dark:text-gray-300">Weight (kg)</label>
        <input type="number" id="weight" v-model="form.weight" required min="1" max="500" step="0.1" class="mt-1 block w-full rounded-md border-gray-300 dark:border-gray-600 shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50 dark:bg-gray-700 dark:text-white">
      </div>
      <div>
        <label for="height" class="block text-sm font-medium text-gray-700 dark:text-gray-300">Height (cm)</label>
        <input type="number" id="height" v-model="form.height" required min="1" max="300" step="0.1" class="mt-1 block w-full rounded-md border-gray-300 dark:border-gray-600 shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50 dark:bg-gray-700 dark:text-white">
      </div>
      <div>
        <button type="submit" class="w-full py-2 px-4 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500 dark:bg-indigo-500 dark:hover:bg-indigo-600">
          Sign Up
        </button>
      </div>
    </form>
    <div v-if="error" class="mt-4 text-red-600 dark:text-red-400">{{ error }}</div>
  </div>
</template>

<script>
import axios from 'axios';

const API_URL = process.env.VUE_APP_API_URL || 'http://localhost:5004';

export default {
  name: 'RegistrationForm',
  data() {
    return {
      form: {
        name: '',
        age: null,
        weight: null,
        height: null
      },
      bmi: null,
      bmiCategory: '',
      error: null,
      isLoading: false
    }
  },
  methods: {
    async submitForm() {
      try {
        this.error = null;
        this.isLoading = true;
        this.calculateBMI();
        
        console.log('Submitting form to:', `${API_URL}/api/user/register`);
        console.log('Form data:', { ...this.form, bmi: this.bmi });

        // Make API call to register user
        const response = await axios.post(`${API_URL}/api/user/register`, {
          ...this.form,
          bmi: this.bmi
        });

        console.log('API Response:', response);

        if (response.data.isSuccess) {
          console.log('User registered successfully:', response.data);
          this.$emit('registration-complete', {
            ...this.form,
            bmi: this.bmi,
            bmiCategory: this.bmiCategory
          });
        } else {
          this.error = response.data.message || 'Registration failed. Please try again.';
        }
      } catch (error) {
        console.error('Error during registration:', error);
        if (error.response) {
          console.error('Error response:', error.response);
          this.error = `Server error: ${error.response.status} - ${error.response.data.message || 'An error occurred during registration. Please try again.'}`;
        } else if (error.request) {
          console.error('No response received:', error.request);
          this.error = 'No response from server. Please check your internet connection and try again.';
        } else {
          console.error('Request setup error:', error.message);
          this.error = `An error occurred during registration: ${error.message}`;
        }
      } finally {
        this.isLoading = false;
      }
    },
    calculateBMI() {
      const heightInMeters = this.form.height / 100;
      this.bmi = +(this.form.weight / (heightInMeters * heightInMeters)).toFixed(2);
      this.bmiCategory = this.getBMICategory(this.bmi);
    },
    getBMICategory(bmi) {
      if (bmi < 18.5) return 'Underweight';
      if (bmi < 25) return 'Normal weight';
      if (bmi < 30) return 'Overweight';
      return 'Obese';
    }
  }
}
</script>
