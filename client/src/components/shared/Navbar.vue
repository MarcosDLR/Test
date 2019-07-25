<template>
<nav class="navbar navbar-expand-lg navbar-light bg-light">


  <div class="collapse navbar-collapse" id="navbarSupportedContent">
    <ul class="navbar-nav ml-auto ">
      <li class="nav-item">
        <a class="nav-link" v-if="loggin" href="/#/ListaUsuarios">Usuarios</a>
      </li>
       <li class="nav-item active">
        <el-button @click="logout" v-if="loggin" type="primary">Logout</el-button>
      </li>
       <li class="nav-item active">
        <el-button @click="SinUp" v-if="!loggin" type="success">SingUp</el-button>
      </li>
    </ul>

  </div>
</nav>
</template>

<script>
export default {
  name: "Navbar",
  data() {
    return {

    };
  },
  computed: {
      loggin() {
      let logeado = true;
        if(localStorage.getItem('Access')){
            logeado = true;
        }else{
            logeado = false;
        }
          return logeado;
      }
  },
  methods: {
      logout(){
        let self = this;
          localStorage.removeItem('Access');
        if(localStorage.getItem('Access')){
            console.log('Logeado');
        }else{
           self.$router.push('/Login');
        }
      },
        SinUp(){
      this.$router.push('/SingUp');
  } 
  }
};
</script>