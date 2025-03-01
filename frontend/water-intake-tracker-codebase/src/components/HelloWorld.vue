<template>
  <div class="p-6">
    <h1 class="text-2xl font-bold mb-4">Vue CRUD Operations</h1>
    
    <!-- Add New Item -->
    <div class="flex mb-4">
      <input v-model="newItem" placeholder="Enter item name" class="border p-2 flex-1" />
      <button @click="addItem" class="bg-blue-500 text-white px-4 py-2 ml-2 rounded">Add</button>
    </div>

    <!-- Display Items -->
    <ul>
      <li v-for="item in items" :key="item.id" class="mb-2 flex justify-between">
        <span v-if="editingIndex !== item.id">{{ item.name }}</span>
        <input v-else v-model="editedItem" class="border p-1 flex-1" />

        <div>
          <button v-if="editingIndex !== item.id" @click="editItem(item)" class="text-yellow-500 mr-2">Edit</button>
          <button v-if="editingIndex === item.id" @click="saveEdit(item.id)" class="text-green-500 mr-2">Save</button>
          <button @click="deleteItem(item.id)" class="text-red-500">Delete</button>
        </div>
      </li>
    </ul>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      items: [], // Stores fetched data
      newItem: "", // New item input
      editingIndex: null, // Track which item is being edited
      editedItem: "", // Stores edited value
    };
  },
  mounted() {
    this.fetchData(); // Fetch data when component loads
  },
  methods: {
    async fetchData() {
      try {
        const apiUrl = "http://localhost:5003/api/TestApi/GetTestData/";
        const response = await axios.get(apiUrl);
        this.items = response.data.apiResponsedata || [];
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    },
    async addItem() {
      if (this.newItem.trim() === "") return;
      
      // Generate a unique ID based on existing records and a random number
      const newId = this.items.length + Math.floor(Math.random() * 1000) + 1;

      try {
        const apiUrl = "http://localhost:5003/api/TestApi/SaveData";
        
        const response = await axios.post(apiUrl, { id: newId, name: this.newItem });

        if (response.data) {
          alert(2);
          this.items.push(response.data.apiResponsedata);
          this.newItem = "";
        }
      } catch (error) {
        console.error("Error adding item:", error);
      }
    },
    editItem(item) {
      this.editingIndex = item.id;
      this.editedItem = item.name;
    },
    async saveEdit(id) {
      if (this.editedItem.trim() === "") return;

      try {
        const apiUrl = "http://localhost:5003/api/TestApi/UpdateData";
        const response = await axios.put(apiUrl, { id, name: this.editedItem });

        if (response.data) {
          this.items = this.items.map((item) =>
            item.id === id ? { ...item, name: this.editedItem } : item
          );
          this.editingIndex = null;
          this.editedItem = "";
        }
      } catch (error) {
        console.error("Error updating item:", error);
      }
    },
    async deleteItem(id) {
      try {
        const apiUrl = `http://localhost:5003/api/TestApi/DeleteData/${id}`;
        await axios.delete(apiUrl);

        this.items = this.items.filter((item) => item.id !== id);
      } catch (error) {
        console.error("Error deleting item:", error);
      }
    },
  },
};
</script>