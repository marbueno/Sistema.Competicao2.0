//Configuração VueValidation

const config = {
    locale: 'pt_BR'
};

Vue.use(VeeValidate, config);


var appMain = new Vue({
    el: '#appMain',
    data: {
        loadingVisible: false,
        newRegister: false,
        formName: ''
    },
    methods: {

        showForm: function (e) {
            this.newRegister = true;
        },

        validateData: function (e, form) {

            form.$validator.validate().then(result => {

                e.preventDefault();
                //se passou em todas as validações
                if (result) {
                    this.loadingVisible = true;
                    $(this.formName).submit();
                }
            });
        },

        cancelForm: function (e) {
            this.newRegister = false;
            e.preventDefault();
            return false;
        }
    }
});


$(function () {
    $('#side-menu').metisMenu();
});

//Loads the correct sidebar on window load,
//collapses the sidebar on window resize.
$(function () {
    $(window).bind("load resize", function () {
        width = (this.window.innerWidth > 0) ? this.window.innerWidth : this.screen.width;
        if (width < 768) {
            $('div.sidebar-collapse').addClass('collapse');
        } else {
            $('div.sidebar-collapse').removeClass('collapse');
        }
    });
});