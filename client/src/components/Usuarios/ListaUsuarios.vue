<template>
  <div>
  <Navbar></Navbar>
<div class="conteiner">
  <h3>Usuarios</h3>
    <el-button type="primary" @click="create">Create</el-button>
<el-table
      :data="tableData"
      style="width: 100%">
      <el-table-column
        prop="Nombre"
        label="Nombre"
        width="180">
      </el-table-column>
      <el-table-column
        prop="Apellido"
        label="Apellido"
        width="180">
      </el-table-column>
      <el-table-column
        prop="Direccion"
        label="Dirección">
      </el-table-column>
       <el-table-column
        prop="Telefono"
        label="Telefono"
        width="180">
      </el-table-column>
      <el-table-column
        prop="Usuario"
        label="Usuario"
        width="180">
      </el-table-column>
      <el-table-column
        prop="Role"
        label="Role">
      </el-table-column>

    </el-table>

</div>
  </div>
</template>

<script>
import Navbar from '@/components/shared/Navbar'

export default {
  name: 'ListaUsuarios',
  components: {
      Navbar
  }
  ,
  data() {
      return {
          tableData: []
      };
  },
  created(){
    this.list();
  },
  methods: {
    list(){
      this.$store.state.services.UsuarioService
      .getAll()
      .then( r => {
        tableData = r.data;
      })
      .catch()


    },
    create(){
      this.$router.push('CreateOrUpdate');
    }
  }
}
</script>