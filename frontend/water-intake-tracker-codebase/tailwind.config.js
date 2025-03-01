const { lightTheme, darkTheme } = require('./src/assets/colorPalette.js');

module.exports = {
  purge: ['./index.html', './src/**/*.{vue,js,ts,jsx,tsx}'],
  darkMode: 'class',
  theme: {
    extend: {
      colors: {
        light: {
          primary: lightTheme.primary,
          secondary: lightTheme.secondary,
          background: lightTheme.background,
          text: lightTheme.text,
          accent1: lightTheme.accent1,
          accent2: lightTheme.accent2,
          success: lightTheme.success,
          error: lightTheme.error,
          warning: lightTheme.warning,
          info: lightTheme.info,
        },
        dark: {
          primary: darkTheme.primary,
          secondary: darkTheme.secondary,
          background: darkTheme.background,
          text: darkTheme.text,
          accent1: darkTheme.accent1,
          accent2: darkTheme.accent2,
          success: darkTheme.success,
          error: darkTheme.error,
          warning: darkTheme.warning,
          info: darkTheme.info,
        },
      },
    },
  },
  variants: {
    extend: {},
  },
  plugins: [],
}
