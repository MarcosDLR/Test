<template>
  <div>
  <Navbar></Navbar>
<div class="conteiner">
  <h3 v-if="titulo">Crear Usuario</h3>
  <h3 v-if="!titulo">Actualizar Usuario</h3>
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
  <label>Role</label>
  <select v-model="data.idRole" class="browser-default custom-select">
    <option value="1">Administrador</option>
    <option value="2">Usuario</option>
    <option value="3">Visitante</option>
  </select>
  <br>
  <br>
  <el-form-item>
    <el-button type="primary" v-if="updateOrcreate" @click="create">Submit</el-button>
    <el-button type="info" v-if="!updateOrcreate" @click="update">Submit</el-button>
  </el-form-item>
</el-form>
</div>
</div>
  </div>
</template>

<script>
import Navbar from '@/components/shared/Navbar'

export default {
  name: 'CreateOrUpdate',
  components: {
      Navbar
  }
  ,
  data() {
      return {
          tableData: [],
          titulo: true,
          data: {
              id: '',
              Nombre: '',
              Apellido: '',
              Direccion: '',
              Telefono: '',
              Usuario: '',
              Password: '',
              idRole: ''
          },
          updateOrcreate: true
      };
  },
created(){
    let aqui = this;
    console.log(aqui.$route.params.id);
this.title(aqui.$route.params.id);
},
  methods: {
     title(id){
      if(id > 0){
       this.titulo = false;
       this.updateOrcreate = false;
       getOne(id);
      }else{
       this.titulo = true;
      }
     },
     getOne(id){
        let self = this;
        self.$store.state.services.UsuarioService
        .getOne(id)
        .then(r => {
            this.data.Nombre = r.data.Nombre;
            this.data.Apellido = r.data.Apellido;
            this.data.Direccion = r.data.Direccion;
            this.data.Telefono = r.data.Telefono;
            this.data.Usuario = r.data.Usuario;
            this.data.Password = r.data.Password;
            this.data.idRole = r.data.idRole;
        })
        .catch( r =>{
            console.log("Error");
        })
     },
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
     },
     update(){
   let self = this;
        self.$store.state.services.UsuarioService
        .put(self.data)
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