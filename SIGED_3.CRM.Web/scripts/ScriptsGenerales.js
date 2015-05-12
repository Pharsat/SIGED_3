var myWindow;
//Abre una ventana emergente con los parametros indicados
//function openWin(Id, URL) {
//    var params = [
//            'height=' + screen.height,
//            'width=' + screen.width,
//            'resizable=yes',
//            'scrollbars=yes',
//            'toolbar=no',
//            'menubar=no',
//            'location=no'
//    ].join(',');
//    if (Id == '0') {
//        if (myWindow == null) {
//            myWindow = window.open(URL, "_blank", params);
//        } else {
//            myWindow.open(URL, "_self", params);
//        }
//    } else {
//        if (myWindow == null) {
//            myWindow = window.open(URL + '?Id=' + Id, "_blank", params);
//        } else {
//            myWindow.open(URL + '?Id=' + Id, "_self", params);
//        }
//    }
//    myWindow.moveTo(0, 0);
//    myWindow.resizeTo(screen.availWidth, screen.availHeight);
//    myWindow.focus();
//    VentanaAbierta = true;
//};
function openWin(Id, URL) {
    var params = [
            'height=' + screen.height,
            'width=' + screen.width,
            'resizable=yes',
            'scrollbars=yes',
            'toolbar=no',
            'menubar=no',
            'location=no'
    ].join(',');
    if (Id == '0') {
        window.open(URL, "_blank", params);
    } else {
        window.open(URL + '?Id=' + Id, "_blank", params);
    }
    window.moveTo(0, 0);
    window.resizeTo(screen.availWidth, screen.availHeight);
    window.focus();
};
//Pregunta si desea eliminar registro
function EliminarRegistro() {
    if (confirm("¿Seguro desea eliminar los registros?"))
        return true;
    else
        return false;
};
//Cierra una ventana ante peticion
function closeWin(mensaje) {
    alert('Registro ' + mensaje + ' exitosamente.');
    window.opener.RecargarGrila();
    //window.close();
};
//muestra mensaje ante guardado pero sin cerrar la ventana ademas actualiza la grilla
function MensajeDos(mensaje) {
    alert('Registro ' + mensaje + ' exitosamente.');
    window.opener.RecargarGrila();
};
function MensajeTres(mensaje) {
    alert(mensaje);
};
// recarga la grilla principal pero sin mostrar ningun mensaje.
function RecargarSinMensaje() {
    window.opener.RecargarGrila();
};
//Metodos que configuran unsa sesion infinita
function establecerSesionInfinita() {
    setTimeout(updateSession, 1000 * 10);
};
function updateSession() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "/Configuracion/MantenerSesion/MantenerSesion.asmx/ActualizarSesion",
        data: "{}",
        dataType: "json"
    });
    setTimeout(updateSession, 1000 * 10);
};
//Cierra menu
function CierraMenu() {
    $('.MenuAbierto').animate({ width: 0, opacity: "0" }, 500);
    setTimeout(OcultarDiv, 500);
};
function AbreMenu() {
    $('.NoMenuAbierto').animate({ width: 0, opacity: "0" }, 500);
    setTimeout(OcultarDiv2, 500);
};
function OcultarDiv() {
    document.getElementById('Menu').className = 'MenuCerrado';
    document.getElementById('Menu').style.zIndex = -5000;
    document.getElementById('NoMenu').style.display = 'inline';
    $('.NoMenuCerrado').animate({ width: 28, opacity: "100" }, 500);
    setTimeout(MostrarDiv2, 500);
};
function MostrarDiv() {
    document.getElementById('Menu').className = 'MenuAbierto';
    document.getElementById('Menu').style.zIndex = 5000;
};
function OcultarDiv2() {
    document.getElementById('NoMenu').className = 'NoMenuCerrado';
    document.getElementById('NoMenu').style.zIndex = -5000;
    document.getElementById('Menu').style.display = 'inline';
    $('.MenuCerrado').animate({ width: 250, opacity: "100" }, 500);
    setTimeout(MostrarDiv, 500);
};
function MostrarDiv2() {
    document.getElementById('NoMenu').className = 'NoMenuAbierto';
    document.getElementById('NoMenu').style.zIndex = 5000;
};
function RecargarGrila() {
    __doPostBack('recargarPagina', '');
};
function Check_Click(objRef) {
    //Get the Row based on checkbox
    var row = objRef.parentNode.parentNode;
    //Get the reference of GridView
    var GridView = row.parentNode;
    //Get all input elements in Gridview
    var inputList = GridView.getElementsByTagName("input");
    for (var i = 0; i < inputList.length; i++) {
        //The First element is the Header Checkbox
        var headerCheckBox = inputList[0];
        //Based on all or none checkboxes
        //are checked check/uncheck Header Checkbox
        var checked = true;
        if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
            if (!inputList[i].checked) {
                checked = false;
                break;
            }
        }
    }
    headerCheckBox.checked = checked;
};
function checkAll(objRef) {
    var GridView = objRef.parentNode.parentNode.parentNode;
    var inputList = GridView.getElementsByTagName("input");
    for (var i = 0; i < inputList.length; i++) {
        //Get the Cell To find out ColumnIndex
        var row = inputList[i].parentNode.parentNode;
        if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
            if (objRef.checked) {
                inputList[i].checked = true;
            }
            else {
                inputList[i].checked = false;
            }
        }
    }
};
