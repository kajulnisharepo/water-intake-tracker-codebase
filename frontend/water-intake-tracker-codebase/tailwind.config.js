module.exports = {
  purge: ['./index.html', './src/**/*.{vue,js,ts,jsx,tsx}'],
  darkMode: 'class',
  theme: {
    extend: {
      backgroundColor: {
        'dark': '#1a202c',
        'light': '#f7fafc',
      },
      textColor: {
        'dark': '#f7fafc',
        'light': '#1a202c',
      },
    },
  },
  variants: {
    extend: {},
  },
  plugins: [],
}
