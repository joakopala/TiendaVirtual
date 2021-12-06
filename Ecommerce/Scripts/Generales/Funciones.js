function validaCampoVacio(id, label) {

    if ($("#" + id).val().length === 0) {
        return "El campo " + label + " se encuentra vacio";
    }
    else {

        return "";
    }
}