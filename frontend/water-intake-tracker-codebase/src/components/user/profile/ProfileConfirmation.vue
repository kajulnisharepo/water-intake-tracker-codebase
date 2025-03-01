<template>
  <div class="max-w-md mx-auto mt-10 bg-white dark:bg-gray-800 p-8 border border-gray-300 dark:border-gray-700 rounded-lg shadow-lg">
    <h2 class="text-2xl font-bold mb-6 text-center text-gray-800 dark:text-white">Profile Confirmation</h2>
    <div class="space-y-4">
      <div>
        <p class="text-sm font-medium text-gray-700 dark:text-gray-300">Name</p>
        <p class="mt-1 text-lg font-semibold text-gray-900 dark:text-white">{{ user.name }}</p>
      </div>
      <div>
        <p class="text-sm font-medium text-gray-700 dark:text-gray-300">Age</p>
        <p class="mt-1 text-lg font-semibold text-gray-900 dark:text-white">{{ user.age }} years</p>
      </div>
      <div>
        <p class="text-sm font-medium text-gray-700 dark:text-gray-300">Weight</p>
        <p class="mt-1 text-lg font-semibold text-gray-900 dark:text-white">{{ user.weight }} kg</p>
      </div>
      <div>
        <p class="text-sm font-medium text-gray-700 dark:text-gray-300">Height</p>
        <p class="mt-1 text-lg font-semibold text-gray-900 dark:text-white">{{ user.height }} cm</p>
      </div>
      <div>
        <p class="text-sm font-medium text-gray-700 dark:text-gray-300">BMI</p>
        <p class="mt-1 text-lg font-semibold text-gray-900 dark:text-white">{{ user.bmi }}</p>
      </div>
      <div>
        <p class="text-sm font-medium text-gray-700 dark:text-gray-300">BMI Category</p>
        <p class="mt-1 text-lg font-semibold" :class="bmiCategoryColor">{{ bmiCategory }}</p>
      </div>
    </div>
    <div class="mt-8">
      <button @click="proceedToDashboard" class="w-full py-2 px-4 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500 dark:bg-indigo-500 dark:hover:bg-indigo-600">
        Proceed to Dashboard
      </button>
    </div>
  </div>
</template>

<script>
export default {
  name: 'ProfileConfirmation',
  props: {
    user: {
      type: Object,
      required: true
    }
  },
  computed: {
    bmiCategory() {
      const bmi = this.user.bmi;
      if (bmi < 18.5) return 'Underweight';
      if (bmi < 25) return 'Normal weight';
      if (bmi < 30) return 'Overweight';
      return 'Obese';
    },
    bmiCategoryColor() {
      switch (this.bmiCategory) {
        case 'Underweight':
          return 'text-blue-600';
        case 'Normal weight':
          return 'text-green-600';
        case 'Overweight':
          return 'text-yellow-600';
        case 'Obese':
          return 'text-red-600';
        default:
          return 'text-gray-600';
      }
    }
  },
  methods: {
    proceedToDashboard() {
      // TODO: Implement navigation to dashboard
      console.log('Proceeding to dashboard');
    }
  }
}
</script>
