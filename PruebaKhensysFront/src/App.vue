<template>
  <div id="app">
    <app-navbar />
    <router-view/>
  </div>
</template>

<script>
import AppNavbar from './components/shared/AppNavbar.vue'

export default {

  name: 'App',
  components: {
    AppNavbar
  }
}
</script>
