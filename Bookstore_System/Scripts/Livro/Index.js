var _id_livro;

//angular.module('app', []).controller('controller',
//    function ($scope, $http) {
//         $http.get("../Livro/RetornaLivros").then(function (response)
//         {
//             $scope.livros = response.data;
//        });

//        $scope.orderBy = function (item) {
//            $scope.ordemPorNome = item;
//        }
//    });
$(document).ready(function () {

    //ListaLivros();

});

//function ListaLivros() {
//    complete_ajax_without_parameters_and_success("GET", "../Livro/RetornaLivros", "application/json;charset=utf-8").done(function (response) {

//        var livros = JSON.parse(response);

//        if (livros) {
//            $("#tabela_livros_body").html(livros.map((l) =>
//                `<tr>
//                    <td class="hidden">${l.id}</td>                
//                    <td>${l.nome}</td>
//                    <td>${l.autor}</td>
//                    <td>${l.editora}</td>
//                    <td>${l.data_lancamento}</td>
//                    <td>
//                        <button id="botao_editar_modal" class="btn btn-primary" data-toggle="modal" data-target="#modal_editar">Editar</button>
//                        <button id="botao_remover" class="btn btn-danger">Remover</button>
//                    </td>
//                </tr>`
//            ));
//        }
//    });
//}

function AdicionaLivro()
{
    var _nome = $("#nome").val(), _autor = $("#autor").val(), _editora = $("#editora").val(), _data_nascimento = $("#data_nascimento").val();

    if (VerificaCampos(_nome, _autor, _editora, _data_nascimento))
    {
        complete_ajax_with_parameters_without_success("POST", "../Livro/AdicionaLivro", "application/json;charset=utf-8",
            JSON.stringify({ nome: _nome, autor: _autor, editora: _editora, data_nascimento: _data_nascimento })).done(function (response) {

                var mensagem = JSON.stringify(response);

                if (mensagem) {
                    if (mensagem.Codigo == 200) {
                        renderSuccessAlert("#alerta-sucesso", mensagem.Texto);
                    }
                    else {
                        renderErrorAlert("#alerta-erro", mensagem.Texto);
                    }
                }

            });
    }
    else
    {
        renderErrorAlert("#alerta-erro", "Não é permitido campos vazios.")
    }
}

function EditaLivro() {
    var _nome = $("#nome_editar").val(), _autor = $("#autor_editar").val(), _editora = $("#editora_editar").val(), _data_nascimento = $("#data_nascimento_editar").val();

    if (VerificaCampos(_nome, _autor, _editora, _data_nascimento)) {
        complete_ajax_with_parameters_without_success("POST", "../Livro/EditaLivro", "application/json;charset=utf-8",
            JSON.stringify({ id_livro: _id_livro, nome: _nome, autor: _autor, editora: _editora, data_nascimento: _data_nascimento })).done(function (response) {

                var mensagem = JSON.stringify(response);

                if (mensagem) {
                    if (mensagem.Codigo == 200) {
                        renderSuccessAlert("#alerta-sucesso", mensagem.Texto);
                    }
                    else {
                        renderErrorAlert("#alerta-erro", mensagem.Texto);
                    }
                }

            });
    }
    else {
        renderErrorAlert("#alerta-erro", "Não é permitido campos vazios.")
    }
}

function RemoveLivro() {
    complete_ajax_with_parameters_without_success("POST", "../Livro/RemoveLivro", "application/json;charset=utf-8",
        JSON.stringify({ id_livro: _id_livro})).done(function (response) {

            var mensagem = JSON.stringify(response);

            if (mensagem) {
                if (mensagem.Codigo == 200) {
                    renderSuccessAlert("#alerta-sucesso", mensagem.Texto);
                }
                else {
                    renderErrorAlert("#alerta-erro", mensagem.Texto);
                }
            }

        });
}

$(document).on("click", "#botao_adicionar", function () {

    AdicionaLivro();

});

$(document).on("click", "#botao_editar", function () {

    EditaLivro();

});

$(document).on("click", "#botao_remover", function () {

    _id_livro = parseInt($(this).closes("tr").find("#id_livro").text());

    RemoveLivro();

});

$(document).on("click", "#botao_editar_modal", function ()
{
    _id_livro = parseInt($(this).closes("tr").find("#id_livro").text());
});

function VerificaCampos(nome, autor, editora, data_lancamento)
{
    return nome && autor && editora && data_lancamento;
}