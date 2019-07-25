import Vue from 'vue'
import Router from 'vue-router'

import Default from '@/components/Default'
import ExampleIndex from '@/components/example/Index'
import ExampleView from '@/components/example/View'
import Login from '@/components/Login/Login'
import ListaUsuarios from '@/components/Usuarios/ListaUsuarios'
import CreateOrUpdate from '@/components/Usuarios/CreateOrUpdate'
import SingUp from '@/components/Login/SingUp'
import Visitantes from '@/components/Visitantes/Visitantes'
Vue.use(Router)

const ifNotAuthenticated = (to, from, next) => {
  if (!localStorage.getItem('Access')) {
    next()
    return
  }
  next('/ListaUsuarios')
}

const ifAuthenticated = (to, from, next) => {
  if (localStorage.getItem('Access')) {
    next()
    return
  }
  next('/Login')
}


const routes = [
  { path: '/', name: 'Default', component: Default },
  { path: '/example', name: 'ExampleIndex', component: ExampleIndex },
  { path: '/example/:id', name: 'ExampleView', component: ExampleView },
  { path: '/Login', name: 'Login', component: Login, beforeEnter: ifNotAuthenticated },
  { path: '/ListaUsuarios', name: 'ListaUsuarios', component: ListaUsuarios, beforeEnter: ifAuthenticated },
  { path: '/CreateOrUpdate', name: 'CreateOrUpdate', component: CreateOrUpdate, beforeEnter: ifAuthenticated},
  { path: '/CreateOrUpdate/:id', name: 'CreateOrUpdate', component: CreateOrUpdate, beforeEnter: ifAuthenticated },
  { path: '/SingUp', name: 'SingUp', component: SingUp, beforeEnter: ifNotAuthenticated },
  { path: '/Visitantes', name: 'Visitantes', component: Visitantes, beforeEnter: ifAuthenticated }
]

export default new Router({
  routes
})
