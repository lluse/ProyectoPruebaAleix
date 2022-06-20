var nuevoCliente = {
    button_crear: '#nuevoCliente',

    Init: function () {
        nuevoCliente.InitBtnCrearEvent();
    },

    InitBtnCrearEvent: function () {
        $(nuevoCliente.button_crear).on('click', function () {
            informacionCliente.SetModal(0);
        });
    }
};

var informacionCliente = {
    modal_cliente: '#modalInformacionCliente',
    inputClientId: '#inputClientId',
    inputNombre: '#inputNombre',
    inputApellidos: '#inputApellidos',
    inputNif: '#inputNif',
    inputEmail: '#inputEmail',
    btnGuardar: '#btnGuardarInformacion',
    formInformacionCliente: '#formInformacionCliente',
    client_id: 0,

    Init: function () {
        informacionCliente.InitBtnGuardarEvent();
    },

    InitBtnGuardarEvent: function () {
        $(informacionCliente.btnGuardar).on('click', function () {
            var data = getFormData($(informacionCliente.formInformacionCliente));

            if (data.clientId == 0) {
                informacionCliente.CrearCliente(data);
            }
            else {
                informacionCliente.EditarClient(data);
            }
        });

        function getFormData($form) {
            var unindexed_array = $form.serializeArray();
            var indexed_array = {};

            $.map(unindexed_array, function (n, i) {
                indexed_array[n['name']] = n['value'];
            });

            return indexed_array;
        }
    },

    SetModal: function (clientId) {
        informacionCliente.client_id = clientId;
        if (clientId == 0) {
            informacionCliente.ResetInputs();
            informacionCliente.AbrirModal();
        }
        else {
            informacionCliente.GetCliente(clientId);
        }

    },

    GetCliente: function (clientId) {
        $.ajax({
            url: '/Home/GetCliente',
            data: {
                clientId: clientId
            },
            success: function (result) {
                if (result) {
                    informacionCliente.SetInformacionCliente(result);
                    informacionCliente.AbrirModal();
                } else {
                    console.log('ERROR CARGA DATA')
                }
            },
            error: function (xhr, status, error) {
                alert(error);
            }
        });
    },

    CrearCliente: function (data) {
        $.ajax({
            //type: 'POST',
            url: '/Home/CreateClient',
            data: data,
            //contentType: "application/json; charset=utf-8",
            success: function (result) {
                if (result) {
                    $(informacionCliente.modal_cliente).modal('hide');
                    alert('Cliente creado');
                    location.reload();
                } else {
                    console.log('ERROR CARGA DATA')
                }
            },
            error: function (xhr, status, error) {
                alert(error);
            }
        });
    },

    EditarClient: function (data) {
        $.ajax({
            //type: 'POST',
            url: '/Home/EditClient',
            data: data,
            //contentType: "application/json; charset=utf-8",
            success: function (result) {
                if (result) {
                    $(informacionCliente.modal_cliente).modal('hide');
                    alert('Cliente actualizado');
                    location.reload();
                } else {
                    console.log('ERROR CARGA DATA')
                }
            },
            error: function (xhr, status, error) {
                alert(error);
            }
        });
    },

    ResetInputs: function () {
        $(informacionCliente.inputClientId).val(0);
        $(informacionCliente.inputNombre).val('');
        $(informacionCliente.inputApellidos).val('');
        $(informacionCliente.inputNif).val('');
        $(informacionCliente.inputEmail).val('');
    },

    SetInformacionCliente: function (client) {
        $(informacionCliente.inputClientId).val(client.clientId);
        $(informacionCliente.inputNombre).val(client.nombre);
        $(informacionCliente.inputApellidos).val(client.apellidos);
        $(informacionCliente.inputNif).val(client.nif);
        $(informacionCliente.inputEmail).val(client.email);
    },

    AbrirModal: function () {
        $(informacionCliente.modal_cliente).modal('show');
    }
};

var deleteCliente = {
    modal_eliminar_cliente: '#confirm-delete-cliente',

    Init: function (clienteId) {
        // Bind click to OK button within popup
        $(deleteCliente.modal_eliminar_cliente).on('click', '.btn-ok', function (e) {
            var $modalDiv = $(e.delegateTarget);
            var id = $(this).data('recordId');

            $modalDiv.addClass('loading');
            $.ajax({
                url: '/Home/DeleteCliente',
                data: {
                    clientId: clienteId
                },
                success: function (result) {
                    if (result) {
                        $modalDiv.modal('hide').removeClass('loading');
                        alert('Cliente borrado');
                        location.reload();
                    } else {
                        console.log('ERROR CARGA DATA')
                    }
                },
                error: function (xhr, status, error) {
                    alert(error);
                }
            });
        });

        $(deleteCliente.modal_eliminar_cliente).on('show.bs.modal', function (e) {
            $('.btn-ok', this).data('recordId', clienteId);
        });

        $(deleteCliente.modal_eliminar_cliente).modal('show');
    }
}

$(document).ready(function () {
    nuevoCliente.Init();
    informacionCliente.Init();
});

function editarCliente(clientId) {
    informacionCliente.SetModal(clientId);
}

function eliminarCliente(clientId) {
    deleteCliente.Init(clientId);
}