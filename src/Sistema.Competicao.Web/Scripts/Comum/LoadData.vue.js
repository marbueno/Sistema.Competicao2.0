var appLoadData = new Vue({
    data: {
        parametros: {},
        listPerfil: [],
        listTipoDespesaReceita: [],
        listAdversario: [],
        listQuadra: [],
        listEquipe: [],
        listPosicao: []
    },
    methods: {

        carregarParametros: function () {

            return new Promise((resolve) => {

                fetch('/Administracao/ListParametros')
                    .then(res => res.json())
                    .then(data => {
                        this.parametros = data;
                        resolve(true);
                    });
            });
        },

        carregarPerfis: function () {

            return new Promise((resolve) => {

                fetch('/Account/ListPerfil')
                    .then(res => res.json())
                    .then(data => {
                        var iCount = 0;
                        data.forEach(item => { item.id = iCount; this.listPerfil.push(item); iCount++; });
                        resolve(true);
                    });
            });
        },

        carregarTipoDespesaReceita: function () {

            return new Promise((resolve) => {

                fetch('/Controles/ListTipoDespesaReceita')
                    .then(res => res.json())
                    .then(data => {
                        var iCount = 0;
                        data.forEach(item => { item.id = iCount; this.listTipoDespesaReceita.push(item); iCount++; });
                        resolve(true);
                    });
            });
        },

        carregarAdversarios: function () {

            return new Promise((resolve) => {

                fetch('/Cadastros/ListAdversario')
                    .then(res => res.json())
                    .then(data => {
                        var iCount = 0;
                        data.forEach(item => { item.id = iCount; this.listAdversario.push(item); iCount++; });
                        resolve(true);
                    });
            });
        },

        carregarQuadras: function () {

            return new Promise((resolve) => {

                fetch('/Cadastros/ListQuadra')
                    .then(res => res.json())
                    .then(data => {
                        var iCount = 0;
                        data.forEach(item => { item.id = iCount; this.listQuadra.push(item); iCount++; });
                        resolve(true);
                    });
            });
        },

        carregarEquipes: function () {

            return new Promise((resolve) => {

                fetch('/Cadastros/ListEquipe')
                    .then(res => res.json())
                    .then(data => {
                        var iCount = 0;
                        data.forEach(item => { item.id = iCount; this.listEquipe.push(item); iCount++; });
                        resolve(true);
                    });
            });
        },

        carregarPosicao: function () {

            return new Promise((resolve) => {

                fetch('/Cadastros/ListPosicao')
                    .then(res => res.json())
                    .then(data => {
                        var iCount = 0;
                        data.forEach(item => { item.id = iCount; this.listPosicao.push(item); iCount++; });
                        resolve(true);
                    });
            });
        }
    }
});