<template>
  <div>
  <Navbar></Navbar>
  <center>
  <h3>Login</h3>
    <div class="wrapper fadeInDown">

    <form>
      <input type="text" class="fadeIn second" name="login" placeholder="Username">
      <input type="text" class="fadeIn third" name="login" placeholder="Password">
        <el-button @click="Login" type="primary">Login</el-button>
    </form>

  </div>
</center>
  </div>
</template>

<script>
import Navbar from '@/components/shared/Navbar'

export default {
  name: 'Login',
  components: {
      Navbar
  }
  ,
  data() {
      return {
          username: '',
          password: ''
      };
  },
  methods: {
    Login(){

        let vari = 'logeado';
        localStorage.setItem('Access',vari);
        if(localStorage.getItem('Access')){
            console.log('Logeado');
            this.$router.push('/ListaUsuarios');
        }else{
            console.log('no logeado');
        }
    }
  }
}
</script>