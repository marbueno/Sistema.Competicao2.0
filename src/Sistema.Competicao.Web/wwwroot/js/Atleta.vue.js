
Vue.component('date-picker', VueBootstrapDatetimePicker);

var appAtleta = new Vue({
    el: '#appAtleta',
    data: {
        Codigo: 0,
        Nome: '',
        CPF: '',
        DataNascimento: '',
        Posicao: '',
        Equipe: '',
        PrimeiroQuadro: '',
        SegundoQuadro: '',
        IsentoPagamento: false,
        columns:
            [
                { "data": "codigo" },
                { "data": "nome" },
                { "data": "segundoQuadro" },
                { "data": "primeiroQuadro" },
                {
                    "mDataProp": "Editar",
                    mRender: function (data, type, row) {
                        return "<a href='#' onclick='appAtleta.editRegister(" + row.id + ")' title='Editar'>Editar</a>";
                    }
                },
                {
                    "mDataProp": "Excluir",
                    mRender: function (data, type, row) {
                        return "<a href='#' onclick='appAtleta.deleteRegister(" + row.id + ", false)' title='Excluir'>Excluir</a>";
                    }
                }
            ],

        config: {
            format: 'DD/MM/YYYY',
            useCurrent: false,
            showClear: true,
            showClose: true,
            locale: 'pt-br'
        }
    },

    methods: {

        newRegister: function () {
            this.Codigo = 0;
            this.Nome = '';
            this.CPF = '';
            this.DataNascimento = '';
            this.Posicao = '';
            this.Equipe = '';
            this.PrimeiroQuadro = '';
            this.SegundoQuadro = '';
            this.IsentoPagamento = false;
            appMain.showForm();
        },

        editRegister: function (id) {
            this.Codigo = appLoadData.listAtleta[id].codigo;
            this.Nome = appLoadData.listAtleta[id].nome;
            this.CPF = appLoadData.listAtleta[id].cpf;
            this.DataNascimento = appLoadData.listAtleta[id].dataNascimentoFormatada;
            this.Posicao = appLoadData.listAtleta[id].posicao;
            this.Equipe = appLoadData.listAtleta[id].equipe;
            this.PrimeiroQuadro = appLoadData.listAtleta[id].primeiroQuadro;
            this.SegundoQuadro = appLoadData.listAtleta[id].segundoQuadro;
            this.IsentoPagamento = appLoadData.listAtleta[id].isentoPagamento;
            appMain.showForm();
        },

        deleteRegister: function (id, confirmed) {
            if (confirmed === false) {
                this.Codigo = appLoadData.listAtleta[id].codigo;
                appMain.showModal();
            }
            else {
                appMain.loadingVisible = true;
                fetch('/Cadastros/AtletaRemove/' + this.Codigo, { method: 'delete'})
                    .then(data =>
                    {
                        window.location.href = '/Admin/Cadastros/Atleta';
                    });
            }
        }
    },

    mounted() {

        appMain.formName = '#frmAtleta';
        appLoadData.carregarEquipes();
        appLoadData.carregarPosicao();
        appLoadData.carregarAtletas()
            .then(dataLoaded => {
                if (dataLoaded) {
                    appMain.loadTable('tblAtleta', appLoadData.listAtleta, this.columns);
                }
            });
    }
});