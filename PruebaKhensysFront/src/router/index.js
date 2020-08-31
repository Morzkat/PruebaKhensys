import Vue from 'vue'
import Router from 'vue-router'
import Employees from '@/components/Employees'
import ExcuseTypes from '@/components/ExcuseTypes'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'employees',
      component: Employees
    },
    {
      path: '/excuseTypes',
      name: 'excuseTypes',
      component: ExcuseTypes
    }
  ]
})
