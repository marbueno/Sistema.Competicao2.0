var appProfile = new Vue({
    el: '#appProfile',
    data: {
        Email: '',
        Nome: '',
        Perfil: 0
    },

    mounted() {

        appMain.formName = '#frmProfile';
    }
});
