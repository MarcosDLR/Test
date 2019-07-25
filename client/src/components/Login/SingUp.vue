<template>
  <div>
  <Navbar></Navbar>

  <h3 >Sing up</h3>


<div>
<el-form :model="data" >
  <el-form-item label="Nombre">
    <el-input v-model="data.Nombre" type="text"></el-input>
  </el-form-item>
   <el-form-item label="Apellido">
    <el-input v-model="data.Apellido" type="text"></el-input>
  </el-form-item>
   <el-form-item label="Direccion">
    <el-input v-model="data.Direccion" type="text"></el-input>
  </el-form-item>
   <el-form-item label="Telefono">
    <el-input v-model="data.Telefono" type="text"></el-input>
  </el-form-item>
   <el-form-item label="Usuario">
    <el-input v-model="data.Usuario" type="text"></el-input>
  </el-form-item>
   <el-form-item label="Password">
    <el-input v-model="data.Password" type="text"></el-input>
  </el-form-item>
  <br>
  <br>
  <el-form-item>
    <el-button type="primary" @click="create">Submit</el-button>
  </el-form-item>
</el-form>
</div>

  </div>
</template>

<script>
import Navbar from '@/components/shared/Navbar'

export default {
  name: 'SingUp',
  components: {
      Navbar
  }
  ,
  data() {
      return {
          tableData: [],
          data: {
              id: '',
              Nombre: '',
              Apellido: '',
              Direccion: '',
              Telefono: '',
              Usuario: '',
              Password: '',
              idRole: 2
          }
      };
  },
  methods: {
     create(){
        let self = this;
        self.$store.state.services.UsuarioService
        .save(self.data)
        .then(r => {
            console.log("saved");
        })
        .catch(r =>{
            console.log("Error");
        })
     }
  }
}
</script>