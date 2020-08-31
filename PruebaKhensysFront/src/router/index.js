import Vue from 'vue'
import Router from 'vue-router'
import Employees from '@/components/Employees'
import Roles from '@/components/Roles'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'employees',
      component: Employees
    },
    {
      path: '/roles',
      name: 'roles',
      component: Roles
    }
  ]
})
