//import de biblioteca de validação e mask
Vue.use(VeeValidate);

//funcionalidades formulario Dados da Empresa (validations)
var appProfile = new Vue({
    el: '#appProfile',
    data: {
        Email: '',
        Nome: '',
        Perfil: 0
    },
    methods: {
        validarDados: function (e) {

            this.$validator.localize('pt_BR');

            this.$validator.validate().then(result => {

                e.preventDefault();
                //se passou em todas as validações
                if (result) {
                    appLoading.visible = true;
                    $("#frmProfile").submit();
                }
            });
        }
    }
});
