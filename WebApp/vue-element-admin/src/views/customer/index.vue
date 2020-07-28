<template>
<div class="app-container">
    <div class="head-container">
        <!-- 搜索 -->
        <el-input v-model="listQuery.Filter" clearable size="small" placeholder="搜索..." style="width: 200px;" class="filter-item" @keyup.enter.native="handleFilter" />
        <el-button class="filter-item" size="mini" type="success" icon="el-icon-search" @click="handleFilter">搜索</el-button>
        <div style="padding: 6px 0;">
            <el-button class="filter-item" size="mini" type="primary" icon="el-icon-plus" @click="handleCreate" v-permission="['AbpIdentity.Users.Create']">新增</el-button>
            <el-button class="filter-item" size="mini" type="success" icon="el-icon-edit" v-permission="['AbpIdentity.Users.Update']" @click="handleUpdate()">修改</el-button>
            <el-button slot="reference" class="filter-item" type="danger" icon="el-icon-delete" size="mini" v-permission="['AbpIdentity.Users.Delete']" @click="handleDelete()">删除</el-button>
        </div>
    </div>
    <el-dialog :visible.sync="dialogFormVisible" :close-on-click-modal="false" :title="formTitle" @close="cancel()" width="500px">
        <el-form ref="form" :inline="true" :model="form" :rules="rules" size="small" label-width="66px">
            <el-form-item label="名称" prop="name">
                <el-input v-model="form.name" style="width: 370px;" />
            </el-form-item>
            <el-form-item label="等级" prop="customerLevelId">
                <el-input v-model="form.customerLevelName" readonly placeholder="请选择" style="width: 370px">
                    <el-button slot="append" icon="el-icon-search" @click="handleSelectCustomerLevle()"></el-button>
                </el-input>
            </el-form-item>
            <el-form-item label="地址" prop="address">
                <el-input v-model="form.address" style="width: 370px;" />
            </el-form-item>

            <el-form-item label="联系人" prop="contact">
                <el-input v-model="form.contact" style="width: 370px;" />
            </el-form-item>

            <el-form-item label="电话" prop="phone">
                <el-input v-model="form.phone" style="width: 370px;" />
            </el-form-item>

            <el-form-item label="备注">
                <el-input type="textarea" v-model="form.remark" style="width: 370px;" />
            </el-form-item>

        </el-form>
        <div slot="footer" class="dialog-footer">
            <el-button size="small" type="text" @click="cancel">取消</el-button>
            <el-button size="small" v-loading="formLoading" type="primary" @click="save">确认</el-button>
        </div>

    </el-dialog>

    <el-dialog title="选择客户等级" width="600px" top="5vh" :close-on-click-modal="false" :visible.sync="customerLevelDialogTableVisible">
        <div class="filter-container">
            <el-input size="small" v-model="customerLevelListQuery.Filter" placeholder="搜索..." style="width: 200px;" class="filter-item" @keyup.enter.native="customerLevelHandleFilter" />
            <el-button size="mini" class="filter-item" type="primary" icon="el-icon-search" @click="customerLevelHandleFilter">搜索</el-button>
        </div>

        <el-table v-loading="customerLevelListLoading" :data="customerLevelList" height="300" @row-click="customerLevelHandleRowClick">
            <el-table-column label="标签" prop="label" align="center" width="150px">
                <template slot-scope="{row}">
                    <span class="link-type">{{row.label}}</span>
                </template>
            </el-table-column>
            <el-table-column label="值" align="center" width="200px">
                <template slot-scope="scope">
                    <span>{{scope.row.value}}</span>
                </template>
            </el-table-column>
        </el-table>
        <el-pagination small layout="prev, pager, next" :total="totalCount" :page.sync="page" :limit.sync="customerLevelListQuery.MaxResultCount" @pagination="getCustomerLevelList"></el-pagination>
    </el-dialog>
    <el-table ref="multipleTable" v-loading="listLoading" :data="list" size="small" style="width: 90%;" @sort-change="sortChange" @selection-change="handleSelectionChange" @row-click="handleRowClick">
        <el-table-column type="selection" width="44px"></el-table-column>
        <el-table-column label="客户名称" prop="name" sortable="custom" align="center" width="150px">
            <template slot-scope="{row}">
                <span class="link-type" @click="handleUpdate(row)">{{row.name}}</span>
            </template>
        </el-table-column>
        <el-table-column label="客户等级" prop="customerLevelName" align="center">
            <template slot-scope="scope">
                <span>{{scope.row.customerLevelName}}</span>
            </template>
        </el-table-column>
        <el-table-column label="地址" prop="address" align="center">
            <template slot-scope="scope">
                <span>{{scope.row.address}}</span>
            </template>
        </el-table-column>
        <el-table-column label="联系人" prop="contact" align="center">
            <template slot-scope="scope">
                <span>{{scope.row.contact}}</span>
            </template>
        </el-table-column>
        <el-table-column label="联系电话" prop="phone" align="center">
            <template slot-scope="scope">
                <span>{{scope.row.phone}}</span>
            </template>
        </el-table-column>

        <el-table-column label="操作" align="center">
            <template slot-scope="{row}">
                <el-button type="primary" size="mini" @click="handleUpdate(row)" v-permission="['Business.Customers.Update']" icon="el-icon-edit" />
                <el-button type="danger" size="mini" @click="handleDelete(row)" :disabled="row.userName==='admin'" v-permission="['Business.Customers.Delete']" icon="el-icon-delete" />
            </template>
        </el-table-column>
    </el-table>

    <pagination v-show="totalCount>0" :total="totalCount" :page.sync="page" :limit.sync="listQuery.MaxResultCount" @pagination="getList" />
</div>
</template>

<script>
import Pagination from '@/components/Pagination'
import permission from '@/directive/permission/index.js'

import Qs from 'qs'

const defaultForm = {
    id: null,
    name: null,
    customerLevelId: null,
    customerLevelName: null,
    address: null,
    contact: null,
    phone: null,
    remark: null,

}
export default {
    name: 'Customer',
    components: {
        Pagination
    },
    directives: {
        permission
    },
    data() {
        return {
            rules: {
                name: [{
                    required: true,
                    message: "请输入客户姓名",
                    trigger: "blur"
                }]

            },

            form: Object.assign({}, defaultForm),
            //   form: Object.assign({}, defaultForm),
            // form: {},
            list: null,
            totalCount: 0,
            listLoading: true,
            customerLevelListLoading: true,
            customerLevelList: null,
            formLoading: false,
            listQuery: {
                Filter: '',
                Sorting: '',
                SkipCount: 0,
                MaxResultCount: 10
            },

            customerLevelListQuery: {

                Pid: "0F7477F1-E696-6A7D-3351-39F6A565AC0A",
                Filter: '',
                Sorting: '',
                SkipCount: 0,
                MaxResultCount: 10
            },
            page: 1,
            dialogFormVisible: false,
            customerLevelDialogTableVisible: false,
            multipleSelection: [],
            formTitle: '',
            isEdit: false
        }
    },
    created() {
        this.getList()
    },
    methods: {
        getList() {
            this.listLoading = true
            this.listQuery.SkipCount = (this.page - 1) * 10
            this.$axios
                .gets('/api/business/customer/all', this.listQuery)
                .then(response => {
                    this.list = response.items
                    this.totalCount = response.totalCount
                    this.listLoading = false
                })
        },
        fetchData(id) {
            this.$axios.gets('/api/business/customer/' + id).then(response => {
                this.form = response
            })
        },

        getCustomerLevelList() {
            this.customerLevelListLoading = true;
            this.customerLevelListQuery.SkipCount = (this.page - 1) * 10;
            this.$axios.gets("/api/business/dictDetails/all", this.customerLevelListQuery).then(response => {
                this.customerLevelList = response.items;
                this.customerLevelTotalCount = response.totalCount;
                this.customerLevelListLoading = false;
            });
        },
        getCustomerLevel(id) {
            this.$axios.gets("/api/business/dictDetails/" + id).then(response => {
                this.form.customerLevelName = response.Lable;
            });
        },
        customerLevelHandleFilter() {
            this.page = 1;
            this.getCustomerLevelList();
        },
        handleFilter() {
            this.page = 1;
            this.getList();
        },
        handleSelectCustomerLevle() {
            this.customerLevelListQuery.Filter = "";
            this.customerLevelDialogTableVisible = true;
            this.getCustomerLevelList();
        },

        customerLevelHandleRowClick(row, column, event) {
            this.customerLevelDialogTableVisible = false;
            this.form.customerLevelId = row.id;
            this.form.customerLevelName = row.value;
        },

        resetQuery() {},
        save() {
            this.$refs.form.validate(valid => {
                if (valid) {
                    this.formLoading = true
                    this.form.roleNames = this.checkedRole
                    if (this.isEdit) {
                        this.$axios
                            .puts('/api/business/customer/' + this.form.id, this.form)
                            .then(response => {
                                this.formLoading = false
                                this.$notify({
                                    title: '成功',
                                    message: '更新成功',
                                    type: 'success',
                                    duration: 2000
                                })
                                this.dialogFormVisible = false
                                this.getList()
                            })
                            .catch(() => {
                                this.formLoading = false
                            })
                    } else {

                        //alert(this.form.customerLevelName);
                        //alert( this.form.customerLevelId +this.form.customerLevelName +this.form.name);

                        this.$axios
                            .posts('/api/business/customer', this.form)
                            .then(response => {
                                this.formLoading = false
                                this.$notify({
                                    title: '成功',
                                    message: '新增成功',
                                    type: 'success',
                                    duration: 2000
                                })
                                this.dialogFormVisible = false
                                this.getList()
                            })
                            .catch((a) => {
                                alert(a.message);
                                this.formLoading = false
                            })
                    }
                }
            })
        },
        handleCreate() {
            this.formTitle = '新增客户'
            this.isEdit = false
            this.dialogFormVisible = true
        },
        handleDelete(row) {
            var params = []
            let alert = ''
            if (row) {
                params.push(row.id)
                alert = row.name

            } else {
                if (this.multipleSelection.length === 0) {
                    this.$message({
                        message: '未选择',
                        type: 'warning'
                    })
                    return
                }
                this.multipleSelection.forEach(element => {
                    let id = element.id
                    params.push(id)
                })
                alert = '选中项'
            }
            this.$confirm('是否删除' + alert + '?', '提示', {
                    confirmButtonText: '确定',
                    cancelButtonText: '取消',
                    type: 'warning'
                })
                .then(() => {
                
                    this.$axios
                        // .posts('/api/business/customer/delete',this.Qs.stringify( params))
                        .posts('/api/business/customer/delete', params)
                        .then(response => {
                            this.$notify({
                                title: '成功',
                                message: '删除成功',
                                type: 'success',
                                duration: 2000
                            })
                            this.getList()
                        })
                })
                .catch(() => {
                    this.$message({
                        type: 'info',
                        message: '已取消删除'
                    })
                })
        },
        handleUpdate(row) {
            this.formTitle = '修改客户'
            this.isEdit = true
            if (row) {
                this.fetchData(row.id)
                this.dialogFormVisible = true
            } else {
                if (this.multipleSelection.length != 1) {
                    this.$message({
                        message: '编辑必须选择单行',
                        type: 'warning'
                    })
                    return
                } else {
                    this.fetchData(this.multipleSelection[0].id)
                    this.dialogFormVisible = true
                }
            }
        },
        sortChange(data) {
            const {
                prop,
                order
            } = data
            if (!prop || !order) {
                this.handleFilter()
                return
            }
            this.listQuery.Sorting = prop + ' ' + order
            this.handleFilter()
        },
        handleSelectionChange(val) {
            this.multipleSelection = val
        },
        handleRowClick(row, column, event) {
            this.$refs.multipleTable.clearSelection()
            this.$refs.multipleTable.toggleRowSelection(row)
        },
        cancel() {
            this.form = Object.assign({}, defaultForm)
            this.dialogFormVisible = false
            this.$refs.form.clearValidate()
        }
        // changeEnabled(data, val) {
        //   data.active = val ? "启用" : "停用";
        //   this.$confirm("是否" + data.active + data.name + "？", "提示", {
        //     confirmButtonText: "确定",
        //     cancelButtonText: "取消",
        //     type: "warning"
        //   })
        //     .then(() => {
        //       this.$axios
        //         .puts("/api/business/customer/" + data.id, data)
        //         .then(response => {
        //           this.$notify({
        //             title: "成功",
        //             message: "更新成功",
        //             type: "success",
        //             duration: 2000
        //           });
        //         })
        //         .catch(() => {
        //           data.enabled = !data.enabled;
        //         });
        //     })
        //     .catch(() => {
        //       data.enabled = !data.enabled;
        //     });
        // }
    }
}
</script>
