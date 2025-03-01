# Fitness Tracker

This project consists of a .NET backend and a Vue.js frontend for tracking fitness activities and goals.

## Features

- User registration and authentication
- Dashboard with fitness goals and activity tracking
- Responsive design with light and dark themes

## Setup and Running the Application

### Backend (.NET)

1. Navigate to the backend directory:
   ```
   cd backend/WaterIntakeTracker
   ```

2. Restore the .NET packages:
   ```
   dotnet restore
   ```

3. Run the backend server:
   ```
   dotnet run
   ```

The backend server will start running on `http://localhost:5004`.

### Frontend (Vue.js)

1. Navigate to the frontend directory:
   ```
   cd frontend/water-intake-tracker-codebase
   ```

2. Install the dependencies:
   ```
   npm install
   ```

3. Run the frontend development server:
   ```
   npm run serve
   ```

The frontend development server will start, typically on `http://localhost:8080`.

## Testing the Application

1. Open your web browser and go to `http://localhost:8080`.
2. You should see the login page. Click on the "Register" link to create a new account.
3. Fill in the registration form with the following details:
   - Name
   - Username
   - Email
   - Password
   - Age
   - Weight (in kg)
   - Height (in cm)
4. Submit the registration form. You should be redirected to the confirmation page.
5. On the confirmation page, you'll see:
   - A success message
   - Your name
   - Your username
   - Your email
   - Your calculated BMI
6. Click on "Continue to Dashboard" to go to the dashboard page.
7. On the dashboard, you can view and interact with your fitness goals and activity tracking (to be implemented).
8. You can log out and log back in using your credentials.

## Customization

- The color scheme can be customized by modifying the `colorPalette.js` file in the `frontend/water-intake-tracker-codebase/src/assets/` directory.
- Tailwind CSS classes are used for styling. You can adjust the design by modifying the Tailwind classes in the Vue components.

## Notes

- Make sure both the backend and frontend servers are running simultaneously for the application to work properly.
- The backend API is configured to run on `http://localhost:5004`. If you change this, make sure to update the `axios.defaults.baseURL` in `frontend/water-intake-tracker-codebase/src/main.js`.
- The application uses responsive design and should work well on both desktop and mobile devices.
- A dark mode toggle is available in the application header for user preference.

## Troubleshooting

If you encounter any issues during registration or login:
1. Check the browser console for any error messages.
2. Ensure that the backend server is running and accessible.
3. Verify that the frontend is correctly configured to communicate with the backend (check the API URL in `main.js`).
4. If the problem persists, check the backend logs for any server-side errors.
