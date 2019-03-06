function formOnFail(error) {

    toastr.options = {
        positionClass: "toast-top-center"
    };

    if (error.status === 500)
        toastr.error(error.responseText);

    appLoading.visible = false;
}
