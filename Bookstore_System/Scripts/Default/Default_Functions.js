var response;

function complete_ajax_without_parameters_and_success(type, url, contentType) {
    return $.ajax({
        type: type,
        url: url,
        contentType: contentType,
        beforeSend: function () {
            //showLoading();
        },
        error: function (e) {
            renderErrorAlert(e.statusText);
        },
        complete: function () {
            //hideLoading();
        }
    });
}

function complete_ajax_with_parameters_without_success(type, url, contentType, parameters) {
    return $.ajax({
        type: type,
        url: url,
        contentType: contentType,
        data: parameters,
        beforeSend: function () {
            //showLoading();
        },
        error: function (e) {
            renderErrorAlert(e.statusText);
        },
        complete: function () {
            //hideLoading();
        }
    });
}

function complete_ajax_with_parameters_without_success_and_content_type(type, url, parameters) {
    return $.ajax({
        type: type,
        url: url,
        data: parameters,
        beforeSend: function () {
            //showLoading();
        },
        error: function (e) {
            showError(e.statusText);
        },
        complete: function () {
            //hideLoading();
        }
    });
}

function showLoading() {
    $("#loading").removeClass("hidden");
}

function hideLoading() {
    $("#loading").addClass("hidden");
}

function renderSuccessAlert(text) {
    $("#alerta-sucesso-container").html(
        `
            <div class="alert alert-success alert-dismissible fade show">
                <div id="alerta-sucesso" role="alert">
                  ${text}   
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
            </div>`);

    $("#alerta-erro-container").attr("hidden", "hidden");
    $("#alerta-sucesso-container").removeAttr("hidden");
}

function renderErrorAlert(text)
{
    $("#alerta-erro-container").html(
        `
            <div class="alert alert-danger alert-dismissible fade show">
                <div id="alerta-erro" role="alert">
                  ${text}   
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
            </div>`);

    $("#alerta-sucesso-container").attr("hidden", "hidden");
    $("#alerta-erro-container").removeAttr("hidden");
}