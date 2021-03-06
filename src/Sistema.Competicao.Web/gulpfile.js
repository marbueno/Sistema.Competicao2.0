var gulp        = require('gulp');
var concat      = require('gulp-concat');
var cssmin      = require('gulp-cssmin');
var uncss       = require('gulp-uncss');
var browserSync = require('browser-sync').create();

gulp.task('browserSync', function () {
    browserSync.init({
        proxy: 'localhost:5000'
    });

    gulp.watch('./Styles/**/*.css', ['css', 'csslogin', 'cssadmin']);
    gulp.watch('./Scripts/**/*.js', ['js']);
});

gulp.task('js', function(){
    return gulp.src([
        './node_modules/bootstrap/dist/js/bootstrap.min.js',
        './node_modules/jquery/dist/jquery.min.js',
        './node_modules/jquery-ajax-unobtrusive/dist/jquery.unobtrusive-ajax.min.js',
        './node_modules/jquery-validation/dist/jquery.validate.min.js',
        './node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js',
        './node_modules/vue/dist/vue.min.js',
        './node_modules/v-mask/dist/v-mask.min.js',
        './node_modules/vee-validate/dist/vee-validate.min.js',
        './node_modules/vee-validate/dist/locale/pt_BR.js',
        './node_modules/moment/min/moment.min.js',
        './node_modules/moment/locale/pt-br.js',
        './node_modules/pc-bootstrap4-datetimepicker/build/js/bootstrap-datetimepicker.min.js',
        './node_modules/vue-bootstrap-datetimepicker/dist/vue-bootstrap-datetimepicker.min.js',
        './node_modules/datatables.net/js/jquery.dataTables.min.js',
        './node_modules/datatables.net-dt/js/dataTables.dataTables.min.js',
        './Scripts/jquery-ui.js',
        './Scripts/jquery.metisMenu.js',

        './Scripts/Comum/Main.vue.js',
        './Scripts/Comum/LoadData.vue.js',
        './Scripts/Account/Login.vue.js',
        './Scripts/Account/Profile.vue.js',
        './Scripts/Account/Perfil.vue.js',
        './Scripts/Account/Usuario.vue.js',
        './Scripts/Administracao/Parametros.vue.js',
        './Scripts/Cadastros/Quadra.vue.js',
        './Scripts/Cadastros/Adversario.vue.js',
        './Scripts/Cadastros/Atleta.vue.js',
        './Scripts/Cadastros/Equipe.vue.js',
        './Scripts/Cadastros/Posicao.vue.js',
        './Scripts/Controles/ControlePagamento.vue.js',
        './Scripts/Controles/TipoDespesaReceita.vue.js',

        './Scripts/site.js'
    ])
    .pipe(gulp.dest('wwwroot/js/'))
    .pipe(browserSync.stream());
});

gulp.task('css', function(){
    return gulp.src([
        './node_modules/bootstrap/dist/css/bootstrap.css',
        './Styles/site.css'
    ])
    .pipe(concat('site.min.css'))
    .pipe(cssmin())
    .pipe(uncss({ html: ['Views/**/*.cshtml']}))
    .pipe(gulp.dest('wwwroot/css'))
    .pipe(browserSync.stream());
});

gulp.task('csslogin', function () {
    return gulp.src([
        './node_modules/bootstrap/dist/css/bootstrap.css',
        './Styles/jquery-ui.css',
        './Styles/login.css'
    ])
    .pipe(concat('login.min.css'))
    .pipe(cssmin())
    //.pipe(uncss({ html: ['Areas/Admin/Views/**/*.cshtml'] }))
    .pipe(gulp.dest('wwwroot/css'))
    .pipe(browserSync.stream());
});

gulp.task('cssadmin', function () {
    return gulp.src([
        './node_modules/datatables.net-dt/css/jquery.dataTables.min.css',
        './node_modules/pc-bootstrap4-datetimepicker/build/css/bootstrap-datetimepicker.min.css',
        './Styles/spinner.css',
        './Styles/black-dashboard.css'
    ])
    .pipe(concat('admin.min.css'))
    .pipe(cssmin())
    .pipe(gulp.dest('wwwroot/css'))
    .pipe(browserSync.stream());
});