<template>
<el-container>
  <el-header>

  </el-header>
  <el-container>
    <el-aside style="width:240px;">
      <navegationmenu></navegationmenu>
    </el-aside>
    <el-container>
      <el-main>
        <el-row>
          <el-col :span="24">
            <router-view></router-view>
          </el-col>
        </el-row>
      </el-main>
      <el-footer> </el-footer>
    </el-container>
  </el-container>
</el-container>
</template>

<script>
import navegationmenu from "@/components/shared/NavegationMenu";

export default {
  components: {
    navegationmenu
  },
  props: {
    source: String
  }
};
</script>