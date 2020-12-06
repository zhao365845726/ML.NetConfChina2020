
new Vue({
    el: "#app",
    data() {
        var validateCode = (rule, value, callback) => {
            callback();
        };
        return {
            defaultMSG: null,
            editorData: '',
            form:
            {
                content: ''
            },
            config:
            {
                initialFrameHeight: 500
            },
            //分页参数
            paginationQuery:
            {
                total: 5
            },
            //分页接口传参
            listQuery: {
                pageIndex: 1,
                pageSize: 20,
                keyword: '',
                orderField: ''
            },
            categoryData: [],
            keyword: '',
            multipleSelection: '',
            radio: '',
            props: { multiple: true },
            // 表格数据
            tableData: [],
            uid: '',
            fileList: [],
            dialogImageUrl: '',
            dialogVisible: false,
            dialog:
            {
                title: '新增用户',
                visible: false,
                data:
                {
                    id: '', nickName: '', account: '', password: '', name: '', gender: '', balance: 0
                },
                rules:
                {
                    name:
                        [
                            { required: true, message: "用户名称为必填项", trigger: "blur" }
                        ]
                },
                updateLoading: false,
                disabled: false,
                checkStrictly: true // 是否严格的遵守父子节点不互相关联
            }
        }
    },
    created: function () {
        let that = this
        that.getList();
    },
    watch:
    {
        'dialog.visible': function (val, old) {
            // 关闭dialog，清空
            if (!val) {
                this.dialog.data = {
                    id: '', nickName: '', account: '', password: '', name: '', gender: '', balance: 0
                };
                this.dialog.updateLoading = false;
                this.dialog.disabled = false;
            }
        }
    },
    methods:
    {
        handleRemove(file, fileList) {
            log(file, fileList, 2);
        },
        handlePictureCardPreview(file) {
            let that = this
            that.dialogImageUrl = file.url;
            that.dialogVisible = true;
        },
        uploadSuccess(res, file, fileList) {
            let that = this
            // 上传成功
            that.fileList = fileList;
            log('上传成功', fileList.length, 2);
            log('res', res, 2);

            if (res.code == 200) {
                that.$notify({
                    title: '成功',
                    message: '恭喜你，上传成功',
                    type: 'success'
                });
                that.dialog.data.cover = res.data;
            }
            else {
                that.$notify.error({
                    title: '失败',
                    message: '上传失败，请重新上传'
                });
            }
        },
        uploadError() {
            let that = this
            //that.refs.upload.clearFiles();
            that.$notify.error({
                title: '失败',
                message: '上传失败，请重新上传'
            });
        },
        // 获取所有用户
        async getList() {
            let that = this
            //that.uid = resizeUrl().uid
            let { pageIndex, pageSize, keyword, orderField } = that.listQuery;
            log('orderField', orderField, 1);
            if (orderField == '' || orderField == undefined) {
                orderField = 'AddTime Desc';
            }
            if (that.keyword != '' && that.keyword != undefined) {
                keyword = that.keyword;
            }

            await service.get(`/Admin/User/Index?handler=User&pageIndex=${pageIndex}&pageSize=${pageSize}&keyword=${keyword}&orderField=${orderField}`).then(res => {
                that.tableData = res.data.data.list;
                that.paginationQuery.total = res.data.data.totalCount;
            });
        },
        async getCategoryList() {
            let that = this
            //获取分类列表数据
            await service.get('/Admin/Products/Index?handler=ProductsCategory').then(res => {
                that.categoryData = res.data.data.list;
                log('categoryData', res, 2);
            });
        },
        // 编辑 // 新增用户 // 增加下一级
        handleEdit(index, row, flag) {
            let that = this
            that.dialog.visible = true;
            if (flag === 'add') {
                // 新增
                that.dialog.title = '新增用户';
                that.dialogImageUrl = '';
                return;
            }
            // 编辑
            let { id, nickName, account, password, name, gender, balance } = row;
            that.dialog.data = {
                id, nickName, account, password, name, gender, balance
            };
            //if (cover != '' && cover != undefined)
            //{
            //    that.dialogImageUrl = cover;
            //}
            //if (body != '' && body != undefined)
            //{
            //    that.editorData = this.$refs['bodyEditor'].editor.setData(body);
            //}
            //if (that.editorData == '')
            //{
            //    that.editorData = this.$refs['bodyEditor'].editor.setData(body);
            //}

            if (flag === 'edit') {
                that.dialog.title = '编辑用户';
            }
        },
        // 更新新增、编辑
        updateData() {
            let that = this
            that.dialog.updateLoading = true;
            that.$refs['dataForm'].validate(valid => {
                // 表单校验
                if (valid) {
                    that.dialog.updateLoading = true;
                    let data = {
                        Id: that.dialog.data.id,
                        NickName: that.dialog.data.nickName,
                        Account: that.dialog.data.account,
                        Password: that.dialog.data.password,
                        Name: that.dialog.data.name,
                        Gender: that.dialog.data.gender,
                        Balance: parseFloat(that.dialog.data.balance)
                    };
                    console.log('add-' + JSON.stringify(data));
                    service.post("/Admin/User/Edit?handler=Save", data).then(res => {
                        if (res.data.success) {
                            that.getList();
                            that.$notify({
                                title: "Success",
                                message: "成功",
                                type: "success",
                                duration: 2000
                            });
                            that.dialog.visible = false;
                        }
                    });
                }
            });
        },
        // 删除
        handleDelete(index, row) {
            let that = this
            let ids = [row.id];
            service.post("/Admin/User/edit?handler=Delete", ids).then(res => {
                if (res.data.success) {
                    that.getList();
                    that.$notify({
                        title: "Success",
                        message: "删除成功",
                        type: "success",
                        duration: 2000
                    });
                }
            });
        },
        handleSelectionChange(val) {
            let that = this
            that.multipleSelection = val;
            console.log(`that.multipleSelection----${JSON.stringify(that.multipleSelection)}`);
            if (that.multipleSelection.length == 1) {
                //that.newsId = that.multipleSelection[0].id;
                //that.dialogVote.data.newsId = that.multipleSelection[0].id;
                //console.log(`that.newsId----${that.newsId}`);
            }
        },
        getCurrentRow(row) {
            let that = this
            //获取选中数据
            //that.templateSelection = row;
            that.multipleSelection = row;
            log('multipleSelection', row, 2)
            //that.newsId = that.multipleSelection.id;
            //that.dialogVote.data.newsId = that.multipleSelection.id;
        },
        handleSearch() {
            let that = this
            that.getList();
        },
        resetCondition() {
            let that = this
            that.keyword = '';
        },
        setRecommendFormat(row, column, cellValue, index) {
            if (cellValue) {
                return "Y";
            }
            return "N";
        },
        setBodyFormat(row, column, cellValue, index) {
            if (cellValue == undefined) {
                return '-';
            }
            else {
                return cellValue.substring(0, 16);
            }
        },
        setContentFormat(row, column, cellValue, index) {
            if (cellValue == undefined) {
                return '-';
            }
            else {
                return cellValue.replace(/<[^>]+>/gim, '').replace(/\[(\w+)[^\]]*](.*?)\[\/\1]/g, '$2 ').substring(0, 16);
            }
        }
    }
}); 