<template>
  <div class="container mt-3">
    <div class="row">
      <div class="col-4">
          <b-button class="mb-2 btn btn-outline-primary" v-b-modal="'employeeForm'">Add new employee</b-button>
          <b-modal id="employeeForm" hide-footer v-if='showModal'>
             <b-form @submit="onFormSubmit" @reset="onReset">
                <b-form-group id="input-group-1" label="Name:" label-for="input-1" description="Name">
                  <b-form-input id="input-1" v-model="employee.name" type="text" required placeholder="Enter name"></b-form-input>
                </b-form-group>

                <b-form-group id="input-group-1" label="Last Name:" label-for="input-1" description="Last Name">
                  <b-form-input id="input-1" v-model="employee.lastName" type="text" required placeholder="Enter lastName"></b-form-input>
                </b-form-group>

                <b-form-group id="input-group-1" label="ExcuseType:" label-for="input-1" description="ExcuseType">
                  <b-form-select id="input-3" v-model="employee.excuseType" :options="excuseTypes" required>
                  </b-form-select>
                </b-form-group>

                <b-button class="float-right" type="submit" variant="primary">Submit</b-button>
              </b-form>
          </b-modal>
      </div>
      <div class="col-12">
          <table class="table table-striped table-bordered">
            <thead>
              <tr>
                <th v-for='column of columns' v-bind:key='column.id' scope="col">{{ column }}</th>
                <th scope="col">Actions</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for='employee of employees' v-bind:key='employee.id'>
                <th scope="row" v-for='column of columns' v-bind:key='column.id'>{{ getElementValue(employee[lowerCaseFirstLetter(column)]) }}</th>
                <th>
                  <b-button variant="outline-success" v-b-modal="'employeeForm'" v-on:click='editEmployee(employee)'>Edit</b-button>
                  <b-button variant="outline-danger" v-on:click='deleteEmployee(employee)'>Delete</b-button>
                </th>
              </tr>
            </tbody>
          </table>
      </div>
    </div>
    <b-alert :show="dismissCountDown" dismissible variant="success" @dismissed="dismissCountDown=0"
      @dismiss-count-down="countDownChanged">
      <p>Employee deleted it</p>
      <b-progress variant="warning" :max="dismissSecs" :value="dismissCountDown" height="4px"></b-progress>
    </b-alert>
  </div>
</template>

<script>
import HttpService from './../services/HttpService.js'

const httpService = new HttpService()

export default {
  name: 'Employees',
  computed: {
  },
  methods: {
    lowerCaseFirstLetter: function (str = '') {
      return str.charAt(0).toLowerCase() + str.slice(1)
    },
    getElementValue: function (element) {
      return element?.description || element
    },
    onFormSubmit: async function (evt) {
      evt.preventDefault()
      console.log(JSON.stringify(this.employee))
      if (!this.isEditing) {
        const result = await httpService.post('employees', this.employee)
        this.employees = [...this.employees, this.employee]
        if (result.success) {
          this.$bvModal.hide('employeeForm')
        } else {
          this.employees = this.employees.pop()
        }
      } else {
        const result = await httpService.put('employees', this.employee)
        if (result.success) {
          const index = this.employees.findIndex(x => x.id === this.employee.id)
          this.employees[index] = this.employee
          this.$bvModal.hide('employeeForm')
        } else {
          //
        }
      }
    },
    onReset: function () {
      this.employee = { id: null, name: '', lastName: '', excuseType: null, date: '' }
      this.isEditing = false
    },
    editEmployee: function (employee) {
      this.employee = employee
      this.isEditing = true
    },
    deleteEmployee: async function (employee) {
      const result = await httpService.delete('employees', employee.id)
      if (result.success) {
        const index = this.employees.findIndex(x => x.id === this.employee.id)
        this.employees.splice(index, 1)
        this.showAlert()
      } else {
        //
      }
    },
    countDownChanged: function (dismissCountDown) {
      this.dismissCountDown = dismissCountDown
    },
    showAlert: function () {
      this.dismissCountDown = this.dismissSecs
    }
  },
  data: function () {
    return {
      showModal: true,
      columns: ['Id', 'Name', 'LastName', 'ExcuseType', 'Date'],
      employees: [],
      employee: { id: undefined, name: '', lastName: '', excuseType: null, date: '' },
      excuseTypes: [ { value: null, text: 'Please select an option' } ],
      isEditing: false,
      dismissSecs: 5,
      dismissCountDown: 0,
      showDismissibleAlert: false
    }
  },
  created: async function () {
    const employeesRequestResult = await httpService.get('employees')
    if (employeesRequestResult.success) {
      this.employees = employeesRequestResult.list
    } else {
      // TODO: Log message
    }

    const excuseTypesRequestResult = await httpService.get('excuseTypes')
    if (excuseTypesRequestResult.success) {
      this.excuseTypes = [ ...this.excuseTypes, ...excuseTypesRequestResult.list.map((x) => {
        return { text: x.description, value: x }
      })]
    } else {
      // TODO: Log message
    }
  }
}
</script>
