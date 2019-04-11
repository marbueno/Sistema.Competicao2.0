var appPerfil = new Vue({
    el: '#appPerfil',
    data: {
        Codigo: 0,
        Nome: '',
        listPerfil: [],
        columns:
            [
                { "data": "codigo" },
                { "data": "nome" },
                {
                    "mDataProp": "Editar",
                    mRender: function (data, type, row) {
                        return "<a href='#' onclick='appPerfil.edit(" + row.id + ")' title='Editar'>Editar</a>";
                    }
                },
                {
                    "mDataProp": "Excluir",
                    mRender: function (data, type, row) {
                        return "<a href='#' onclick='appPerfil.delete(" + row.id + ")' title='Excluir'>Excluir</a>";
                    }
                }
            ]
    },

    methods: {

        newRegister: function () {
            this.Codigo = 0;
            this.Nome = '';
            appMain.showForm();
        },

        edit: function (id) {
            this.Codigo = this.listPerfil[id].codigo;
            this.Nome = this.listPerfil[id].nome;
            appMain.showForm();
        }
    },

    mounted() {

        appMain.formName = '#frmPerfil';
        fetch('/Account/ListPerfil')
            .then(res => res.json())
            .then(data => {
                var iCount = 0;
                data.forEach(item => { item.id = iCount; this.listPerfil.push(item); iCount++; });
                appMain.loadTable('tblPerfil', this.listPerfil, this.columns);
            });
    }
});